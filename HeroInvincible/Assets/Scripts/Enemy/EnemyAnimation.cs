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

    public string deathName;
    public string atrackName;
    public string runName;


    private void Awake()
    {
        this.animate = GetComponentInChildren<Animation>();
        this.animateAction = new AnimationAction(this.animate);
    }

    public void Play(string name)
    {
        this.animateAction.Play(name);
    }
}
