using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 敌人马达：用于控制敌人的前进，旋转，寻路功能
/// 与敌人的行走，移动有关。
///
/// </summary>

public class EnemyMotor : MonoBehaviour
{
    // 敌人当前运动的路线
    public WayLine wayline = new WayLine(3);
    public Transform[] ePointers = null;

    // 敌人运行的速度
    public float moveSpeed = 5;

    /// <summary>
    /// 向前移动
    /// </summary>
    public void MoveForward()
    {
        this.transform.Translate(0, 0, Time.deltaTime * moveSpeed);
    }

    /// <summary>
    /// 面向目标点旋转,旋转到目标点
    /// </summary>
    /// <param name="targetPoint"></param>
    public void LookRotation(Vector3 targetPoint)
    {
        transform.LookAt(targetPoint);
    }

    private int currentIndex;
    /// <summary>
    /// 寻路，判断当前位置是否为终点
    /// </summary>
    /// <returns></returns>
    public bool Pathfinding()
    {
        if (currentIndex >= ePointers.Length) return false;

        LookRotation(ePointers[currentIndex].position);
        MoveForward();

        if (Vector3.Distance(transform.position, ePointers[currentIndex].position) <= 0.1) 
        {
            currentIndex++;
        }

        // return true表示可以继续移动，继续寻路
        return true;
    }

    public bool Pathfinding2()
    {
        if (currentIndex >= wayline.Pointers.Length) return false;

        LookRotation(wayline.Pointers[currentIndex]);
        MoveForward();

        if (Vector3.Distance(transform.position, wayline.Pointers[currentIndex]) <= 0.1)
        {
            currentIndex++;
        }

        // return true表示可以继续移动，继续寻路
        return true;
    }

    private void Update()
    {
        Pathfinding2();
    }
}
