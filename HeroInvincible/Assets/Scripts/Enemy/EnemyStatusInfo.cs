using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 敌人状态信息：保存敌人血量，提供受伤，死亡的功能
///
/// </summary>

public class EnemyStatusInfo : MonoBehaviour
{

    public float deathDelay = 5;
    public float currentHP;
    //最大血量
    public float maxHP;
    //敌人生成器
    public EnemySpawn spawn;
    
    //受到攻击，减血
    public void Damage(float amount)
    {
        if (currentHP <= 0) return;

        currentHP -= amount;

        if (currentHP <= 0)
        {
            Death();
        }
    }

    //死亡
    public void Death()
    {
        //死亡动画
        var anim = this.GetComponent<EnemyAnimation>();
        anim.Play(anim.deathName);

        //将当前游戏对象上的AI组件中的敌人状态设置成死亡
        GetComponent<EnemyAI>().currentState = EnemyAI.EnemyState.Death;

        //当前敌人游戏对象所使用的路线重新设置为可用
        GetComponent<EnemyMotor>().wayline.IsUseable = true;

        //销毁当前游戏体
        Destroy(this.gameObject, deathDelay);

        //再生成一个敌人
        spawn.GenerateEnemy();

    }
}
