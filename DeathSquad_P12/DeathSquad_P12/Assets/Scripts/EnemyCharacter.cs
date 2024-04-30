using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum AIState
{
    Patrol,//巡逻
    Attack,//攻击
    Chase,//追击
    Die,//死亡
    Freeze//被冻结（踩中了陷阱）
}

public class EnemyCharacter : MonoBehaviour
{
    //角色属性
    float walkSpeed = 2.5f;
    float runSpeed = 8f;
    float hp = 3;

    //距离设置：视野距离，射击距离，追击距离
    public float maxScanDist = 16f;
    public float maxAttackDist = 13f;
    public float maxChaseDist = 16f;
    //视觉感知
    Transform viewIndicator;
    MeshFilter viewFilter;
    MeshRenderer viewRender;

    float freezeTime; //被陷阱冻结时间

    //引用组件
    Animator animator;
    NavMeshAgent agent;
    CapsuleCollider coll;

    //武器射击
    Transform attackTarget;
    public Transform prefabBullet;
    public Transform weaponSlot;
    float nextShootTime = 0;
    public float shootInterval = 0.1f;

    //巡逻
    public List<Transform> patrolPoints; //所有要巡逻的点
    int patrolIndex;//当前巡逻点序号
    AIState _state;
    AIState state
    {
        get { return _state; }
        set
        {
            _state = state;
            Debug.Log("游戏AI状态机更新："+state.ToString());
        }
    }

   

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        coll = GetComponent<CapsuleCollider>();
        //动画状态机
        animator.SetBool("Static_b",true);
        animator.SetInteger("WeaponType_int",6);

        agent = GetComponent<NavMeshAgent>();
        if(agent.avoidancePriority == 0)
        {   //设置避让优先级，敌人集体寻路时，互相避让
            agent.avoidancePriority = Random.Range(30,61);
        }

        patrolIndex = 0;
        agent.isStopped = true;
        // AI状态机始终为巡逻状态
        state = AIState.Patrol;

