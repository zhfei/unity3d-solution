using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    //标准移动输入
    [HideInInspector]
    public Vector3 curInput;

    public float moveSpeed = 5;
    public float hp = 9999;
    [HideInInspector]
    public bool dead = false;

    //引用其他组件
    CharacterController cc;
    PlayerInput playerInput;
    Animator animator;

    //当前道具
    public string curItem;


    //手枪射击
    public Transform weaponSlot; //武器槽位
    public Transform gunfirePos; //定位枪口闪光
    public ParticleSystem prefabGunFire; //枪口火光预制体
    public Transform prefabBullet; //子弹预制体
    [HideInInspector]
    public float nextShootTime; //下次可以开火时间
    public float shootInterval = 0.3f; //射击间隔

    //投掷物
    [HideInInspector]
    public Vector3 throwTarget;
    public Throwing prefabCigar;

    //陷阱
    [HideInInspector]
    public float settingTrapTime; //陷阱设置完毕时刻
    [HideInInspector]
    public float settingTrapStart; //陷阱开始设置时刻
    public float settingTrapInterval;
    public Transform prefabTrap;  //陷阱预制体


    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
        animator.SetBool("Static_b",true);
        curItem = "none";

        //手枪射击
        weaponSlot.gameObject.SetActive(false);
        gunfirePos = weaponSlot.Find("gunfirePos");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //运动
    public void UpdateMove()
    {
        if (dead) return;
        float curSpeed = moveSpeed;
        switch(curItem)
        {
            case "none":
                break;
            case "handgun"://手枪
                {
                    curSpeed = moveSpeed / 2.0f;
                }
                break;
            case "cigar"://诱饵
                {
                    curSpeed = moveSpeed / 2.0f;
                }
                break;
            case "trap"://陷阱
                {
                    curSpeed = 0;
                }
                break;
            case "knife"://匕首
                {
                    curSpeed = moveSpeed / 2.0f;
                }
                break;
        }

        Vector3 v = curInput;
        if(!cc.isGrounded)
        {
            v.y = -0.5f;
        }
        //调用移动方法
        cc.Move(v * curSpeed * Time.deltaTime);
       
    }
    //动作，开火
    public void UpdateAction(Vector3 curInputPos, bool fire)
    {
        if (dead) return;
        switch (curItem)
        {
            case "none":
                break;
            case "handgun"://手枪
                {
                    animator.SetInteger("WeaponType_int",6);
                    if(fire)
                    {
                        Shoot(curInputPos);
                        animator.SetBool("Shoot_b",true);
                    }
                    else
                    {
                        animator.SetBool("Shoot_b",false);
                    }
                }
                break;
            case "cigar"://诱饵
                {
                    throwTarget = curInputPos;
                    if(fire)
                    {
                        curItem = "none";
                        ThrowItem(prefabCigar);
                    }
                }
                break;
            case "trap"://陷阱
                {
                    if(Time.time > settingTrapTime)
                    {
                        curItem = "none";
                        PlaceTrap();
                    }
                }
                break;
            case "knife"://匕首
                {
                    animator.SetInteger("WeaponType_int", 101);
                    if (fire)
                    {
                        //Stab();
                        animator.SetBool("Shoot_b", true);
                    }
                    else
                    {
                        animator.SetBool("Shoot_b", false);
                    }
                }
                break;
        }
    }
    //动画
    public void UpdateAnim(Vector3 curInputPos)
    {
        if(dead)
        {
            animator.SetFloat("Speed_f",0);
            return;
        }
        animator.SetFloat("Speed_f", cc.velocity.magnitude / moveSpeed);
        if(cc.velocity.magnitude > moveSpeed/1.9f)
        {
            PlayFootstepSound();
        }
        weaponSlot.gameObject.SetActive(false);
        if(curItem == "handgun")
        {
            animator.SetLayerWeight(animator.GetLayerIndex("Weapons"),1);


            //显示武器
            weaponSlot.gameObject.SetActive(true);
            weaponSlot.Find("Weapon_Pistol").gameObject.SetActive(true);
            weaponSlot.Find("Weapon_knife").gameObject.SetActive(false);
            //调整枪口朝向
            Vector3 v = new Vector3(curInputPos.x,transform.position.y, curInputPos.z);
            transform.LookAt(v);
        }
        else if (curItem == "knife")
        {
            animator.SetLayerWeight(animator.GetLayerIndex("Weapons"), 1);


            //显示匕首
            weaponSlot.gameObject.SetActive(true);
            weaponSlot.Find("Weapon_Pistol").gameObject.SetActive(false);
            weaponSlot.Find("Weapon_knife").gameObject.SetActive(true);
            //调整匕首朝向
            Vector3 v = new Vector3(curInputPos.x, transform.position.y, curInputPos.z);
            transform.LookAt(v);
        }
        else if (curItem == "trap")
        {
            animator.SetFloat("Speed_f",0);
            animator.SetInteger("Animation_int",9);
        }
        else if (curItem == "charm")
        {
            animator.SetFloat("Speed_f", 0);
            animator.SetInteger("Animation_int", 4);
            transform.Rotate(0,1,0);
        }
        else
        {
            animator.SetInteger("Animation_int", 0);
            animator.SetLayerWeight(animator.GetLayerIndex("Weapons"),0);
            if (curInput.magnitude > 0.01f)
            {
                transform.rotation = Quaternion.LookRotation(curInputPos);
            }
        }



        if (curInput.magnitude>0.01f)
        {
            transform.rotation = Quaternion.LookRotation(curInput);
        }
    }

    public void BeHit(int demage)
    {
        if (dead) return;
        hp -= demage;
        if(hp <= 0)
        {
            hp = 0;
            Die();
        }
    }

    void Die()
    {
        transform.Rotate(90,0,0);
        dead = true;
        //GameMode.Instance.GameOver();
    }

    void PlayFootstepSound()
    {

    }

    //射击
    void Shoot(Vector3 target)
    {
        if (Time.time < nextShootTime) return;
        //1.确定子弹发射向量
        Vector3 dir = target - transform.position;
        dir.y = 0;
        dir = dir.normalized;
        //2.确定子弹发射位置
        Vector3 startPos = new Vector3(transform.position.x,transform.position.y+cc.height/2,transform.position.z);
        startPos += dir * (cc.radius * 2.5f);//发射点往自身坐标前面挪一点
        //3.创建子弹，发射
        Transform bullet = Instantiate(prefabBullet,startPos,Quaternion.identity);
        Bullet b = bullet.GetComponent<Bullet>();
        b.Init("Enemy",dir,0.2f); //设置子弹Tag为Enemy, 用于区分敌我，防止子弹达到自己

        //4.播放音效
        //PlaySound(handgunSound);

        //5.添加枪口特效
        var particle = Instantiate(prefabGunFire,gunfirePos.position,Quaternion.identity);
        var light = gunfirePos.GetComponent<Light>();
        light.enabled = true;
        StartCoroutine(_Flash(light)); //枪口光源闪烁一次

        //开枪时间间隔时间更新
        nextShootTime = Time.time + shootInterval;
    }
    IEnumerator _Flash(Light light)
    {
        if (light == null) yield break;
        light.enabled = true;
        yield return new WaitForSeconds(0.1f);
        light.enabled = false;
    }

    //投掷
    void ThrowItem(Throwing item)
    {
        //发射位置
        Vector3 startPos = new Vector3(transform.position.x, transform.position.y + cc.height / 2, transform.position.z);
        startPos += transform.forward * (2.0f*cc.radius);

        //创建投掷物
        Throwing obj = Instantiate(item,startPos,Quaternion.identity);
        obj.throwTarget = throwTarget;
    }

    //陷阱
    public void BeginTrap()
    {
        if(settingTrapStart + settingTrapInterval > Time.time)
        {
            //陷阱过期
            curItem = "none";
            return;
        }
        settingTrapTime = Time.time + 2; //2s后陷阱生效
    }
    void PlaceTrap()
    {
        Instantiate(prefabTrap,transform.position,Quaternion.identity);
        settingTrapStart = Time.time;
    }

}
