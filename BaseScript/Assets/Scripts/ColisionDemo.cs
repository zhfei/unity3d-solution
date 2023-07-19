using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 碰撞检测
///
/// </summary>

public class ColisionDemo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 碰撞开始时，接触的第一帧，触发回调
    private void OnCollisionEnter(Collision collision)
    {
        //通过collision.collider拿到了另一碰撞对象的碰撞器，那么就可以通过这个碰撞器获取这个对象上所有的其他组件。
        //collision.collider.GetComponent<MeshRenderer>();
        Debug.Log(collision.collider.name);
    }

    private void OnCollisionStay(Collision collision)
    {
        
    }
    // 碰撞结束时，接触的最后一帧，触发回调
    private void OnCollisionExit(Collision collision)
    {
        
    }
}
