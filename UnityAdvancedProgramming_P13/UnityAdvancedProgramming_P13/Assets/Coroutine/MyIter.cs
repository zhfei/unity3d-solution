using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///
/// </summary>

public class MyIter : MonoBehaviour
{

    IEnumerator<int> HelloWorld()
    {
        transform.position = new Vector3(1,0,0);
        yield return 233;

        transform.position = new Vector3(2, 0, 0);
        yield return 234;

        transform.position = new Vector3(3, 0, 0);
        yield return 235;
    }

    // Start is called before the first frame update
    void Start()
    {
        IEnumerator<int> e = HelloWorld();
        while(true)
        {
            //每次调用MoveNext()方法，函数都会走到yield处中断，并返回一个迭代器
            //可以通过e.Current获取当前return迭代器的值
            if (!e.MoveNext())
            {
                break;
            }
            Debug.Log("yield返回值："+e.Current);
            Debug.Log("物体当前位置：" + transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
