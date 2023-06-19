using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 敌人AI，控制器：通过判断状态，执行寻路或攻击逻辑。
///
/// </summary>

public class EnemyAI : MonoBehaviour
{

    enum EnemyState
    {
        PathFinding,
        Atrack
    }

    private EnemyState currentState;
    private float nextTime;
    private EnemyAnimation enemyAnimation;
    private EnemyMotor enemyMotor;
    private EnemyStatusInfo enemyStatusInfo;

    private void Awake()
    {
        this.currentState = EnemyState.PathFinding;
        this.enemyAnimation = GetComponent<EnemyAnimation>();
        this.enemyMotor = GetComponent<EnemyMotor>();
        this.enemyStatusInfo = GetComponent<EnemyStatusInfo>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (this.currentState)
        {
            case EnemyState.PathFinding:
                if (!this.enemyMotor.Pathfinding())
                {
                    this.currentState = EnemyState.Atrack;
                }
                this.enemyAnimation.PlayStartAnimation();


                break;
            case EnemyState.Atrack:

                if (nextTime <= Time.time)
                {
                    this.enemyAnimation.fireAnimation();
                    nextTime += 1;
                }

                

                break;
        }
    }
}
