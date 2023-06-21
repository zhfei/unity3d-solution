using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 敌人AI，控制器：通过判断状态，执行寻路或攻击逻辑。
///
/// </summary>

[RequireComponent(typeof(EnemyAnimation)), RequireComponent(typeof(EnemyMotor)), RequireComponent(typeof(EnemyStatusInfo)) ]
public class EnemyAI : MonoBehaviour
{

    public enum EnemyState
    {
        PathFinding,
        Atrack,
        Death
    }

    public EnemyState currentState;
    private float nextTime;
    private EnemyAnimation enemyAnimation;
    private EnemyMotor enemyMotor;
    private EnemyStatusInfo enemyStatusInfo;
    public float atrackInternal = 1;

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
                this.enemyAnimation.Play(enemyAnimation.runName);
                if (!this.enemyMotor.Pathfinding())
                {
                    this.currentState = EnemyState.Atrack;
                }

                break;
            case EnemyState.Atrack:


                if (nextTime <= Time.time)
                {
                    //攻击动画
                    this.enemyAnimation.Play(enemyAnimation.atrackName);
                    nextTime += atrackInternal;
                }
                else
                {
                    if (!this.enemyAnimation.IsPlaying(enemyAnimation.atrackName))
                    {
                        //闲置动画
                        this.enemyAnimation.Play(enemyAnimation.idleName);
                    }
                }

                break;
        }
    }
}
