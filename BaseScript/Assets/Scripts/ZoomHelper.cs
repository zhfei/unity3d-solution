using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///
/// </summary>

public class ZoomHelper : MonoBehaviour
{
    public bool isFar = false;
    public int[] section;
    public int currentSectionIndex;
    private Camera myCamera = null;

    // Start is called before the first frame update
    void Start()
    {
        myCamera = this.GetComponent<Camera>();

    }

    // Update is called once per frame
    void Update()
    {
        //SimpleZoom();
        //GradientZoom();
        SectionGradientZoom();

    }





    //1.简单放大镜
    private void SimpleZoom()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (isFar)
            {
                myCamera.fieldOfView = 80;
            }
            else
            {
                myCamera.fieldOfView = 20;
            }
            isFar = !isFar;
        }
    }

    //2.渐变放大镜
    private void GradientZoom()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (isFar)
            {
                if (Mathf.Abs(myCamera.fieldOfView - 20) <= 0.1)
                {
                    isFar = false;
                }
            }
            else
            {
                isFar = true;
            }
        }

        if (isFar)
        {
            myCamera.fieldOfView = Mathf.Lerp(myCamera.fieldOfView, 20, 0.1f);
        }
        else
        {
            myCamera.fieldOfView = 80;
        }
    }

    //3.分组渐变放大镜
    private void SectionGradientZoom()
    {
        if (Input.GetMouseButtonDown(1))
        {
            currentSectionIndex = (currentSectionIndex + 1) % section.Length;

        }

        if (myCamera.fieldOfView != section[currentSectionIndex])
        {
            myCamera.fieldOfView = Mathf.Lerp(myCamera.fieldOfView, section[currentSectionIndex], 0.1f);

            if (Mathf.Abs(myCamera.fieldOfView - section[currentSectionIndex]) <= 0.1)
            {
                myCamera.fieldOfView = section[currentSectionIndex];
            }
        }
    }
}
