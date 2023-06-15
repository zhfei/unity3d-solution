using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///
/// </summary>

public class TransformHelper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 查找距离相机最近的敌人
    /// </summary>
    /// <param name="allEnemy"></param>
    /// <returns></returns>
    public Enemy FindEnemyByMinDistance(Enemy[] allEnemy)
    {
        Enemy minDistanceEnemy = allEnemy[0];
        float minDistance = Vector3.Distance(this.transform.position, minDistanceEnemy.transform.position);
        for (int i = 1; i < allEnemy.Length; i++)
        {
            Enemy one = allEnemy[i];
            float distance1 = Vector3.Distance(one.transform.position, this.transform.position);
            if (distance1 < minDistance)
            {
                minDistanceEnemy = one;
                minDistance = distance1;
            }

        }

        return minDistanceEnemy;
    }
}
