using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject prefabBoomEffect; //用于制作死亡效果的预制体

    public float speed = 2.0f;
    public float fireTime = 0.1f;
    public int maxHp = 1;

    Vector3 input;

    Transform player;
    float hp;
    bool dead = false;
    Weapon weapon;


    // Start is called before the first frame update
    void Start()
    {
        //从场景中根据tag查找游戏对象
        player = GameObject.FindGameObjectWithTag("Player").transform;
        weapon = GetComponent<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PlayerBullet"))
        {
            Destroy(other.gameObject);
            hp--;
            if(hp <= 0)
            {
                //播放死亡动效
                //Instantiate(prefabBoomEffect, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }

    void Move()
    {
        //敌人指向玩家的向量：通过向量+-向量计算得到
        input = player.transform.position - transform.position;

        input = input.normalized;
        transform.position = transform.position + input * speed * Time.deltaTime;
        if(input.magnitude > 0.1f)
        {
            transform.forward = input;
        }
    }

    void Fire()
    {
        //一直开枪
        weapon.Fire(true, true);
    }
}
