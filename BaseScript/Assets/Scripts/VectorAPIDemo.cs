using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 三维向量Vector的常用API使用
///
/// </summary>

public class VectorAPIDemo : MonoBehaviour
{
    public Transform t1;
    private Vector3 tangent;
    private Vector3 binNormal;
    public Vector3 currentSpeed;

    public AnimationCurve curve;
    private float x;
    public float time = 1;

    // Start is called before the first frame update
    void Start1()
    {
        //属性设置注意,因为this.transform.position返回的是position的副本，无法真正修改position的值，所以会报错。
        //this.transform.position.z = 1;

        //解决方案：将position作为一个整体设置
        Vector3 p = this.transform.position;
        p.z = 2;
        this.transform.position = p;

        //Distance: 为模长。
        //sqrMagnitude: 为(位置1-位置2).模长平方。
        Vector3.Distance(tangent, binNormal);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vect = new Vector3();
        Vector3 vect0 = vect.normalized;
        vect.Normalize();

        //计算垂直向量：在三维坐标系中，一个向量的垂直向量有2条
        //OrthoNormalize(ref Vector3 normal, ref Vector3 tangent);

        //计算t1物体在地面上的投影
        Vector3 norm = t1.position;
        Vector3 project = Vector3.ProjectOnPlane(norm, Vector3.up);

        //计算反射向量：Vector3.Reflect;

        //向量的加，减，点乘，差乘等。
    }

    private void OnGUI()
    {
        if (GUILayout.RepeatButton("Lerp"))
        {
            //Lerp有快到慢，每次前进总长度的10%,无限接近目标点；
            //每次都是起点改变，终点和比例不变。
            this.transform.position = Vector3.Lerp(transform.position, new Vector3(0, 0, 10), 0.1f);
        }

        if (GUILayout.RepeatButton("MoveTowards"))
        {
            //匀速前进,无限接近目标点；
            this.transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 0, 10), 0.1f);
        }

        if (GUILayout.RepeatButton("SmoothDamp"))
        {
            //平滑阻尼
            this.transform.position = Vector3.SmoothDamp(transform.position, new Vector3(0,0,10),ref currentSpeed,2);
        }

        if (GUILayout.RepeatButton("变速运动"))
        {
            x += Time.deltaTime / time;
            Vector3 begin = Vector3.zero;

            //起点，终点不变，比例改变
            transform.position = Vector3.LerpUnclamped(begin, new Vector3(0,0,10),curve.Evaluate(x));
        }


    }
}
