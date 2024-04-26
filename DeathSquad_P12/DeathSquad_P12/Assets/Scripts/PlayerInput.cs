using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{

    PlayerCharacter player;
    LineRenderer throwLine;

    [HideInInspector]
    public Vector3 curGroundPoint;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerCharacter>();
        throwLine = GetComponentInChildren<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 input;
        input = new Vector3(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical"));
        //转成标准输入
        if(input.magnitude > 1.0f)
        {
            input = input.normalized;
        }
        //1.传递标准输入到角色控制器
        player.curInput = input;

        bool fire = false;
        bool touch = TouchGroundPos(); //保存鼠标指向陆地的点

        player.UpdateMove(); //2.移动
        player.UpdateAction(curGroundPoint,fire); //3.开火
        player.UpdateAnim(curGroundPoint); //4.动画
    }

    //记录鼠标指针当前指向的点
    bool TouchGroundPos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        //射线仅检测到Ground层的碰撞
        if (!Physics.Raycast(ray,out hit,1000,LayerMask.GetMask("Ground")))
        {
            return false;
        }

        curGroundPoint = hit.point;
        return true;
    }
}
