using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//武器的作用：产生子弹，根据不同的武器类型，按照对应的策略产生子弹
public class Weapon : MonoBehaviour
{

    public GameObject prefabBullet; //子弹预制体

    //不同武器的开火间隔
    public float pistolFireCD = 0.2f; //手枪
    public float shotgunFireCD = 0.5f; //散弹枪
    public float rifleCD = 0.1f; //步枪
    public int currentGun { get; private set; } //当前使用的武器 0手枪，1散弹枪，2自动步枪

    float lastFireTime; //上次开火时间


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //开火函数，由不同的角色脚本自己调用
    //keyDown:表示下一帧按下开火键， keyPressed表示正在持续按下开火键。 这样可以区分不同武器的发射子弹不同的策略
    public void Fire(bool keyDown, bool keyPressed)
    {
        switch(currentGun)
        {
            case 0:
                if (keyDown)
                {
                    pistolFire();
                }
                break;

            case 1:
                if (keyDown)
                {
                    shotgunFire();
                }
                break;
            case 2:
                if (keyPressed)
                {
                    rifleFire();
                }
                break;
        }
    }
    //更换武器
    public int Change()
    {
        currentGun += 1;
        if (currentGun == 3)
        {
            currentGun = 0;
        }
        return currentGun;
    }



    //不同类型枪的子弹发射动作
    void pistolFire()
    {
        if (lastFireTime + pistolFireCD > Time.time)
        {
            //开火间隔时间没到，不处理
            return;
        }

        lastFireTime = Time.time;
        GameObject bullet = Instantiate(prefabBullet, null);
        bullet.transform.position = transform.position + transform.forward * 1.0f;
        bullet.transform.forward = transform.forward;
    }
    void rifleFire()
    {
        if (lastFireTime + rifleCD > Time.time)
        {
            //开火间隔时间没到，不处理
            return;
        }

        lastFireTime = Time.time;
        GameObject bullet = Instantiate(prefabBullet, null);
        bullet.transform.position = transform.position + transform.forward * 1.0f;
        bullet.transform.forward = transform.forward;
    }
    void shotgunFire()
    {
        if (lastFireTime + shotgunFireCD > Time.time)
        {
            //开火间隔时间没到，不处理
            return;
        }

        lastFireTime = Time.time;

        //创建5颗子弹，分别相隔10度，分布于前方扇形区域
        for (int i = -2; i <= 2; i++)
        {
            GameObject bullet = Instantiate(prefabBullet, null);
            //四元数右乘：表示右侧三维坐标按四元数做旋转
            Vector3 dir = Quaternion.Euler(0,i*10,0)*transform.forward;
            bullet.transform.forward = dir;
            bullet.transform.position = transform.position + dir * 1.0f;

            //散弹枪射击距离比较短，需要给子弹设置生命周期
            //Bullet b = bullet.AddComponent<Bullet>();
            //b.lifeTime = 3.0f;
        }
    }
}
