using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetBundleManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {   
        //加载资源
        //1.加载预制体，预制体资源使用GameObject表示，路径不包含Resources和扩展名
        GameObject go = Resources.Load<GameObject>("Prefabs/Person");
        //资源加载和实例化是不同的。
        GameObject go2 = Instantiate(go);


        //2.加载其他类型的资源
        Texture2D image = Resources.Load<Texture2D>("Images/header");
        Debug.Log(image);

        //卸载资源
        //3.强制卸载
        Resources.UnloadAsset(image);
        //Resources.UnloadUnusedAssets();
        //销毁物体
        Destroy(go2,5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
