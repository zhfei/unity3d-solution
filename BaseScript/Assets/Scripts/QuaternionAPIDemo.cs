using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 四元数常用API
///
/// </summary>

public class QuaternionAPIDemo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //四元数
        Quaternion qt = transform.rotation;
        //1.四元数 -> 欧拉角
        Vector3 euler = qt.eulerAngles;
        //2.欧拉角 -> 四元数
        Quaternion qt02 = Quaternion.Euler(0, 90, 0);
        //3.轴、角转换
        transform.rotation = Quaternion.AngleAxis(30, Vector3.up);
        transform.localRotation = Quaternion.AngleAxis(30,Vector3.up);

    }

    // Update is called once per frame
    public Transform target;
    void Update()
    {
        //4.注视旋转
        Quaternion dir = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = dir;
        transform.LookAt(target.position);

        //5.Lerp差值旋转，由快到慢
        transform.rotation = Quaternion.Lerp(transform.rotation,dir,0.1f);

        //6.RotateTowards: 匀速旋转
        transform.rotation = Quaternion.RotateTowards(transform.rotation,dir,0.1f);


        Quaternion dir2 = Quaternion.Euler(0,180,0);
        transform.rotation = Quaternion.Lerp(transform.rotation,dir2,0.0005f);
        //7.2个四元数角度差计算
        if (Quaternion.Angle(transform.rotation,dir2) < 30)
        {
            transform.rotation = dir2;
        }

        //8.从？到？的旋转
        transform.rotation = Quaternion.FromToRotation(Vector3.right,target.position - transform.position);

    }
}