using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 动画行为类：是对动画组件的一层封装，在业务层调用，动画组件改动不影响业务层的代码。
///
/// </summary>

public class AnimationAction 
{
    private Animation anim;

    public AnimationAction(Animation anim)
    {
        this.anim = anim;
    }

    public void Play(string animationName)
    {
        this.anim.CrossFade(animationName);
    }

    public bool IsPlay(string animationName)
    {
        return this.anim.isPlaying;
    }

}
