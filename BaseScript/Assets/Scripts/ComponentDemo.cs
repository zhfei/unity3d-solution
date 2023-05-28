using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Component类提供了查找（当前物体，后代，先辈）组件的功能。
/// </summary>

public class ComponentDemo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //当Unity页面渲染和发送事件时触发回调。
    private void OnGUI()
    {
        //Unity早期页面的创建代码GUILayout.Button， 现在已经被废弃
        //GUILayout.Button作用：创建一个可点击按钮，并在按钮点击时，返回true
        if (GUILayout.Button("transform-Z-0"))
        {
            this.transform.position = new Vector3(0, 0, 0);
        }
        if (GUILayout.Button("transform-Z-10"))
        {
            this.transform.position = new Vector3(0, 0, 10);
        }
        if (GUILayout.Button("GetComponent"))
        {
            this.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        //获取后代物体的指定类型组件（从this自身开始找,把自身的也返回）【往下找，子类，孙子类】
        if (GUILayout.Button("GetComponentsInChildren"))
        {
            var allComponents = this.GetComponentsInChildren<MeshRenderer>();
            foreach (var item in allComponents)
            {
                item.material.color = Color.red;
            }
        }
        //获取前辈物体的指定类型组件（从this自身开始找,把自身的也返回）【往上找，父类，祖父类】
        if (GUILayout.Button("GetComponentsInParent"))
        {
            var allComponents = this.GetComponentsInParent<MeshRenderer>();
            foreach (var item in allComponents)
            {
                item.material.color = Color.red;
            }
        }
        //获取自己的指定类型组件（从this自身开始找,把自身的也返回）【只在自己身上找】
        if (GUILayout.Button("GetComponents"))
        {
            var allComponents = this.GetComponents<MeshRenderer>();
            foreach (var item in allComponents)
            {
                item.material.color = Color.red;
            }
        }
    }
}
