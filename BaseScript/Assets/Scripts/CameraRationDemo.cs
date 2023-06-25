using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 摄像头随鼠标，键盘前进，后台，上下左右旋转
/// </summary>

public class CameraRationDemo : MonoBehaviour
{
    public float speed = 40;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        // 摄像头上下，左右旋转
        float resY = Input.GetAxisRaw("Mouse Y");
        float resX = Input.GetAxisRaw("Mouse X");

        //上下旋转要选择自身坐标系
        this.transform.Rotate(-resY * speed, 0, 0);
        //左右旋转要选择世界坐标系
        this.transform.Rotate(0, resX * speed, 0, Space.World);
        //print("resY: " + resY + "  resX: " + resX);

        // 摄像头前后，左右移动
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");
        this.transform.Translate(moveH, 0, moveV);
        //print("moveH: " + moveH + "  moveV: " + moveV);

        //鼠标滚轮
        float scrollV = Input.GetAxis("Mouse ScrollWheel");
        print("scrollV: " + scrollV);

    }
}
