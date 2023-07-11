using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///
/// 坐标系转换
/// </summary>

public class PlayControllerDemo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //游戏物体的右侧在世界坐标系中的位置
        var v0 = transform.right;
        //本地坐标前1米在世界坐标系中的位置
        transform.TransformVector(Vector3.up);
        //世界坐标系中的Vector3(0,0,30)在本地坐标系中的位置
        transform.InverseTransformVector(new Vector3(0,0,30));
    }

    // Update is called once per frame
    void Update()
    {
        //判断游戏物体的屏幕坐标，判断游戏物体是否在屏幕内
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.x < Screen.width && screenPosition.y < Screen.height)
        {
            Debug.Log("在屏幕范围之内");
        }
        else
        {
            Debug.Log("在屏幕范围之外");
        }


        float hRes = Input.GetAxis("Horizontal");
        float vRes = Input.GetAxis("Vertical");

        //模拟左右旋转，移动，判断是否移除到屏幕之外
        if (hRes != 0 || vRes != 0)
        {
            var qt = Quaternion.LookRotation(new Vector3(hRes,0,vRes));
            qt = Quaternion.Lerp(transform.rotation,qt,1*Time.deltaTime);
            transform.rotation = qt;

            transform.Translate(0,0,1 * Time.deltaTime);
        }
    }
}
