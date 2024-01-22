using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


/// <summary>
///
/// </summary>

public class LoadFromFile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string sharePath = "AssetBundles/share.ab";
        string profabPath = "AssetBundles/cube.ab";
        string profabPath2 = "AssetBundles/capsule.ab";

        // 1.读取本地ab包
        LoadFromFileMethod(profabPath, sharePath);

        // 2.启动一个协程,读取内存ab包
        StartCoroutine(LoadFromMemoryAsync(profabPath2));
    }

    //1.从本地读取
    void LoadFromFileMethod(string profabPath, string sharePath) {
        AssetBundle share = AssetBundle.LoadFromFile(sharePath);
        AssetBundle ab = AssetBundle.LoadFromFile(profabPath);

        if (share == null || ab == null) {
            Debug.Log("AB包加载失败");
            return;
        }

        GameObject profab = ab.LoadAsset<GameObject>("Cube");
        Instantiate(profab);

        //Object[] objs = ab.LoadAllAssets();
        //foreach (Object obj in objs) {
        //    Instantiate(obj);
        //}  
    }
    //2.从本地内存中读取
    IEnumerator LoadFromMemoryAsync(string path)
    {
        AssetBundleCreateRequest request = AssetBundle.LoadFromMemoryAsync(File.ReadAllBytes(path));
        yield return request;
        AssetBundle assetBundle = request.assetBundle;
        GameObject profab = assetBundle.LoadAsset<GameObject>("Capsule");
        Instantiate(profab);
    }

    //3.使用WWW工具请求网络AB包或者本地AB包
    IEnumerator LoadFromCacheOrDownload(string path)
    {
        AssetBundleCreateRequest request = AssetBundle.LoadFromMemoryAsync(File.ReadAllBytes(path));
        yield return request;
        AssetBundle assetBundle = request.assetBundle;
        GameObject profab = assetBundle.LoadAsset<GameObject>("Capsule");
        Instantiate(profab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
