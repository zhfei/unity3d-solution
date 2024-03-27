using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindComponentAndGameObjectWithFatherAndSon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Unity中父子关系的表示是使用Transform来表示的。

        //根据父子关系路径查询子物体，使用电脑中文件目录的方式查询
        Transform rightLeg = transform.Find("Character1_Reference/Character1_Hips/Character1_RightUpLeg");
        Transform root = transform.Find("../../..");
        Debug.Log("根据父子关系，查询到游戏物体："+rightLeg.gameObject.name+"和"+root.gameObject.name);

        //根据Unity提供的API查询
        Transform parent1 = transform.parent; //这两个查询结果相同
        Transform parent2 = transform.Find("..");

        //子物体排列序号查询
        Transform rightLeg2 = parent1.GetChild(1);
        for (int i = 0; i< parent1.childCount; i++) {
            Transform child = parent1.GetChild(i);
            Debug.Log("查询到的游戏对象名称："+child.gameObject.name);
        }

        //根据父子关系，从子物体中查询组件
        SphereCollider sc = GetComponentInChildren<SphereCollider>();
        Debug.Log("查询到的游戏对象名称：" + sc.gameObject.name);

        //注意：如果游戏物体是禁用状态，那么需要使用父子关系进行查找。可以使用场景查找+父子关系查找两种方式进行查找。
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
