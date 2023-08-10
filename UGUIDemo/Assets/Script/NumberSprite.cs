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
    }
}
