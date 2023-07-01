using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 三维向量, 三角函数
/// </summary>

public class VectorDemo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // 向量的长度：求模的大小
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

    // 向量的方向：求方向，求向量模的方向，求标准向量，归一化向量
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

    //向量的加、减运算
    public Transform t1, t2, t3;
    private void Update3()
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

    //角度和弧度的转换：Degree角度 -> Radian弧度
    private void Update4()
    {
        //角度 -> 弧度： 弧度 = 角度数 * PI/180
        float d1 = 60;
        float r1 = d1 * Mathf.Deg2Rad;
        float r2 = d1 * Mathf.PI / 180;
        print("r1: "+r1 + "  r2:"+r2);

        //弧度 -> 角度： 角度 = 弧度数 * 180/PI
        float r02 = Mathf.PI / 3;
        float g02 = r02 * 180 / Mathf.PI;
        float g03 = r02 * Mathf.Rad2Deg;
        print("g02: "+g02+"  g03:"+g03);

    }

    //三角函数， 已知一个三角形里的2个部分（角度，边长），就能求出其他部分（角度，边长）
    private void Update5()
    {
        //列如：已知角度x, 边长b， 求边长a
        //根据公式：tanx = a/b
        float x = 50, b = 20;
        float a = Mathf.Tan(x * Mathf.Deg2Rad) * b;
        //Debug.Log(a);

        //已知:边长a, 边长b, 求角度 angle
        //公式：angle = arc tan(a/b)
        float angle = Mathf.Atan(a / b);
        float angle2gad = Mathf.Rad2Deg * angle;
        
        //Debug.Log(string.Format("{0}:{1}", angle, angle2gad));


        //三角函数在项目中的运用
        //TransformPoint将自身坐标系中的点转成世界坐标系中的点，
        //TransformPoint(0, 0, 10)的意思是延物体自身坐标向前(z轴)走10米，然后将这个点转到世界坐标系中对应的点
        Vector3 worldSpaceP = transform.TransformPoint(0, 0, 10);
        Debug.DrawLine(this.transform.position, worldSpaceP);

        //练习：计算物体右前方30度，10m远的坐标
        // 根据题目可知，是知道角度和斜边，求a,b边
        // 由公式：sinx = a/c, cosx = b/c 得：
        // x = a = c * sinx; z = b = c * cosx;
        float movX = 10 * Mathf.Sin(30 * Mathf.Deg2Rad);
        float movZ = 10 * Mathf.Cos(30 * Mathf.Deg2Rad);

        Vector3 worldSpaceP2 = transform.TransformPoint(movX, 0, movZ);
        Debug.DrawLine(this.transform.position, worldSpaceP2, Color.red);
    }

    //向量的点乘与叉乘
    public float dotDegValue;
    private void Update()
    {
        Debug.DrawLine(Vector3.zero, t1.position);
        Debug.DrawLine(Vector3.zero, t2.position);

        //根据向量的点乘，求夹角
        //注意：点乘求出来的夹角是2个单位向量的最小夹角，如果两个向量的夹角大于180，比如270，则求出来的结果是哪个小部分，90度。
        float dotValue = Vector3.Dot(t1.position.normalized, t2.position.normalized);
        dotDegValue = Mathf.Acos(dotValue) * Mathf.Rad2Deg;
        Debug.Log(dotDegValue);

        //根据2个向量的叉乘，求夹角夹角是否大于180,当小于180时，结果向量的y是大于0的，大于180时，结果向量的y是小于0的
        //2个向量叉乘的意义为：得出2个向量组成平面的垂直向量
        Vector3 crossValue = Vector3.Cross(t1.position, t2.position);
        Debug.DrawLine(this.transform.position, crossValue, Color.red);
        //y小于0，大于180
        if (crossValue.y < 0)
        {
            dotDegValue = 360 - dotDegValue;
        }
    }









}
