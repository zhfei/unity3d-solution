using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///
/// </summary>

public class Bullet : MonoBehaviour
{
    //对象池的引用
    public SimplePool pool;

    // Update is called once per frame
    void Update()
    {
        //子弹移动向量
        Vector3 dir = transform.position - Vector3.zero;

        transform.position += dir.normalized * 5.0f * Time.deltaTime;

        if(Vector3.Distance(transform.position,Vector3.zero) >= 17)
        {
            if(pool)
            {
                //有对象池，则对象池回收
                pool.Destroy(gameObject);
            }
            else
            {
                //无对象池，直接销毁
                Destroy(gameObject);
            }
        }



    }
}
