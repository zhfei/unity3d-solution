using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomEffect : MonoBehaviour
{

    List<Transform> objs = new List<Transform>();
    const int N = 15;


    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i< N; i++)
        {
            GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            obj.transform.parent = transform;
            obj.transform.localPosition = new Vector3(Mathf.Cos(i*2*Mathf.PI/N), 0, Mathf.Sin(i*2*Mathf.PI/N));
            obj.transform.forward = obj.transform.position - transform.position;
            objs.Add(obj.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Transform transf in objs)
        {
            transf.Translate(0,0,10*Time.deltaTime);
            transf.localScale *= 0.9f;
            if(transf.localScale.x <= 0.05f)
            {
                Destroy(gameObject);
            }
        }
    }
}
