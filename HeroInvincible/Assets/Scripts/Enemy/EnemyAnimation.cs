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

    public string StartAnimation;
    public string EndAnimation;
    public string deathName;


    private void Awake()
    {
        this.animate = GetComponentInChildren<Animation>();
        this.animateAction = new AnimationAction(this.animate);
    }

    public void PlayStartAnimation()
    {
        this.animateAction.Play(StartAnimation);
    }

    public void fireAnimation()
    {
        this.animate.Play(EndAnimation);
    }
}
