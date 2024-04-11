using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///
/// </summary>

public class CreateParticle : MonoBehaviour
{
    public GameObject prefabParticle;

    // Start is called before the first frame update
    void Start()
    {
        ////1.调整粒子参数
        ////注意：粒子系统参数修改要在播放前，播放后无法修改。
        //GameObject particle = Instantiate(prefabParticle);
        //ParticleSystem ps = particle.GetComponent<ParticleSystem>();

        //ParticleSystem.MainModule main = ps.main;
        //main.duration = 1; //粒子播放持续时间
        //main.startSpeed = 40; //粒子初始速度
        //main.stopAction = ParticleSystemStopAction.Destroy;

        //ParticleSystem.EmissionModule emission = ps.emission;
        //emission.rateOverTime = 1000;//加大发射频率

        //ps.Play();


        ////2.调整动画参数
        //Animator animator = gameObject.GetComponent<Animator>();
        //animator.speed = 2; //调整动画播放速度

    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            GameObject particle = Instantiate(prefabParticle);
            ParticleSystem ps = particle.GetComponent<ParticleSystem>();

            //1.如果ParticleSystem组件中没有勾选Play On Awake, 那么可以手动调用开启粒子效果。
            //ps.Play();

            //2.如果ParticleSystem组件中Stop Action中可以选择Destroy，执行结束后自动销毁
            Destroy(particle, 2.0f);
        }
    }

    //2.如果ParticleSystem组件中Stop Action选择的模式为Callback， 那么粒子执行结束后，会在脚本中执行回调函数OnParticleSystemStopped()
    private void OnParticleSystemStopped()
    {
        Debug.Log("粒子效果执行结束");
    }
}
