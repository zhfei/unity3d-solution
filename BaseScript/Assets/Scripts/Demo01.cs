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

        //Debug.Log("日志打印：构造函数");
    }


    // ------------------------Unity生命周期------------------------  

    // --------------初始阶段---------------  

    //调用顺序0：游戏对象创建并启用，调用1次
    public void Awake()
    {
        //Unity中，会批量先创建所有的对象【调用 Awake()】, 然后在批量调用所有对象的Start方法【如果满足启用条件】
        Debug.Log("Awake: " + Time.time + "--" + this.name);
    }

    //调用顺序1：游戏对象创建并启用，脚本对象启用，调用1次
    public void Start()
    {
        Debug.Log("Start: " + Time.time + "--" + this.name);
    }
    //调用顺序1.1：脚本对象启用1次调用1次
    private void OnEnable()
    {
        Debug.Log("OnEnable: " + Time.time + "--" + this.name);
    }



    // --------------物理阶段---------------  

    //常用于模拟物体的物理效果，比如物体倒下的效果。它以固体的调用频率（默认0.02s）执行一次
    //与渲染频率不一致，因为渲染调用随着它上一次渲染时的任务量不同而变化，比如上次渲染的物体多，等到下次渲染时，等待的时间就长一点。
    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate: " + " -- " + Time.time);
    }



    // --------------游戏逻辑---------------  
    // 屏幕的实际渲染频率，用于处理游戏的逻辑，每次屏幕渲染一次，处理一次游戏的逻辑
    private void Update()
    {
        
    }
}
