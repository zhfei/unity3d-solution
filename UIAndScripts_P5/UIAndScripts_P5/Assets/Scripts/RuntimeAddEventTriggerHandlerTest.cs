using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


/// <summary>
///
/// </summary>

public class RuntimeAddEventTriggerHandlerTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //1.给第一个Button1添加Event Trigger组件
        EventTrigger eventTrigger = transform.GetChild(0).gameObject.AddComponent<EventTrigger>();
        eventTrigger.triggers = new List<EventTrigger.Entry>();

        EventTrigger.Entry entry1 = new EventTrigger.Entry();//添加鼠标点击事件监听
        entry1.eventID = EventTriggerType.PointerDown;
        entry1.callback.AddListener(Btn1Click);
        //把监听对象放到触发器列表中
        eventTrigger.triggers.Add(entry1);


        //2.给第二个Button2添加一些事件监听
        EventTrigger eventTrigger1 = transform.GetChild(1).gameObject.AddComponent<EventTrigger>();
        eventTrigger1.triggers = new List<EventTrigger.Entry>();

        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry.callback.AddListener(Btn1Click);

        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry2.eventID = EventTriggerType.PointerExit;
        entry2.callback.AddListener(Btn1Click);

        eventTrigger1.triggers.Add(entry);
        eventTrigger1.triggers.Add(entry2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Btn1Click(BaseEventData eventData)
    {
        //所有的事件回调都绑定到了这个方法上，需要进行区分
        PointerEventData pointerEventData = eventData as PointerEventData;
        if(pointerEventData == null)
        {
            Debug.Log("转换成PointerEventData类型失败"+pointerEventData);
            return;
        }

        Debug.Log("事件坐标："+pointerEventData.position);

        //获取事件对应的游戏物体
        GameObject obj = pointerEventData.selectedObject;
        if(obj == null)
        {
            Debug.Log("事件对应的物体无法获取");
            return;
        }
        else
        {
            Debug.Log("事件对应的物体:"+obj.name);
        }
    }
}
