using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 碰撞检测
///
/// </summary>

public class ColisionDemo : MonoBehaviour
{

    public float speet = 30;

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
        //Debug.Log(collision.collider.name);
        Debug.Log(string.Format("碰撞器碰撞了：{0}", collision.collider.name));

        //撞击的碰撞点
        ContactPoint cp = collision.contacts[0];
        //cp.point碰撞点的世界坐标
        //cp.normal碰撞点接触面的法线
    }
    //中间的每一帧
    private void OnCollisionStay(Collision collision)
    {
        
    }
    // 碰撞结束时，接触的最后一帧，触发回调
    private void OnCollisionExit(Collision collision)
    {
        
    }


    //触发回调，接触的第一帧，触发回调
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(string.Format("触发器触发了：{0}", other.name));
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        
    }

    //当物体的移动速度非常快时可能检测不到触发和碰撞，情况是在接触前那一刻检测，等第二次检测时已经穿过去了，判断结果还是没有接触
    private void FixedUpdate()
    {
        Debug.Log(string.Format("frameCount: {0}", Time.frameCount));
        this.transform.Translate(Time.deltaTime * speet * -1, 0, 0);
    }
}
