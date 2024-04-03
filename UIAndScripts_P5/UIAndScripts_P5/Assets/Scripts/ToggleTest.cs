using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
///
/// </summary>

public class ToggleTest : MonoBehaviour
{
    Toggle toggle;


    // Start is called before the first frame update
    void Start()
    {
        toggle = GetComponent<Toggle>();
        toggle.isOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TestToggleValueChanged(bool isOn)
    {
        Debug.Log("当前参选框状态："+isOn);
    }
}
