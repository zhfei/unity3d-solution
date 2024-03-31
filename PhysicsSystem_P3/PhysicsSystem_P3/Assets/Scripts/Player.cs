using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///
/// </summary>

public class Player : MonoBehaviour
{
    Vector3 input;
    Rigidbody rigid; //刚体
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        //1.添加力
        //按空格键，往y方向添加300牛的力
        if (Input.GetButtonDown("Jump"))
        {
            //rigid.AddForce(new Vector3(0,100,0));

            //在没有落地前连续按空格键，可以实现二连跳,
            //二连跳是通过修改速度和添加力组合实现的。
            rigid.velocity = new Vector3(rigid.velocity.x,0, rigid.velocity.z);
            rigid.AddForce(new Vector3(0, 100, 0));
        }

        //2.修改速度
        //相比添加力会少了加速的过程
        if(Input.GetKey(KeyCode.J))
        {
            rigid.velocity = new Vector3(0, 0, 1);

            //Vector3 v0 = rigid.velocity;
            //rigid.velocity = v0 + new Vector3(0,0,1);
        }

        //3.射线检测
        if(Input.GetKey(KeyCode.K))
        {
            //创建从原点向上的射线
            Ray ray = new Ray(Vector3.zero, Vector3.up);

            //获得鼠标在屏幕上的位置
            Vector2 mousePos = Input.mousePosition;
            //创建一条射线，起点是摄像机位置，方向指向鼠标指针所在的点（隐含了从屏幕到世界的坐标系转换）
            Ray ray2 = Camera.main.ScreenPointToRay(mousePos);
            //发射射线, Mask设置射线仅会碰到的层
            gameObject.layer = LayerMask.NameToLayer("Default"); //给游戏对象修改层
            bool res = Physics.Raycast(ray,1000,LayerMask.GetMask("Default"));
            Debug.Log("射线检测结果："+res);
            Debug.DrawRay(transform.position, transform.position+transform.forward*100, Color.red,1000);

            //射线调试技巧
            //Physics.Raycast(起点，方向向量，长度);
            //Debug.DrawLine(起点，起点+方向向量.normal*长度，Color.red);

            //碰撞信息获取
            //TestRay();
        }

        //4.修改角速度
        if (Input.GetKey(KeyCode.R))
        {
            rigid.angularVelocity = new Vector3(0, 60,0);
            Debug.Log("角速度："+ rigid.angularVelocity+"角速度衰减系数："+rigid.angularDrag);
        }
    }

    void TestRay()
    {
        //声明变量，用于保存碰撞信息
        RaycastHit hitInfo;
        //1.发射射线，起点为物体位置，方向是世界前方
        if (Physics.Raycast(transform.position, Vector3.forward, out hitInfo))
        {
            //如果射线碰到物体

            //获取碰撞点坐标（世界坐标）
            Vector3 point = hitInfo.point;
            //获取对方的碰撞体组件
            Collider collider = hitInfo.collider;
            Transform transform = hitInfo.transform;
            //获取碰撞物体名称
            string name = transform.gameObject.name;
            //获取碰撞点的法线
            Vector3 normal = hitInfo.normal;
        }

        //2.不同的射线类型
        Ray ray = new Ray(Vector3.zero, Vector3.up);
        //Physics.SphereCast(ray, 20);//球形射线
        //Physics.BoxCast();//盒子射线
        //Physics.CapsuleCast();//胶囊射线

        //3.穿过多个物体的射线
        //射线穿过物体时不会停止
        RaycastHit[] raycastHits = Physics.RaycastAll(ray,1000);

        //4.区域覆盖型射线(Overlap)
        //场景：炸弹爆炸,10m内的物体都会收到波及
        Collider[] colliders = Physics.OverlapSphere(transform.position, 10);

    }



    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        input = new Vector3(h, 0, v);
        input = input.normalized;
        if (input.magnitude > 0.1f)
        {
            transform.forward = input.normalized;
            transform.position += input.normalized * 10 * Time.deltaTime;
        }
        
    }
}
