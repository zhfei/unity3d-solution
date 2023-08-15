using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///
/// </summary>

public class RectTransformDemo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //世界坐标
        //当画布渲染模式为overlay时，世界坐标(单位：米)等同于屏幕坐标(单位：像素)
        //this.transform.position

        //当前轴心点 相对于父UI的轴心点位置（单位：像素）
        //this.transform.localPosition

        //RectTransform rtf = GetComponent<RectTransform>();
        RectTransform rtf = this.transform as RectTransform;
        //自身轴心点相对于锚点的位置（编译器中显示的POS）
        //rtf.anchoredPosition3D;
        //获取/设置锚点
        //rtf.anchorMin

        //获取UI的宽度和高度
        //rtf.rect.width;
        //rtf.rect.height;
        //设置UI宽高
        rtf.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,100);

        //当锚点不分开时，数值可以理解为UI宽高
        //实际意义为：物体大小-锚点的间距
        var size = rtf.sizeDelta;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
