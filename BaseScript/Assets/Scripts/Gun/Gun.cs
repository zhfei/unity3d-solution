using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///
/// </summary>

[RequireComponent(typeof(AudioSource))]
public class Gun : MonoBehaviour
{
    private AudioSource audioSource;
    //音频片段
    public AudioClip clip;

    /// <summary>
    /// 开火
    /// </summary>
    /// <param name="direction">子弹朝向</param>
    public void Firing(Vector3 direction) {
        //玩家枪发射：枪口方向
        //敌人发射：从枪口位置朝向玩家头部位置

        //准备子弹
        //判断弹夹内是否包含子弹

        //创建子弹，播放音频，播放动画
        audioSource.PlayOneShot(clip);
    }


    /// <summary>
    /// 更换弹夹
    /// </summary>
    public void UpdateAmmo() {
        //弹匣容量
        //当前弹匣内的子弹数
        //剩余子弹数
    }

    //虚方法，供子类重写
    protected virtual void Start()
    {
        print("Gun - Start");
    }
}
