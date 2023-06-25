using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 三维向量
/// </summary>

public class VectorDemo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // 求模的大小
    void Update1()
    {
       Vector3 po = this.transform.position;

        // 向量的模
        var l1 = Mathf.Sqrt(Mathf.Pow(po.x, 2) + Mathf.Pow(po.y, 2) + Mathf.Pow(po.z, 2));
        var l2 = Vector3.Distance(Vector3.zero, po);
        //po.magnitude: po向量的模，po点相对于世界坐标原点的距离
        var l3 = po.magnitude;
        Debug.LogFormat("{0}-{1}-{2}", l1, l2, l3);

        // 标准向量，归一向量，单位向量：模长度为1的向量
        //po.normalized: 标准向量，归一向量，指的是将向量的模变成1，方向不变。改变后的向量。
        //debug划线，从世界坐标系原点，到当前的坐标点
        Debug.DrawLine(Vector3.zero, po);
        Debug.DrawLine(Vector3.zero, po.normalized,Color.red);
    }

    // 求方向，求向量模的方向，求标准向量，归一化向量
    private void Update2()
    {
        Vector3 po = this.transform.position;

        //向量/向量模长 = 标准化向量
        Vector3 n1 = po / po.magnitude;
        //使用向量API 求的 标准化向量
        Vector3 n2 = po.normalized;

        Debug.DrawLine(Vector3.zero,po);
        Debug.DrawLine(Vector3.zero,n2,Color.blue);
    }

    //向量的运算
    public Transform t1, t2, t3;
    private void Update()
    {
        //减 向量:结果是 结果向量从减数箭头点指向t1【被减数箭头点】+ 平移到t1和t2的起点交点处
        Vector3 n1 = t1.position - t2.position;

        if (Input.GetKey(KeyCode.A))
        {
            // 每次移动单位向量，这样距离越长，花费的时间就越长，能体现出距离感
            t3.Translate(n1.normalized);
        }

        // 加 向量：结果是 两个向量分别生成各自的辅助虚线向量，组成一个平行四边形，加向量的结果就是这个平行四边形的中间连线
        Vector3 n2 = t1.position + t2.position;
        if (Input.GetKey(KeyCode.B))
        {
            // 每次移动单位向量，这样距离越长，花费的时间就越长，能体现出距离感
            t3.Translate(n2.normalized);
        }

        Debug.DrawLine(Vector3.zero, n1);
        Debug.DrawLine(Vector3.zero, n2, Color.red);
    }
}
