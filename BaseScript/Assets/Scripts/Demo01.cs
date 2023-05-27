using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///
/// </summary>
public class Demo01 : MonoBehaviour
{
    //public 即可以在编译器中可见，又可以在其他类中访问
    public int score = 10;


    //SerializeField：在编译器中显示私有变量
    [SerializeField]
    private int age = 10;

    //HideInInspector：在编译器中隐藏公开字段
    [HideInInspector]
    public string name = "jack";

    //Range(0,100)：编译器中设置数据设置范围
    [Range(0,100)]
    public int nums = 0;


    public float time;
    //C#类与Unity类对比
    /*
     * C#
     * 字段
     * 属性
     * 构造方法
     * 方法
     */

     /*
     * Unity脚本
     * 字段
     * 方法
     */


    //在Unity中，脚本中不要写构造函数
    public Demo01()
    {
        //在Unity中，场景中对象实例的创建是统一放在子线程中做的，而Untiy中提供的很多API是在主线程中执行的，所以在构造方法中
        //调用Unity中的API会报错：不能在子线程中调用组线程成员
        //time = Time.time;

        Debug.Log("日志打印：构造函数");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
