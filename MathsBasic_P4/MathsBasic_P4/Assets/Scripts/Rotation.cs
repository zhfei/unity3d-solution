using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///
/// </summary>

public class Rotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //通过transform.rotation可以获取物体当前的朝向，通过Quaternion.Euler()方法可以借用角度创建出任意的旋转量。未来与旋转有关的操作都可以套用这两种基本方法。

        //1.使用横竖移动+ctr键控制人物的旋转
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //将横向转化为左右旋转，纵向转化为俯仰旋转， 得到一个很小的旋转四元数
        Quaternion samllQuaternion = Quaternion.Euler(v, h, 0.0f);

        if(Input.GetButton("Fire1"))
        {
            //鼠标左键或Ctr键,沿着世界坐标轴旋转
            transform.rotation = samllQuaternion * transform.rotation;
        } else
        {
            //沿着局部坐标系旋转
            transform.rotation = transform.rotation * samllQuaternion;
        }

        //2.使用鼠标点击控制角色旋转
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            //主角在旋转时会低头。这是因为角色有一定高度，地面上的点低于角色，因此角色会向下看。解决方案是将结果向量的y轴设置为与角色高度一致
            Vector3 vp = hit.point - transform.position;
            vp.y = transform.forward.y;
            transform.forward = vp;
        }
    }
}
