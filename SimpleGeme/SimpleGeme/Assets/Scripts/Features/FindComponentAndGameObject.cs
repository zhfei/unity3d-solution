using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindComponentAndGameObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // 从当前脚本组件中查询游戏对象和组件
    void FindComponentAndGameObjectFromCurrentGameObject() {
        //-- 从脚本组件中查询挂载对象自身的对象和组件 --

        //1.查询游戏物体
        //从脚本组件中查询它所挂载的游戏对象
        //GameObject gameObject0 = this.gameObject;
        GameObject gameObject0 = gameObject; //this可以省略

        //2.查询游戏物体下的组件
        //SphereCollider sc = this.gameObject.GetComponent<SphereCollider>();
        //SphereCollider sc = gameObject.GetComponent<SphereCollider>();
        SphereCollider sc = GetComponent<SphereCollider>(); //Unity语法糖，考虑到GetComponent查询组件的使用频率，this.gameObject.可以全部省略，使用脚本组件直接调用。

        //3.transform组件，考虑到transform的特殊性和使用频率，可以在脚本组件中通过this.transform 或 transform直接得到transform组件。
        Transform tf = transform;


        //4.注意，组件 == 游戏对象
        //"组件 == 游戏对象，组件弱等于它挂载的游戏对象"， 组件类型可以看成对游戏物体的一种约束，这个游戏物体必须包含该组件类型
        //当在脚本组件中定义一个组件属性时，在给属性赋值时，是可以给它赋值成游戏对象的<该游戏对象必须包含这个类型的组件>



        //-- 从整个场景中查询被激活的的对象和组件 --

        //根据名称查找
        //GameObject gameObject1 = GameObject.Find("场景中处于激活状态的游戏物体名称");
        GameObject gameObject1 = GameObject.Find("Main Camera");
        //GameObject gameObject1 = GameObject.Find("Directional Light");
        //GameObject gameObject1 = GameObject.Find("Obstacler (2)");

        //根据标签查找
        GameObject gameObjectTag = GameObject.FindGameObjectWithTag("Player"); //标签相当于前端中的class, 可以标记一类的游戏物体
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Player");
    }
        

    // Update is called once per frame
    void Update()
    {
        

    }
}
