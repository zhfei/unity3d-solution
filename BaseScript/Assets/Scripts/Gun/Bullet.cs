using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 子弹，定义子弹公有的行为
/// </summary>

public class Bullet : MonoBehaviour
{
    protected RaycastHit hit;

    //计算目标点
    //移动
    //到达目标点：销毁，创建相关特效


    //创建相关特效
    //根据目标点物体的标签hit.collider.tag
    private void GennerateContactEffect()
    {
        //通过代码读取资源
        //资源必须放在Resources目录下，ContactEffects/xxx
        GameObject prefabGO = Resources.Load<GameObject>("资源名称");

        //创建资源
        Instantiate(prefabGO);
    }
}
