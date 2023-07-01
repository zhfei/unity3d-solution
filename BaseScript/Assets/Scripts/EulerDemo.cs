using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 欧拉角和四元数
/// 用于表示物体在三维向量中的位置
/// </summary>

public class EulerDemo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //欧拉角和四元数：用于表示一个物体在三维坐标系中的位置
    private void OnGUI()
    {
        if (GUILayout.RepeatButton("欧拉角X轴"))
        {
            //欧拉角采用Vector3类型设置是因为Vector3中有对应x,y,z的值，这和欧拉角中设置x,y,z轴上的旋转角度虽然数值意义不同，但它们有相同的数据结构，这是
            //欧拉角选择使用Vector3表示的原因
            //两者的区别如下：

            //1.位置：有方向（从世界坐标系原点指向当前点），有大小（从世界坐标原点到当前点的位置）
            //向量的x,y,z分别表示当前点在各个轴向上的有向位移
            Vector3 pos = this.transform.position;

            //2.欧拉角，没有方向，大小的概念。它表示的是在x,y,z轴上转了多少度
            Vector3 euler = this.transform.eulerAngles;

            //各分量相加 
            this.transform.eulerAngles += new Vector3(1, 0,0);
        }

        if (GUILayout.RepeatButton("欧拉角Y轴"))
        {
            this.transform.eulerAngles += Vector3.up;
        }
        if (GUILayout.RepeatButton("欧拉角Z轴"))
        {
            this.transform.eulerAngles += Vector3.forward;
        }


        //四元数就是用来旋转用的，它是轴角模式的旋转,与欧拉角不同的是四元数的旋转全部是绕自己的x,y,z轴旋转。而欧拉角是x,z绕自身的轴y是绕世界坐标系的y，用来解决欧拉角的万向节死锁问题
        if (GUILayout.RepeatButton("四元数旋转"))
        {
            //四元数设置需要2个条件：1.绕哪个轴，2.转多少度

            //绕y轴
            Vector3 axis = Vector3.right;
            //旋转弧度
            float radValue = 60 * Mathf.Deg2Rad;

            //组建四元数
            Quaternion qt = new Quaternion();
            qt.x = axis.x * Mathf.Sin(radValue / 2);
            qt.y = axis.y * Mathf.Sin(radValue / 2);
            qt.z = axis.z * Mathf.Sin(radValue / 2);
            qt.w = Mathf.Cos(radValue / 2);
            //设置四元数
            //this.transform.rotation = qt;

            //使用系统便捷方式设置四元数。欧拉角转成四元数
            this.transform.rotation = Quaternion.Euler(60,0,0);
        }

        if (GUILayout.RepeatButton("四元数X轴旋转"))
        {
            this.transform.rotation *= Quaternion.Euler(1,0,0);
        }
        if (GUILayout.RepeatButton("四元数Y轴旋转"))
        {
            this.transform.rotation *= Quaternion.Euler(0, 1, 0);
        }
        if (GUILayout.RepeatButton("四元数Z轴旋转"))
        {
            this.transform.rotation *= Quaternion.Euler(0, 0, 1);
        }
    }
}
