using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///敌人生成器：提供生成敌人的功能
/// 
/// </summary>

public class EnemySpawn : MonoBehaviour
{

    public int maxCount = 5;

    private int maxDelay = 2;

    private int startCount = 2;

    private int currentCount = 2;

    //可选路线
    private WayLine[] lines;
    //敌人类型
    private GameObject[] enemyTypes;

    // Start is called before the first frame update
    void Start()
    {
        //创建路线数组
        CreateWayLines();

        //创建2个敌人
        for (int i = 0; i < startCount; i++)
        {
            BatchCreateEnemies();
        }

        //随机选择一条路线，设置给敌人

    }
    // 批量生成敌人
    private void BatchCreateEnemies()
    {
        // 所有的敌人都生成完成了
        if (currentCount >= maxCount)
        {
            print("over");
        }
        else
        {
            currentCount++;
            float delay = Random.Range(0, maxDelay);
            // 随机延时生成敌人
            Invoke("CreateOneEnemy", delay);
        }
    }

    // 创建一个敌人
    private void CreateOneEnemy()
    {
        // 获取当前可用的路线
        var usableWayLines = selectUsableWayLines();
        // 随机选择一种敌人类型
        int enemyTypeIndex = Random.Range(0, usableWayLines.Length);
        var selectedWayLine = usableWayLines[enemyTypeIndex];
        // Instantiate(敌人预制件，生成的敌人放置的位置，朝向)
        var GameObj = Instantiate(enemyTypes[enemyTypeIndex], selectedWayLine.Pointers[0], Quaternion.identity) as GameObject;

        // 给敌人对象上面的 EnemyMator敌人马达设置 敌人运动的路线
        GameObj.GetComponent<EnemyMotor>().wayline = selectedWayLine;
        selectedWayLine.IsUseable = false;

        // 给敌人状态组件设置当前敌人生成器，用于在敌人死亡时，主动生成一个敌人
        GameObj.GetComponent<EnemyStatusInfo>().spawn = this;
    }

    //创建路线
    private void CreateWayLines()
    {
        //lines个数与敌人生成器子物体数对应
        lines = new WayLine[this.transform.childCount];

        //敌人生成器中所有可选的线数
        for (int i = 0; i < this.transform.childCount; i++)
        {
            var tf = this.transform.GetChild(i);
            var lineOne = lines[i];
            //每根线的点数
            for (int j = 0; j < tf.transform.childCount; j++)
            {
                var tfP = tf.transform.GetChild(j);
                lineOne.Pointers[j] = tfP.position;
            }
        }
    }

    private WayLine[] selectUsableWayLines()
    {
        List<WayLine> usableList = new List<WayLine>(lines.Length);
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].IsUseable)
            {
                usableList.Add(lines[i]);
            }
        }
        return usableList.ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateEnemy()
    {

    }
}
