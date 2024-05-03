using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///
/// </summary>

public class Spawner : MonoBehaviour
{
    //是否使用对象池
    public bool usePool = true;
    //预制体
    public GameObject prefab;

    SimplePool pool;

    // Start is called before the first frame update
    void Start()
    {
        pool = GameObject.Find("Pool").GetComponent<SimplePool>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            for(int i = 0; i<1000;i++)
            {
                GameObject go;
                if(usePool)
                {
                    //通过对象池创建
                    go = pool.Create();
                    //对Bullt脚本设置pool属性
                    go.GetComponent<Bullet>().pool = pool;
                }
                else
                {
                    go = Instantiate(prefab);
                    go.GetComponent<Bullet>().pool = null;
                }
                go.transform.position = Random.onUnitSphere * 5;
                go.transform.parent = transform;
            }
        }
    }
}
