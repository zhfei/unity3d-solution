using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class TestLoadAB : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string path = "/Users/admin/Documents/Unity/unity3d-solution/AssetBundlesAndHotReload_P9/AssetBundlesAndHotReload_P9/AssetBundles/ab";
        //1.同步加载本地AssetBundle包
        //AssetBundle ab = AssetBundle.LoadFromFile(path);

        //GameObject prefab1 = ab.LoadAsset<GameObject>("Cube");
        //GameObject prefab2 = ab.LoadAsset<GameObject>("Sphere");
        //GameObject prefab3 = ab.LoadAsset<GameObject>("icon1");
        //GameObject prefab4 = ab.LoadAsset<GameObject>("icon2");

        ////GameObject[] prefabs = ab.LoadAllAssets<GameObject>(); //加载所有

        //Instantiate(prefab1, new Vector3(0, 0, 0), Quaternion.identity);
        //Instantiate(prefab2, new Vector3(1, 0, 0), Quaternion.identity);
        //Instantiate(prefab3, new Vector3(2, 0, 0), Quaternion.identity);
        //Instantiate(prefab4, new Vector3(3, 0, 0), Quaternion.identity);

        //2.异步加载本地AssetBundle包
        //StartCoroutine(LoadFileAsync(path));


        //3.异步加载网络AssetBundle包
        string urlPath = "http://121.199.5.39/res/assetBundle/testAB/ab"; //成功
        //string urlPath2 = "http://121.199.5.39/res/assetBundle/testZipAB/AssetBundles.zip"; //失败
        StartCoroutine(UseUnityWebRequestLoadWebAB(urlPath));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //本地异步加载AB包
    IEnumerator LoadFileAsync(string path)
    {
        AssetBundleCreateRequest request = AssetBundle.LoadFromFileAsync(path);
        //在LoadFromFileAsync方法加载完成之前，方法不会执行到yield return的下面。
        yield return request;

        AssetBundle ab = request.assetBundle;
        GameObject go = ab.LoadAsset<GameObject>("Cube");
        GameObject prefab1 = Instantiate<GameObject>(go);
    }

    IEnumerator UseUnityWebRequestLoadWebAB(string path)
    {
        //发送网络请求加载AB包，path可以是网络URL，也可以是本地file://User/Libaray/...路径
        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(path);
        yield return request.SendWebRequest();

        //异步网络请求结束，拿到请求结果
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
        }
        else
        {
            AssetBundle ab = DownloadHandlerAssetBundle.GetContent(request);

            GameObject go = ab.LoadAsset<GameObject>("Cube");
            Instantiate(go);
        }
    }
}
