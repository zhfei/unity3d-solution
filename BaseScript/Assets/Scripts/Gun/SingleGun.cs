using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 单发枪
/// </summary>

public class SingleGun : Gun
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //点击鼠标左键，发射
            //base.Firing(枪口位置);
        }
    }

    //重写父类的方法
    protected override void Start()
    {
        base.Start();
    }
}
