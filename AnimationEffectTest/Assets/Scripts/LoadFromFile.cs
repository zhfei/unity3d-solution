using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;


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
        //string profabPath3 = @"file:///Users/zhoufei/Documents/Unity3D/unity3d-solution/AnimationEffectTest/AssetBundles/cylinder.ab";
        string profabPath3 = @"http://localhost/AssetBundles/cylinder.ab";

        string profabPath4 = @"http://localhost/AssetBundles/sphere.ab";
        string assetBundleManifestPath = "AssetBundles/AssetBundles";

        // 1.读取本地ab包
        LoadFromFileMethod(profabPath, sharePath);

        // 2.启动一个协程,读取内存ab包
        StartCoroutine(LoadFromMemoryAsync(profabPath2));


        // 3.启动一个协程,使用WWW读取内存ab包
        StartCoroutine(LoadFromCacheOrDownload(profabPath3));

        // 4.启动一个协程,使用UnityWebRequest读取内存ab包
        StartCoroutine(LoadWithUnityWebRequest(profabPath4));

        // 5.加载manifest
        LoadManifestFile(assetBundleManifestPath);
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
        while (!Caching.ready)
            //暂停一帧
            yield return null;
        //5：下载资源的版本号，如果想全部重新下载，则添加一个新的版本号
        //path: 使用http://或者使用file://进行发生网络请求加载
        //crc：ab.manifast中crc校验码，网络下载成功后会根据下载的内容生成一个crc校验码，然后和文件中的crc进行对比，来保证文件的完整性。
        var www = WWW.LoadFromCacheOrDownload(path, 5);
        Debug.Log("LoadFromCacheOrDownload");
        //等待下载完成
        yield return www;
        if (!string.IsNullOrEmpty(www.error)) {
            Debug.Log(www.error);
            //手动中断协程，否则报错了系统不会自动停止
            yield break;
        }

        var assetBundle = www.assetBundle;
        
        Debug.Log(assetBundle);
        GameObject profab = assetBundle.LoadAsset<GameObject>("Cylinder");
        Instantiate(profab);
    }

    //4.使用UnityWebRequest工具请求网络AB包或者本地AB包
    IEnumerator LoadWithUnityWebRequest(string path)
    {
        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(path);
        yield return request.Send();
        AssetBundle assetBundle = DownloadHandlerAssetBundle.GetContent(request);
        GameObject gameObject = assetBundle.LoadAsset<GameObject>("Sphere");
        Instantiate(gameObject);

        
        //AssetBundle assetBundle1 =  (request.downloadHandler as DownloadHandlerAssetBundle).assetBundle;
        ////数据保存到本地
        //File.WriteAllBytes(path, (request.downloadHandler as DownloadHandlerAssetBundle).data);

    }

    //5.加载manifest文件， 通过manifest提前加载一个ab包的依赖包，防止资源丢失
    void LoadManifestFile(string path) {
        AssetBundle assetBundle = AssetBundle.LoadFromFile(path);
        AssetBundleManifest assetBundleManifest = assetBundle.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
        //查看所有的ab包
        foreach (string name in assetBundleManifest.GetAllAssetBundles()) {
            Debug.Log(name);
        }

        string[] strs = assetBundleManifest.GetAllDependencies("cube.ab");
        foreach (string name in strs) {
            Debug.Log("加载依赖包："+name);
            AssetBundle.LoadFromFile("AssetBundles/" + name);
        }
    }

    //6.资源卸载
    void UnLoadAssetBundle(string path)
    {
        AssetBundle assetBundle = AssetBundle.LoadFromFile(path);
        //true：卸载所有的资源
        //false: 卸载不使用的资源，对于正在使用的如Materal不卸载，这可能导致内存泄漏
        //推荐固定卸载时机，自己把控是否使用，然后选择true进行卸载。
        assetBundle.Unload(true);
        //卸载单个不使用的资源，如果卸载Materal，防止资源
        Resources.UnloadUnusedAssets();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
