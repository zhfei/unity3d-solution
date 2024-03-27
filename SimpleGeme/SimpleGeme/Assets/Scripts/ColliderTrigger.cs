using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTrigger : MonoBehaviour
{

    //触发事件
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("收到触发事件："+other.gameObject.name);
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("进入触发事件：" + other.gameObject.name);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("离开触发事件：" + other.gameObject.name);
    }

    //碰撞事件
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("收到碰撞事件：" + collision.gameObject.name);
    }
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("进入碰撞事件：" + collision.gameObject.name);
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("离开碰撞事件：" + collision.gameObject.name);
    }
}
