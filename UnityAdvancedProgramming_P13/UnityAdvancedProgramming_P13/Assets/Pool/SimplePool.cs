using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 只存放一种游戏对象的简单对象池
/// </summary>


public class SimplePool : MonoBehaviour
{
    //其他脚本中无法访问，Unity编辑器可以编辑
    [SerializeField]
    private GameObject _prefab;
    //队列，与List相似，先进先出
    private Queue<GameObject> _poolInstanceQueue = new Queue<GameObject>();

    public GameObject Create()
    {
        if(_poolInstanceQueue.Count > 0)
        {
            GameObject go = _poolInstanceQueue.Dequeue();
            go.SetActive(true);
            return go;
        }
        //新建
        return Instantiate(_prefab);
    }

    public void Destroy(GameObject go)
    {
        _poolInstanceQueue.Enqueue(go);
        go.SetActive(false);
        go.transform.SetParent(gameObject.transform);
    }
}
