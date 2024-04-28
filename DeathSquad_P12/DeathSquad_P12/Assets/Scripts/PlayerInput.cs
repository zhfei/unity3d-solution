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

        //抛物线指示器，只有在投掷物时才需要划曲线
        if(player.curItem == "cigar")
        {
            DrawThrowLine(curGroundPoint);
        }
        else
        {
            HideThrowLine();
        }
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

    public void OnSelectItem(string item)
    {
        if (player.dead) return;
        player.curItem = item;
        Debug.Log(item);

        switch(item)
        {
            case "handgun":
                {
                    //手枪
                }
                break;
            case "cigar":
                {
                    //投掷物
                }
                break;
            case "trap":
                {
                    //陷阱
                    player.BeginTrap();
                }
                break;
            case "knife":
                {
                    //匕首
                }
                break;
            case "colse":
                {
                    //关闭
                    GameObject canvas = GameObject.Find("Canvas");
                    canvas.SetActive(false); 
                }
                break;
        }
    }


    //抛物线指示器
    void HideThrowLine()
    {
        throwLine.positionCount = 0;
    }

    public void DrawThrowLine(Vector3 _target)
    {
        //显示抛物线
        Vector3 target = transform.InverseTransformVector(_target);
        float d = target.magnitude;
        float h = d / 3;

        //用20条直线模拟曲线，算法和抛物线飞行类似
        int T = 20;
        float T_half = T / 2.0f;
        float a = 2 * h / (T_half * T_half);
        float vx = target.x / T;
        float vz = target.z / T;

        List<Vector3> points = new List<Vector3>();
        //列表保存的点都是局部坐标系的点
        points.Add(Vector3.zero);

        Vector3 p = Vector3.zero;
        float vy = T_half * a;
        for(int i = 0; i<T;i++)
        {
            p.x += vx;
            p.z += vz;
            p.y += vy - a / 2.0f;
            vy -= a;
            points.Add(p);
        }

        //将points列表赋值给Line Render组件，就会显示曲线了
        throwLine.positionCount = points.Count;
        throwLine.SetPositions(points.ToArray());
    }
}