        //敌人视野范围
        viewIndicator = transform.Find("ViewIndicator");
        viewFilter = viewIndicator.GetComponent<MeshFilter>();
        viewRender = viewIndicator.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAI();
        UpdateAnim();
    }

    void UpdateAI()
    {
        switch(state)
        {
            case AIState.Patrol:
                {
                    agent.speed = walkSpeed;
                    UpdatePatrol();
                    Transform target = UpdateScan();
                    if (target != null)
                    {
                        state = AIState.Chase;
                        attackTarget = target;
                    }
                }
                break;
            case AIState.Chase:
                {
                    agent.speed = runSpeed;
                    UpdateChase();
                }
                break;
            case AIState.Attack:
                {
                    UpdateAttack();
                }
                break;
            case AIState.Die:
                break;
            case AIState.Freeze:
                {
                    if(Time.time > freezeTime)
                    {
                        state = AIState.Patrol;
                    }
                }
                break;
        }
    }

    void UpdateAnim()
    {
        if(state == AIState.Die)
        {
            animator.SetFloat("Speed_f",0);
            return;
        }
        if(state == AIState.Chase || state == AIState.Attack)
        {
            animator.SetBool("Shoot_b",true);
            weaponSlot.localRotation = Quaternion.Euler(0,0,50);
        }
        else
        {
            animator.SetBool("Shoot_b", false);
            weaponSlot.localRotation = Quaternion.Euler(0, 0, 0);
        }

        float speed = agent.velocity.magnitude / runSpeed;
        animator.SetFloat("Speed_f",speed);
    }
    //巡逻
    void UpdatePatrol()
    {
        if (patrolPoints.Count == 0) return;
        
        if(agent.isStopped)
        {
            agent.destination = patrolPoints[patrolIndex].position;
            agent.isStopped = false;
            return;
        }
        //到达当前目标点
        if(agent.remainingDistance <= agent.stoppingDistance)
        {
            if(patrolPoints.Count == 1)
            {
                //在前2个参数直接求差值，比例点为0.3位置
                transform.rotation = Quaternion.Slerp(transform.rotation,patrolPoints[0].rotation,0.3f);
                return;
            }
            patrolIndex++;
            patrolIndex = patrolIndex % patrolPoints.Count;
            agent.SetDestination(patrolPoints[patrolIndex].position);
        }
    }
    //视觉感知扫描
    Transform UpdateScan()
    {
        List<Vector3> points = new List<Vector3>();

        System.Func<bool> _DrawRange = () =>
        {
            List<int> tris = new List<int>();
            for (int i = 2; i < points.Count; i++)
            {
                tris.Add(0);
                tris.Add(i - 1);
                tris.Add(i);
            }

            Mesh mesh = new Mesh();
            mesh.vertices = points.ToArray();
            mesh.triangles = tris.ToArray();
            mesh.RecalculateBounds();
            mesh.RecalculateNormals();
            mesh.RecalculateTangents();

            viewFilter.mesh = mesh;
            return true;
        };

        Vector3 offset = new Vector3(0,1,0);
        points.Add(offset);

        for(int d = -60; d<60; d+=4)
        {
            Vector3 v = Quaternion.Euler(0, d, 0) * transform.forward;
            Ray ray = new Ray(transform.position + offset, v);
            RaycastHit hit;
            if(!Physics.Raycast(ray, out hit, maxScanDist))
            {
                Vector3 localV = transform.InverseTransformVector(v);
                points.Add(offset + localV * maxScanDist);
                Debug.DrawLine(transform.position,transform.position+v*maxScanDist,Color.red);
            }
            else
            {
                Vector3 local = transform.InverseTransformVector(hit.point);
                points.Add(offset+local);
                Debug.DrawLine(transform.position,hit.point,Color.red);
            }
        }
        //绘制视线范围
        _DrawRange();

        //检测视线内物体
        //球形覆盖检测
        Collider[] colliders = Physics.OverlapSphere(transform.position, maxScanDist);
        List<Transform> targets = new List<Transform>();
        foreach(var c in colliders)
        {
            Vector3 to = c.gameObject.transform.position - transform.position;
            if (Vector3.Angle(transform.forward, to) > 60)
            {
                //120度视线外
                continue;
            }

            //射线探测能否看到目标
            Ray ray = new Ray(transform.position + offset, to);
            RaycastHit hit;
            if(!Physics.Raycast(ray,out hit, maxScanDist))
            {
                //没有中间遮挡
                continue;
            }
            if(hit.collider != c)
            {
                //一根射线串2个障碍物，检测外面的物体，发生碰撞的是里面的物体
                continue;
            }
            Debug.DrawLine(transform.position+offset,hit.point,Color.blue);


            //同时发现多个物体时，处理优先级
            if(c.gameObject.tag == "Player")
            {
                return c.transform;
            }
            if(c.gameObject.tag == "Cigar")
            {
                targets.Add(c.transform);
            }
            if (c.gameObject.tag == "Corpse")
            {
                targets.Add(c.transform);
            }
        }

        if(targets.Count > 0)
        {
            return targets[0];
        }

        return null;
    }
    //追击
    void UpdateChase()
    {
        if(attackTarget == null)
        {
            //没有目标时，回到巡逻状态
            state = AIState.Patrol;
            return;
        }

        if(Vector3.Distance(attackTarget.position, transform.position) > maxChaseDist)
        {   //超过追击距离，返回到巡逻状态
            state = AIState.Patrol;
            agent.isStopped = true;
            attackTarget = null;
            return;
        }

        //追击过程中，不断更新实现，追击诱饵时，发现了玩家就把目标改成玩家。
        Transform target = UpdateScan();
        if(target == null)
        {
            return;
        }
        //追击过程中，进行攻击范围，改成攻击状态
        if(Vector3.Distance(target.position,transform.position) <= maxAttackDist)
        {
            state = AIState.Attack;
            attackTarget = target;
            agent.isStopped = true;
            return;
        }

        if(Vector3.Distance(target.position,transform.position) > 0.5f)
        {
            agent.isStopped = false;
            agent.SetDestination(target.position);
        }
    }
    //攻击
    void UpdateAttack()
    {
        if(attackTarget == null)
        {
            state = AIState.Patrol;
            return;
        }

        Transform target = UpdateScan();
        if (target == null)
        {
            state = AIState.Chase;
            agent.isStopped = false;
            return;
        }

        attackTarget = target;
        if(Vector3.Distance(target.position,transform.position)>maxAttackDist)
        {
            agent.isStopped = false;
            agent.SetDestination(attackTarget.position);
            return;
        }

        agent.isStopped = true;
        if(attackTarget.tag == "Player")
        {
            Shoot(attackTarget.position);
        }
        else if(attackTarget.tag == "Cigar")
        {
            //如果攻击目标是投掷物，销毁投掷物
            attackTarget.GetComponent<Throwing>().DelayDestroy();
        }
    }

    public void BeHit(int demage)
    {
        if (hp <= 0) return;
        hp -= demage;
        if (hp <= 0)
        {
            hp = 0;
            Die();
        }
    }

    void Die()
    {
        state = AIState.Die;
        agent.isStopped = true;
        agent.enabled = false;
        transform.Rotate(90,0,0);
        Destroy(viewFilter);
        Destroy(viewRender);
        transform.Find("Corpse").gameObject.SetActive(true);
    }
    //踩到陷阱，被冻结
    public void OnTrap(float time)
    {
        state = AIState.Freeze;
        freezeTime = Time.time + time;
        agent.isStopped = true;
    }

    //射击
    void Shoot(Vector3 target)
    {
        if (Time.time < nextShootTime) return;

        target.y = transform.position.y;
        transform.LookAt(target);

        Vector3 dir = target - transform.position;
        dir.y = 0;
        dir = dir.normalized;

        Vector3 startPos = new Vector3(transform.position.x, transform.position.y + coll.height / 2, transform.position.z);
        startPos += dir * (2.5f*coll.radius);

        Transform bullet = Instantiate(prefabBullet,startPos,Quaternion.identity);
        Bullet b = bullet.GetComponent<Bullet>();
        b.Init("Player",dir);

        nextShootTime = Time.time + shootInterval;
    }


}
