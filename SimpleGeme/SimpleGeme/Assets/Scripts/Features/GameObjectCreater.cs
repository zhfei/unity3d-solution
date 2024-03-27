using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectCreater : MonoBehaviour
{
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        //-- 创建游戏对象 --

        //1.创建一个游戏对象，并放置在场景中
        GameObject go = Instantiate(prefab, null);
        Debug.Log("游戏对象创建成功：" + go.name);

        //2.创建一个游戏对象，并作为当前挂载物体的的子物体
        GameObject go1 = Instantiate(prefab, transform);
        Debug.Log("游戏对象创建成功：" + go1.name);

        //3.创建一个游戏对象，指定位置，朝向
        GameObject go2 = Instantiate(prefab, new Vector3(3, 0, 3), Quaternion.identity);

        //4.创建10个物体围成环形
        for (int i = 0; i < 10; i++)
        {
            Vector3 pos = new Vector3(Mathf.Cos(i * (2 * Mathf.PI) / 10), 0,
                Mathf.Sin(i * (2 * Mathf.PI) / 10));
            pos *= 5;       // 圆环半径是5
            Instantiate(prefab, pos, Quaternion.identity);
        }


        //-- 创建组件 --
        GameObject go3 = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
        Rigidbody rb = go3.AddComponent<Rigidbody>();
        rb.isKinematic = true;

    }
    // Update is called once per frame
    void Update()
    {
        //-- 销毁游戏对象 --
        if (Input.GetKeyDown(KeyCode.K))
        {
            GameObject go = GameObject.Find("Obstacler(Clone)");
            //Destroy(go, 0.1f); //延时销毁
            //Destroy(go); //并不会立刻销毁go对象，而是由系统在下一帧合适的时候进行销毁
            DestroyImmediate(go);//当前一帧立刻销毁

            //延时执行函数
            Invoke("DelayFunc", 5);
        }
    }

    void DelayFunc()
    {
        Debug.Log("延时执行："+Time.time);
    }
}
