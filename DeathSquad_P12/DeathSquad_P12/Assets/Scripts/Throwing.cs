using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwing : MonoBehaviour
{

    public Vector3 throwTarget; //投掷时，指定的投掷点

    float time;//飞行时间
    float speedParam = 20;
    Vector3 startPos;
    float vx, vy, vz, a, T;

    bool free;//free为true表示不受脚本控制，变成普通刚体
    Rigidbody rigid; //动力学刚体
    Collider coll; //触发器

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();

        startPos = transform.position;
        //目标向量
        Vector3 to = throwTarget - startPos;
        float d = to.magnitude;

        //下面根据距离计算出合适的参数：抛物线高度，初始速度

        T = d / speedParam; //预计飞行时间T
        float h = d * 0.4f; //抛物线高度h, 距离越远，抛物线高度越高
        a = 2.0f * h / (T * T / 4.0f);//加速度a
        vy = a * (T/2); //Y轴初速度
        vx = to.x / T; //X轴初速度
        vz = to.z / T; //Z轴初速度

        free = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (free) return;
        transform.Rotate(0,3,0); //空中旋转

        float dt = Time.deltaTime;
        time += dt;
        transform.position += new Vector3(vx,vy,vz)*dt; //随时间改变物理位置

        vy -= a * dt; //Y轴方向的速度受加速度影响
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") return;
        if (free) return;

        //当投掷物碰到地面或者障碍物时，切换成普通普通的刚体和碰撞器
        free = true;
        coll.isTrigger = false;
        rigid.isKinematic = false;
    }

    //被其他地方调用，投掷物被敌人发现后，过一段时间消失
    public void DelayDestroy()
    {
        Destroy(gameObject,10);
    }
}
