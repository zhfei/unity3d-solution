using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Console2048;
using System;


/// <summary>
///
/// </summary>

public class GameController : MonoBehaviour
{
    private GameCore core;
    //精灵脚本二维数组
    private NumberSprite[,] spriteActionArray;
    // Start is called before the first frame update
    void Start()
    {
        core = new GameCore();
        spriteActionArray = new NumberSprite[4,4];

        Init();

        GenerateNewNumber();
        GenerateNewNumber();
    }

    // Update is called once per frame
    void Init()
    {
        for (int row = 0; row < 4; row++)
        {
            for (int col = 0; col < 4; col++)
            {
                CreateSprite(row,col);
            }
        }
    }

    void CreateSprite(int row, int col)
    {
        //
        /*
         * 创建UI的方法：
         * 1.创建预制件,通过Instantiate()加载
         * 2.通过代码创建
         */

        GameObject go = new GameObject(row.ToString()+col.ToString());
        go.AddComponent<Image>();
        NumberSprite numSprint = go.AddComponent<NumberSprite>();
        //将精灵保存到二维数组
        spriteActionArray[row, col] = numSprint;
        numSprint.SetImage(0);
        go.transform.SetParent(this.transform,false);
    }

    private void GenerateNewNumber()
    {
        /*
         * Location? loc;
            int? number;
            获取值的方式为 loc.value;
         */


        Location loc;
        int number;

        //out: 输出参数
        core.GenerateNumber(out loc, out number);
        spriteActionArray[loc.RIndex, loc.CIndex].SetImage(number);
    }

   
}
