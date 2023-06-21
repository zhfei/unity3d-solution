using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 敌人动画：保存各种动画名称，提供播放动画的功能
///
/// </summary>

public class EnemyAnimation : MonoBehaviour
{

    private Animation animate;
    private AnimationAction animateAction;

    //死亡动画
    public string deathName = "death";
    //攻击动画
    public string atrackName = "shooting";
    //跑步动画
    public string runName = "run";
    //闲置动画
    public string idleName = "idleWgun";


    private void Awake()
    {
        //从子gameObject查找组件
        this.animate = GetComponentInChildren<Animation>();
        this.animateAction = new AnimationAction(this.animate);
    }

    public void Play(string name)
    {
        this.animateAction.Play(name);
    }

    public bool IsPlaying(string name)
    {
        return this.animateAction.IsPlay(name);
    }
}
