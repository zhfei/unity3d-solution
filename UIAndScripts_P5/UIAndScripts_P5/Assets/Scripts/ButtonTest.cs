using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


/// <summary>
///
/// </summary>

public class ButtonTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BtnClick(int index)
    {
        Debug.Log("按钮被点击了："+index);
    }

    public void BtnCustomEvent(BaseEventData param)
    {
        Debug.Log("自定义点击事件：" + param);
    }
}
