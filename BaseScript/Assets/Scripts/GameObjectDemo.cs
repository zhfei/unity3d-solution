using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///
/// </summary>

public class GameObjectDemo : MonoBehaviour
{
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
        if (GUILayout.Button("Active"))
        {
            //在场景中的物体激活状态（物体真实的激活状态， 如果父物体状态打钩关掉，子类即使有钩，依然是非激活状态）
            bool isAcH = this.gameObject.activeInHierarchy;
            //物体自身的激活状态（是否被打钩）
            bool isAcSelf = this.gameObject.activeSelf;

            print("activeInHierarchy: " + isAcH);
            print("activeSelf: " + isAcSelf);
        }
        if (GUILayout.Button("添加光源"))
        {
            //创建物体
            GameObject go = new GameObject();
            //添加光源
            Light lt = go.AddComponent<Light>();
            lt.color = Color.red;
            lt.type = LightType.Point;
        }
        if (GUILayout.Button("FindGameObject"))
        {
            var gos = GameObject.FindGameObjectsWithTag("fire");
            var go = GameObject.FindGameObjectWithTag("fire");

            MeshRenderer[] list = GameObject.FindObjectsOfType<MeshRenderer>();

            print(gos);
            print(go);
            print(list);
        }
    }
}
