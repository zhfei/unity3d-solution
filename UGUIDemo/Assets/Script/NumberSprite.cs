using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// 添加到方格中，方格的行为
/// </summary>

public class NumberSprite : MonoBehaviour
{
    private Image img;

    // Start is called before the first frame update
    void Start()
    {
        img = this.GetComponent<Image>();
    }

    // Update is called once per frame
    public void SetImage(int number)
    {
        //获取精灵，把精灵设置到Image组件中
        //加载Resources资源，资源必须放在Resources目录下面
        //单个精灵加载
        //Sprite sprite = Resources.Load<Sprite>("2048Atlas");
        //加载精灵图集
        Sprite[] spriteList = Resources.LoadAll<Sprite>("2048Atlas");
        foreach (var item in spriteList)
        {
            if (item.name == number.ToString())
            {
                img.sprite = item;
            }
        }
    }

    //移动，合并，生成效果
}
