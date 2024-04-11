using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///
/// </summary>

public class TestTrail : MonoBehaviour
{
    TrailRenderer trail;
    public Material material1;
    public Material material2;

    // Start is called before the first frame update
    void Start()
    {
        trail = GetComponent<TrailRenderer>();
        trail.material = material1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            trail.sharedMaterial = material2;
            trail.startColor = Color.red;
            trail.endColor = Color.red;
        }
        else
        {
            trail.sharedMaterial = material1;
            trail.startColor = Color.blue;
            trail.endColor = Color.blue;
        }
    }
}
