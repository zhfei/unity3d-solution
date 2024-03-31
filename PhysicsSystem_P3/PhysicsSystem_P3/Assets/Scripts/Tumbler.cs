using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///
/// </summary>

public class Tumbler : MonoBehaviour
{
    Rigidbody rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();

        //1.修改质心位置：centerOfMass
        //重心下移，变成不倒翁
        rigid.centerOfMass = new Vector3(0,-1,0);
    }

    // Update is called once per frame
    void Update()
    {
        //1.自定义施加力
        if(Input.GetKeyDown(KeyCode.B))
        {
            Vector3 position = transform.position + transform.up;
            //指定施加力的方向，施加力的方式
            //施加力的模式ForceMode常用的有：Force默认模式，遵守牛顿力学；Impulse爆炸默认，遵守牛顿力学
            rigid.AddForceAtPosition(new Vector3(0,0,50), position, ForceMode.Force);
        }
        //2.添加冻结约束
        if(Input.GetKeyDown(KeyCode.D))
        {
            //冻结约束
            rigid.constraints = RigidbodyConstraints.FreezeRotationY;
        }
    }
}
