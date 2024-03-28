using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 3;//移动速度
    public float maxHp = 20;//最大血量

    Vector3 input; //键盘输入的行走方向
    float currentHp;//当前血量
    bool isDead = false;//是否已死


    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        //将键盘的横向，纵向行走量保存到变量中
        input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (!isDead)
        {
            Move();
        }
    }

    void Move()
    {
        //归一化向量：让输入更直接，同时避免斜着移动时速度值超过最大的速度。
        input = input.normalized;

        //行走：修改位置
        transform.position += input * speed * Time.deltaTime;
        //转身：修改朝向
        if (input.magnitude > 0.1f)
        {
            transform.forward = input;
        }

        //设置移动的边界
        Vector3 tmp = transform.position;
        const float Border = 10;
        if (tmp.z > Border)
        {
            tmp.z = Border;
        }
        if (tmp.z < -Border)
        {
            tmp.z = -Border;
        }

        if (tmp.x > Border)
        {
            tmp.x = Border;
        }
        if (tmp.x < -Border)
        {
            tmp.x = -Border;
        }
        transform.position = tmp;
    }
}
