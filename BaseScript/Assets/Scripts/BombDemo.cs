using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 炸弹脚本，用于判断炸弹能否炸弹玩家
/// </summary>

public class BombDemo : MonoBehaviour
{

    public Transform playerTF;
    public float playerRadius = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 player2bumbV = this.transform.position - playerTF.position;
        //求半径向量
        Vector3 targetV = player2bumbV.normalized * playerRadius;

        //求连接向量与切角向量的夹角,弧度
        //已知：cosX = b/c, X = arc Cos(b/c)
        float deg = Mathf.Acos(playerRadius / player2bumbV.magnitude)*Mathf.Rad2Deg;

        Vector3 topV = Quaternion.Euler(0, 0, -deg) * targetV;
        Vector3 bottomV = Quaternion.Euler(0, 0, deg) * targetV;

        Vector3 topPosition = this.transform.position + topV;
        Vector3 bottomPosition = this.transform.position + bottomV;
    }
}
