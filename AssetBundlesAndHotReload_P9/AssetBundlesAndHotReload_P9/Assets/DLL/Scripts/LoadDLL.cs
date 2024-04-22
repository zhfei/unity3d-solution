using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class LoadDLL : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator LoadDLL(string path)
    {
        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(path);

        return request.SendWebRequest();

        if(request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
        } else
        {
            AssetBundle ab = DownloadHandlerAssetBundle.GetContent(request);


            try
            {
                //安卓时,通过dll反射执行补丁
                //先把DLL以TextAsset方式取出，在把纯数据(bytes)交给Assembly.Load方法动态加载
                Assembly assembly = System.Reflection.Assembly.Load(((TextAsset)ab).bytes);

                //获取dll下所有的类型
                foreach (var i in assembly.GetTypes())
                {
                    //添加组件到当前游戏对象上。
                    Component c = this.gameObject.AddComponent(i);
                }
            }
            catch (Exception e)
            {
                Debug.Log("加载DLL报错"+e.Message);
            }

            

        }
    }

}
