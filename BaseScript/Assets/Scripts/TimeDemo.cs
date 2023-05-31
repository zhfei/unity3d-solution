using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
///
/// </summary>

public class TimeDemo : MonoBehaviour
{
    public int second = 120;
    float nextTime = 0;
    public TextMeshProUGUI clock;
    public string clockStr;

    // Start is called before the first frame update
    void Start()
    {
        Component[] list = GetComponents<Component>();
        foreach (var item in list)
        {
            print(item.name);
        }
        clock = GetComponent<TextMeshProUGUI>();
        InvokeRepeating("Timer3", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //立即式1s执行，方法调用会直接执行，然后再延迟1s后再执行。适用场景：按住开关连续发射子弹
    private void Timer1()
    {
        if (Time.time >= nextTime)
        {
            second--;
            nextTime = Time.time + 1;
            clockStr = string.Format("{0:d2}:{1:d2}", second / 60, second % 60);
            clock.text = clockStr;
            if (second <= 10) {clock.color = Color.red;}
            if (second <= 0) { clock.enabled = false; }
        }
    }

    //累加式1s执行，会先延迟1s后再执行，适用场景：沿多个路点移动，到达一点停一会再进行移动。
    public float totalTime = 0;
    private void Timer2()
    {
        totalTime += Time.deltaTime;
        if (totalTime >= 1)
        {
            totalTime = 0;
            second--;
            clockStr = string.Format("{0:d2}:{1:d2}", second / 60, second % 60);
            clock.text = clockStr;
            if (second <= 10) { clock.color = Color.red; }
            if (second <= 0) { clock.enabled = false; }
        }
    }

    //简单的间隔1s执行一次
    private void Timer3()
    {
        second--;
        clockStr = string.Format("{0:d2}:{1:d2}", second / 60, second % 60);
        clock.text = clockStr;
        if (second <= 0)
        {
            CancelInvoke();
        }
    }

}
