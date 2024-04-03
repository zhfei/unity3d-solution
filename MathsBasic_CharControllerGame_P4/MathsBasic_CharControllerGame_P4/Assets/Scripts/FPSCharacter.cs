using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///
/// </summary>

public class FPSCharacter : MonoBehaviour
{

    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        //隐藏鼠标指针
        Cursor.visible = false;
        //锁定鼠标指针到屏幕中央
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        MouseLook();
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal"); //左右
        float v = Input.GetAxis("Vertical"); //前后

        //右方
        Vector3 r = transform.right;
        //（正）前方： 如果玩家仰头，那么它的正前方是往天上指的，这里把y轴的向量值重置为0，表示无论玩家是否仰望，行走方向都是往正前方走
        Vector3 f = new Vector3(transform.forward.x,0,transform.forward.z);

        //行走方向：当玩家同时按住左右和前后键时，算出它们的向量合，往斜着走
        //这里以右方向，正前方为向量基值，来计算两个向量的合。
        Vector3 runV = r * h + f * v;

        //角色移动
        transform.position = transform.position + runV * Time.deltaTime * speed;

    }

    void MouseLook()
    {
        float mh = Input.GetAxis("Mouse X"); //鼠标水平滑动
        float mv = Input.GetAxis("Mouse Y"); //鼠标前后滑动

        Quaternion qLR = Quaternion.Euler(0,mh,0); //鼠标水平滑动 左右旋转
        Quaternion qUD = Quaternion.Euler(mv,0,0); //鼠标前后滑动 上下旋转

        transform.rotation = qLR * transform.rotation; //左右旋转：沿世界坐标系
        transform.rotation = transform.rotation * qUD; //上下旋转：沿局部坐标系

        //angle仰俯 角度判断
        float angle = transform.eulerAngles.x;
        //对于欧拉角，经常出现-1和359度混乱判断，下面对这些情况进行处理
        if (angle > 180) { angle -= 360; }
        if (angle < -180) { angle += 360; }

        //限制抬头，低头角度
        if(angle > 80)
        {
            //这里的Z轴写成0，没有写成transform.eulerAngles.z的目的是：防止误差累加，随时纠正为直立状态
            transform.eulerAngles = new Vector3(80, transform.eulerAngles.y, 0);
        }
        if (angle < -80)
        {
            //这里的Z轴写成0，没有写成transform.eulerAngles.z的目的是：防止误差累加，随时纠正为直立状态
            transform.eulerAngles = new Vector3(-80, transform.eulerAngles.y, 0);
        }
    }
}
