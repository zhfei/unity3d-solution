using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 四元数常用API
///
/// </summary>

public class QuaternionAPIDemo : MonoBehaviour
{
    public float moveSpeed = 1;
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
        //transform.rotation = Quaternion.AngleAxis(30, Vector3.up);
        //transform.localRotation = Quaternion.AngleAxis(30,Vector3.up);

    }

    // Update is called once per frame
    public Transform target;
    
    private void OnGUI()
    {
        Quaternion dir = Quaternion.LookRotation(target.position - transform.position);
        if (GUILayout.RepeatButton("LookRotation+++++++++++++++++++"))
        {
            //4.注视旋转
            //方法1
            //Quaternion dir2 = Quaternion.LookRotation(target.position - transform.position);
            //transform.rotation = dir2;
            //方法2
            transform.LookAt(target.position);
        }
        if (GUILayout.RepeatButton("Lerp"))
        {
            //5.Lerp差值旋转，由快到慢
            //它与注视旋转的区别是：注视旋转是一帧设置完成，Lerp是多帧设置完成
            transform.rotation = Quaternion.Lerp(transform.rotation, dir, 0.1f);
        }
        if (GUILayout.RepeatButton("RotateTowards"))
        {
            //6.RotateTowards: 匀速旋转
            transform.rotation = Quaternion.RotateTowards(transform.rotation, dir, 0.1f);
        }
        if (GUILayout.RepeatButton("Angle角度判断"))
        {
            Quaternion dir2 = Quaternion.Euler(0, 180, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, dir2, 0.005f);
            //7.2个四元数角度差计算
            if (Quaternion.Angle(transform.rotation, dir2) < 30)
            {
                transform.rotation = dir2;
            }
        }
        
    }

    void Update()
    {
        //上面提供的方法默认的旋转轴是绕z轴，如果想绕x轴旋转,可通过下面的方式
        //this.transform.right = target.position - this.transform.position;
        //从x轴正方向 -> 注视目标位置的方向
        //8.从？到？的旋转
        //transform.rotation = Quaternion.FromToRotation(Vector3.right, target.position - transform.position);



        //课后作业：物体随ad/sw进行上下旋转
        var hRes = Input.GetAxis("Horizontal");
        var vRes = Input.GetAxis("Vertical");

        if (hRes != 0 || vRes != 0)
        {
            Debug.Log(string.Format("hRes:{0}- vRes:{1}", hRes, vRes));
            //transform.rotation = Quaternion.LookRotation(new Vector3(hRes, 0, vRes));

            //带旋转过程
            var targetRotation = Quaternion.LookRotation(new Vector3(hRes, 0, vRes));
            transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, moveSpeed *Time.deltaTime);
            

            transform.Translate(0, 0, moveSpeed * Time.deltaTime);
        }
    }

    
}
