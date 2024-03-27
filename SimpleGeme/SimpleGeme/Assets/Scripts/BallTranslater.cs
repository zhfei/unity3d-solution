using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTranslater : MonoBehaviour
{
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //1.输入
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        Debug.Log("当前输入，垂直方向："+v+"水平方向："+h);

        //2.移动
        //this.transform.Translate(h * speed * Time.deltaTime, v * speed * Time.deltaTime, 0);
        this.transform.position += new Vector3(h * speed * Time.deltaTime, 0, v * speed * Time.deltaTime);
    }
}
