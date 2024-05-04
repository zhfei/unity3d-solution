using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///
/// </summary>

public class HelloCoroutine : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        Debug.Log(1);
        yield return new WaitForSeconds(1);
        Debug.Log(2);
        yield return new WaitForSeconds(1);
        Debug.Log(3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
