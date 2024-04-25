using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

enum AIState
{
    Idle, //待机状态
    Attack,//攻击状态
    Back//返回状态
}

public class EnemyAIViewState : MonoBehaviour
{
    public int viewRadius = 4;//视野半径
    public int viewLines = 30;//视线条数

    //模型由网格组成，网格由顶点组成，一个三角面顶点的描述顺序（顺时针或逆时针）不同，得到平面表示为正面（法线向外）和反面（法线向内）。
    public MeshFilter viewMeshFilter;
    List<Vector3> viewVerts; //顶点列表
    List<int> viewIndices; //顶点序号列表， 顶点序号顺时针排列表示贴图在外，法线朝外。
                           //

    AIState state; //AI状态机的“状态”
    Transform target; //攻击目标
    Vector3 homePos; //起点位置
    Quaternion homeRot; //起点朝向
    NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
    {
        Transform view = transform.Find("View");
        viewMeshFilter = view.GetComponent<MeshFilter>();

        viewVerts = new List<Vector3>();
        viewIndices = new List<int>();

        homePos = transform.position;
        homeRot = transform.rotation;
        agent = GetComponent<NavMeshAgent>();
        state = AIState.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        //状态机
        switch(this.state)
        {
            case AIState.Idle:
                {
                    //待机中
                    FieldOfView();
                    if(target != null)
                    {
                        this.state = AIState.Attack;
                    }
                }
                break;
            case AIState.Attack:
                {
                    //进攻中
                    agent.SetDestination(target.position);
                    if(Vector3.Distance(transform.position,target.position) > 10)
                    {
                        target = null;
                        this.state = AIState.Back;
                    }
                    if (Vector3.Distance(transform.position, homePos) > 15)
                    {
                        target = null;
                        this.state = AIState.Back;
                    }
                }
                break;
            case AIState.Back:
                {
                    //返回中
                    agent.SetDestination(homePos);
                    if(!agent.hasPath) //回到起点了
                    {
                       if(Quaternion.Angle(transform.rotation,homeRot) > 0.5f)
                        {
                            transform.rotation = Quaternion.RotateTowards(transform.rotation,homeRot,2f);
                        } else
                        {
                            state = AIState.Idle;
                        }

                    }
                }
                break;
        }
    }

    void FieldOfView()
    {
        viewVerts.Clear();
        viewVerts.Add(Vector3.zero); //加起点坐标

        //最左边的那根射线向量
        Vector3 vector_left = Quaternion.Euler(0, -45, 0) * transform.forward * viewRadius;
        for (int i = 0; i < viewLines; i++)
        {
            Vector3 v = Quaternion.Euler(0, i * (90 / viewLines), 0) * vector_left;
            //射线终点位置
            Vector3 pos = transform.position + v;

            RaycastHit hit;
            if (Physics.Raycast(transform.position, v, out hit, viewRadius))
            {
                //射线碰到物体，碰撞点改为终点
                pos = hit.point;
                if(hit.transform.CompareTag("Player"))
                {
                    //看到玩家了
                    target = hit.transform;
                }
            }

            Vector3 p = transform.InverseTransformVector(pos);
            viewVerts.Add(p);
        }

        //生成网格
        RefreshView();
    }


    void RefreshView()
    {
        viewIndices.Clear();
        //逐个添加三角面，每个三角面都以起点开始
        for (int i = 1; i < viewVerts.Count - 1; i++)
        {
            viewIndices.Add(0); //起点
            viewIndices.Add(i);
            viewIndices.Add(i + 1);
        }
        //网格对象
        Mesh mesh = new Mesh();
        mesh.vertices = viewVerts.ToArray(); //顶点数组
        mesh.triangles = viewIndices.ToArray();//顶点序号数组，每三个为一组，一组为一个三角面，数组整体个数为3的倍数
        viewMeshFilter.mesh = mesh;
    }


}
