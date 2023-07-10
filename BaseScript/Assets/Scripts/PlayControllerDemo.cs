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
            Debug.Log("在屏幕范围之内");
        }
    }
}
