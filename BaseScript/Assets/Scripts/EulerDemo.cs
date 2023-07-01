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
    }
}
