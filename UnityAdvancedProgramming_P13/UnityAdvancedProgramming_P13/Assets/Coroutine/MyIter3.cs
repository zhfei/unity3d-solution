using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///
/// </summary>

public class MyIter3 : MonoBehaviour
{

    IEnumerator<int> HelloWorld()
    {
        float helloTime = 0;

        transform.position = new Vector3(1,0,0);
        helloTime = Time.time + 1;
        while(Time.time < helloTime)
        {
            yield return 1;
        }

        transform.position = new Vector3(2, 0, 0);
        helloTime = Time.time + 2;
        while (Time.time < helloTime)
        {
            yield return 2;
        }

        transform.position = new Vector3(3, 0, 0);
        helloTime = Time.time + 3;
        while (Time.time < helloTime)
        {
            yield return 3;
        }
    }

    IEnumerator<int> e;
    // Start is called before the first frame update
    void Start()
    {
        e = HelloWorld();
    }

    // Update is called once per frame
    void Update()
    {
        if(e != null)
        {
            //协程结束了
            if(!e.MoveNext())
            {
                e = null;
                return;
            }
            else
            {
                Debug.Log("MyIter3:" + e.Current);
            }
        }
    }
}
