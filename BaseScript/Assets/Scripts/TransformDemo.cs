using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 提供了查找（父，根，子类）transform组件，改变位置，缩放，旋转。
/// </summary>

public class TransformDemo : MonoBehaviour
{
    public Transform tf;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        if (GUILayout.Button("this.transform"))
        {   // 获取所有子类的transform
            foreach (Transform item in this.transform)
            {
                //item.position = new Vector3(0,1,1);
                print(item.name);
            }
            // 相对于父类的坐标
            var lp = this.transform.localPosition;
            //相对于世界坐标系的坐标
            var p = this.transform.position;

            //相对于父类缩放
            var ls =  this.transform.localScale;
            //绝对缩放，如果物体缩放3，父物体缩放2， 则lossyScale为6（自身缩放比例*父物体缩放比例）
            var s = this.transform.lossyScale;

        }
        if (GUILayout.Button("Translate"))
        {
            //沿自身坐标系的z轴移动。
            //this.transform.Translate(0, 0, 1);
            //沿时间坐标系的z轴移动。
            this.transform.Translate(0, 0, 1, Space.World);
        }
        if (GUILayout.Button("Rotate"))
        {
            //沿自身坐标系的z轴旋转。
            //this.transform.Rotate(0, 0, 1);
            //沿时间坐标系的z轴旋转。
            this.transform.Rotate(0, 0, 1, Space.World);
        }
        if (GUILayout.Button("RotateAround"))
        {
            //围绕旋转
            this.transform.RotateAround(Vector3.zero, Vector3.forward, 1);
        }
        if (GUILayout.Button("Parent"))
        {
            //父组件、根组件
            Transform root = this.transform.root;
            Transform parent = this.transform.parent;

            print(root.name);
            print(parent.name);

            
        }
        if (GUILayout.Button("SetParent"))
        {
            //当前物体的位置视为 世界坐标
            this.transform.SetParent(tf,true);
            //当前物体的位置视为 localPosition
            this.transform.SetParent(tf, false);
        }
        if (GUILayout.Button("Find"))
        {
            //根据名称获取子物体
            this.transform.Find("子物体名称");
            this.transform.Find("子物体名称/孙子物体名称");

            int count = this.transform.childCount;
            for (int i = 0; i < count; i++)
            {
                Transform tf = this.transform.GetChild(i);
                print(tf.name);
            }
        }
    }
}
