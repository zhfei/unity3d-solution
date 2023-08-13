using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 精灵资源管理器
/// </summary>

public class ResourcesManager
{
    private static Dictionary<int, Sprite> spriteDict;
    //静态构造函数，调用时机是在类加载的时候被调用
    static ResourcesManager()
    {
        //获取精灵，把精灵设置到Image组件中
        //加载Resources资源，资源必须放在Resources目录下面
        //单个精灵加载
        //Sprite sprite = Resources.Load<Sprite>("2048Atlas");
        //加载精灵图集
        var spriteList = Resources.LoadAll<Sprite>("2048Atlas");
        foreach (var item in spriteList)
        {
            int itemValue = int.Parse(item.name);
            spriteDict.Add(itemValue, item);
        }
    }

    /// <summary>
    /// 读取数字精灵
    /// </summary>
    /// <param name="number">精灵名称对应的数字</param>
    /// <returns>精灵</returns>
    public static Sprite? LoadSprite(int number)
    {
        
        //foreach (var item in spriteList)
        //{
        //    if (item.name == number.ToString())
        //    {
        //        return item;
        //    }
        //}
        //return null;

        return spriteDict[number];
         
    }
}
