using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///
/// </summary>

public class ObjPool : MonoBehaviour
{
    //物体的缓存池，用字典表示。键为种类ID，值是同类物体的队列
    //以预制体的ID作为每个种类的标识ID
    private Dictionary<int, Queue<GameObject>> m_pool = new Dictionary<int, Queue<GameObject>>();
    //记录所有离开对象池的物体。键为物体引用，值是种类ID
    //对象从my_pool中离开，然后在m_OutObjs中记录
    private Dictionary<GameObject, int> m_OutObjs = new Dictionary<GameObject, int>();


    //创建游戏物体，预制体由调用者传入
    public GameObject Create(GameObject prefab)
    {
        //使用预制体的物体ID，作为该类物体的ID
        int id = prefab.GetInstanceID();
        //1.从对象池中创建物体
        GameObject go = _GetFromPool(id);

        if(go == null)
        {
            go = Instantiate(prefab);
            if(!m_pool.ContainsKey(id))
            {
                //添加一种新类型
                m_pool.Add(id,new Queue<GameObject>());
            }
        }

        //2.在离开池中做标记
        m_OutObjs.Add(go,id);
        return go;
    }
    //销毁物体
    public void Destroy(GameObject go)
    {
        //判断物体是否通过对象池创建
        if(!m_OutObjs.ContainsKey(go))
        {
            Debug.LogWarning("回收的物体不是对象池创建的："+go);
            return;
        }

        //该物体属于哪个类
        int id = m_OutObjs[go];


        go.transform.parent = gameObject.transform;
        go.SetActive(false);

        m_pool[id].Enqueue(go);
        m_OutObjs.Remove(go);
    }

    //从对象池中根据id取出物体，如果类型不存在或者物体用完了则返回null
    private GameObject _GetFromPool(int id)
    {
        if(!m_pool.ContainsKey(id) || m_pool[id].Count == 0)
        {
            return null;
        }

        GameObject go = m_pool[id].Dequeue();
        go.SetActive(true);
        return go;
    }
}
