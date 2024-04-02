using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///
/// </summary>

public class Coordinate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //向量的计算
        //向量点乘: 求标量向量一方上的投影距离
        Vector3 a = new Vector3(2,1,0);
        Vector3 b = new Vector3(3,0,0);
        Vector3 dir_b = b.normalized; //将b向量归一化
        float pa = Vector3.Dot(a,dir_b); //pa表示向量a,在向量dir_b方向上的投影长度

        //向量叉乘：其2个向量组成平面的法线，垂直线
        //叉乘方向使用的是左手定则：手掌沿着一个方向放平，四指向第二个向量握拳，拇指指向的方向就是叉乘方向
        Vector3 n = Vector3.Cross(a,b); //n是该平面的法线
        n = n.normalized; //归一化法线


    }

    // Update is called once per frame
    void Update()
    {
        //// 鼠标指针位置是屏幕坐标系
        //Vector2 mousePos = Input.mousePosition;
        ////将鼠标指针位置转化为视图坐标系时，需要使用摄像机计算
        //Vector3 viewPoint = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        //Debug.Log("鼠标在屏幕坐标系的值："+mousePos+ "在视图坐标系的值："+viewPoint);

        Vector3 nor = transform.forward;
        Vector3 nor2 = Vector3.forward;
        //Debug.Log("摄像机的前方："+(transform.position+ nor) +" 世界坐标系的前方："+nor2);


        //坐标系转换
        //transform.TransformPoint();//转换局部坐标到世界坐标
        //transform.InverseTransformPoint();//转换世界坐标到局部坐标

        //Vector3 v = transform.InverseTransformDirection(Vector3.forward);
        Vector3 v = transform.TransformDirection(Vector3.forward);
        Debug.Log("摄像机的前方1：" + (transform.position + nor) + " 摄像机的前方2：" + v);

    }
}
