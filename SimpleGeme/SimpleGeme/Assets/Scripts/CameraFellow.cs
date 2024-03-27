using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFellow : MonoBehaviour
{
   //相机要跟随的目标对象
    public Transform targetFollew;
    //相机相距目标对象之间的向量差
    Vector3 offset;

    private void Start()
    {
        offset = transform.position - targetFollew.position;
    }

    private void LateUpdate()
    {
        transform.position = offset + targetFollew.position;
    }
}
