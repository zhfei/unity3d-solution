using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///敌人行走的路线：包括属性为路点坐标数组Vector3[] Points, 是否可用IsUseable
/// 
/// </summary>

public class WayLine 
{
    //所有的路点
    public Vector3[] Pointers { get; set; }

    //路线是否可用
    public bool IsUseable { get; set; }


    public WayLine(int num)
    {
        this.Pointers = new Vector3[num];
        this.IsUseable = true;
    }

}
