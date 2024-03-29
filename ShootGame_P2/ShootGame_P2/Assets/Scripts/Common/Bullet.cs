using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1.0f;//子弹的飞行速度
    public float lifeTime = 10.0f;//子弹的生命周期（几秒后消失）
    float startTime;//子弹出生时间

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;

        if(startTime+lifeTime < Time.time)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //子弹发生碰撞
        if(CompareTag(other.tag))
        {
            //如果子弹的tag与被碰撞物体的tag相同，则忽略碰撞事件
            return;
        }
        Destroy(this.gameObject);
    }
}
