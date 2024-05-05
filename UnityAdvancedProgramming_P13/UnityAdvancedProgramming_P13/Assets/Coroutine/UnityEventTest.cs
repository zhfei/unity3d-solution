using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

//0.定义Unity事件
[Serializable] //通过Serializable特性声明，可以在编辑器中看到
public class MyEvent1 : UnityEvent<Vector3> { }
[Serializable] 
public class MyEvent3 : UnityEvent<int,int,string> { }

/// <summary>
///
/// </summary>

public class UnityEventTest : MonoBehaviour
{

    public MyEvent1 testEvent1;
    public MyEvent3 testEvent3;

    //一个参数的测试函数
    void F1(Vector3 pos)
    {
        Debug.Log("F1:"+pos);
    }
    void F3(int a, int b, string c)
    {
        Debug.LogFormat("F3 : {0} {1} {2}",a,b,c);
    }

    // Start is called before the first frame update
    void Start()
    {
        //1.添加订阅
        testEvent1.AddListener(F1);
        testEvent3.AddListener(F3);
        testEvent3.AddListener((int a, int b, string c)=> {
            Debug.Log("Lambda:"+a+b+c);
        });

        //2.发送通知
        testEvent1.Invoke(new Vector3(3,5,10));
        testEvent3.Invoke(8,7,"Hello");

        //3.删除订阅
        testEvent3.RemoveListener(F3);
        testEvent3.Invoke(8, 7, "Hello");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
