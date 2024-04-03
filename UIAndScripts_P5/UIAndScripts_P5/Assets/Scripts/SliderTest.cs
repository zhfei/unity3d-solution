using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
///
/// </summary>

public class SliderTest : MonoBehaviour
{

    public Image image;
    Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.minValue = 0;
        slider.maxValue = 1;
        slider.value = 0.5f;

        //设置图片类型为Filled, 360填充
        image.type = Image.Type.Filled;
        image.fillMethod = Image.FillMethod.Radial360;
    }

    // Update is called once per frame
    void Update()
    {
        //使用滑动条的值更新图片的填充大小
        image.fillAmount = slider.value;
    }
}
