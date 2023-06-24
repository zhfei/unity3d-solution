using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///
/// </summary>

public class CameraRationDemo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 摄像头上下，左右旋转
        float resY = Input.GetAxisRaw("Mouse Y");
        float resX = Input.GetAxisRaw("Mouse X");
        this.transform.Rotate(resY * 40, resX * 40, 0);
        //print("resY: " + resY + "  resX: " + resX);

        // 摄像头前后，左右移动
        float moveH = Input.GetAxisRaw("Horizontal");
        float moveV = Input.GetAxisRaw("Vertical");
        this.transform.Translate(moveH * Time.deltaTime, 0, moveV * Time.deltaTime);
        print("moveH: " + moveH + "  moveV: " + moveV);
    }
}
