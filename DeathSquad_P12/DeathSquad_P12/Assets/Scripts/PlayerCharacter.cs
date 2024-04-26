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

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
        animator.SetBool("Static_b",true);
        curItem = "none";
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
    public void UpdateAction(Vector3 currentGroundPoint, bool isFire)
    {

    }
    //动画
    public void UpdateAnim(Vector3 currentGroundPoint)
    {
        if(dead)
        {
            animator.SetFloat("Speed_f",0);
            return;
        }
        animator.SetFloat("Speed_f", cc.velocity.magnitude / moveSpeed);

        if(curInput.magnitude>0.01f)
        {
            transform.rotation = Quaternion.LookRotation(curInput);
        }
    }
}
