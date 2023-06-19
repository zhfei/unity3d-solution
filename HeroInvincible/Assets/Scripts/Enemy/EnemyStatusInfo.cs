using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 敌人状态信息：保存敌人血量，提供受伤，死亡的功能
///
/// </summary>

public class EnemyStatusInfo : MonoBehaviour
{

    public float HP = 100;

    public float deathDelay = 5;
    public float currentHP;
    public float maxHP;
    

    public void Damage(float amount)
    {
        if (currentHP <= 0)
        {
            return;
        }

        currentHP -= amount;

        if (currentHP <= 0)
        {
            Death();
        }
    }

    //死亡
    public void Death()
    {
        //销毁当前游戏体
        Destroy(this.gameObject, deathDelay);


    }
}
