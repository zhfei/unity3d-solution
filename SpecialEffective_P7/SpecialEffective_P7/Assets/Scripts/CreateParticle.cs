using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///
/// </summary>

public class CreateParticle : MonoBehaviour
{
    public GameObject prefabParticle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
           GameObject p = Instantiate(prefabParticle);
            Destroy(p,2.0f);
        }
    }
}
