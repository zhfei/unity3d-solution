using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIView : MonoBehaviour
{
    public int viewRadius = 4;//视野半径
    public int viewLines = 30;//视线条数

    //模型由网格组成，网格由顶点组成，一个三角面顶点的描述顺序（顺时针或逆时针）不同，得到平面表示为正面（法线向外）和反面（法线向内）。
    public MeshFilter viewMeshFilter;
    List<Vector3> viewVerts; //顶点列表
    List<int> viewIndices; //顶点序号列表， 顶点序号顺时针排列表示贴图在外，法线朝外。                         


    // Start is called before the first frame update
    void Start()
    {
        Transform view = transform.Find("View");
        viewMeshFilter = view.GetComponent<MeshFilter>();

        viewVerts = new List<Vector3>();
        viewIndices = new List<int>();
    }

    // Update is called once per frame
    void Update()
    {
        FieldOfView();
    }

    void FieldOfView()
    {
        viewVerts.Clear();
        viewVerts.Add(Vector3.zero); //加起点坐标

        //最左边的那根射线向量
        Vector3 vector_left = Quaternion.Euler(0, -45, 0) * transform.forward * viewRadius;
        for (int i = 0; i< viewLines; i++)
        {
            Vector3 v = Quaternion.Euler(0, i * (90 / viewLines), 0) * vector_left;
            //射线终点位置
            Vector3 pos = transform.position + v;

            RaycastHit hit;
            if(Physics.Raycast(transform.position, v, out hit, viewRadius))
            {
                //射线碰到物体，碰撞点改为终点
                pos = hit.point;
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
        for(int i = 1; i< viewVerts.Count-1;i++)
        {
            viewIndices.Add(0); //起点
            viewIndices.Add(i);
            viewIndices.Add(i+1);
        }
        //网格对象
        Mesh mesh = new Mesh();
        mesh.vertices = viewVerts.ToArray(); //顶点数组
        mesh.triangles = viewIndices.ToArray();//顶点序号数组，每三个为一组，一组为一个三角面，数组整体个数为3的倍数
        viewMeshFilter.mesh = mesh;
    }


}
