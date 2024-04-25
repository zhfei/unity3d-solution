using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemy : MonoBehaviour
{
    public int viewRadius = 4;//视野距离
    public int viewLines = 30;//射线数量，越多越密集

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FieldOfView();
    }

    void FieldOfView()
    {
        //最左侧射线向量
        Vector3 forward_left = Quaternion.Euler(0, -45, 0) * transform.forward * viewRadius;

        for (int i = 0; i< viewLines; i++)
        {
            Vector3 v = Quaternion.Euler(0, (90 / viewLines)*i, 0) * forward_left;

            //射线的终点pos：游戏对象的实际位置+射线目标向量
            Vector3 pos = transform.position + v;

            //射线碰到物体，修改终点位置
            RaycastHit hit;
            if(Physics.Raycast(transform.position, v, out hit, viewRadius))
            {
                pos = hit.point;
            }

            //画辅助线
            Debug.DrawLine(transform.position,pos,Color.red);
        }
    }
}
