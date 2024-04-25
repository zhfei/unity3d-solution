using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToAnim : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AgentMove();
        UpdateAnim();
    }

    void AgentMove()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit))
            {
                agent.destination = hit.point;
                agent.SetDestination(hit.point);
            }
        }
    }

    void UpdateAnim()
    {
        Vector3 v = agent.velocity; //代理速度向量

        v = transform.InverseTransformVector(v);//转换坐标系：世界转局部
        animator.SetFloat("Forward",v.z);//z轴表示前进
        animator.SetFloat("Turn",v.x);//x轴表示转向

        if (agent.isOnOffMeshLink)
        {
            animator.speed = 1.0f;
            animator.SetBool("OnGround", false);
        }
        else {
            animator.speed = 3.6f;
            animator.SetBool("OnGround", true);
        }
    }
}
