using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///
/// </summary>

public class AnimationDemo : MonoBehaviour
{
    private Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();

        anim.Play("Animation1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
