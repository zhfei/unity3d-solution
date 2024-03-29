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

    Weapon weapon;


    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
        weapon = GetComponent<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        //将键盘的横向，纵向行走量保存到变量中
        input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //开火
        bool fireKeyDown = Input.GetKeyDown(KeyCode.J);
        bool fireKeyPressed = Input.GetKey(KeyCode.J);
        bool changeWeapon = Input.GetKeyDown(KeyCode.Q);

        if (!isDead)
        {
            Move();

            weapon.Fire(fireKeyDown,fireKeyPressed);
            if(changeWeapon)
            {
                ChangeWeapon();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("EnemyBullet"))
        {
            if(currentHp <= 0)
            {
                return;
            }
            currentHp--;
            if (currentHp <= 0)
            {
                isDead = true;
            }
            Debug.Log("掉血，剩余血量："+currentHp);
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

    void ChangeWeapon()
    {
        int type = weapon.Change();
        switch(type)
        {
            case 0:
                {
                    Debug.Log("手枪");
                    break;
                }
            case 1:
                {
                    Debug.Log("散弹枪");
                    break;
                }
            case 2:
                {
                    Debug.Log("步枪");
                    break;
                }
        }
    }
}
