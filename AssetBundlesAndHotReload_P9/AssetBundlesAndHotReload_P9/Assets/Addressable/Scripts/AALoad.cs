using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class AALoad : MonoBehaviour
{
    public GameObject prefab;
    public AssetReference refPrefab;

    private async void OnGUI()
    {
        if(GUILayout.Button("实例化AA预制体"))
        {
            //预制体加载方式1：引用加载
            //GameObject.Instantiate<GameObject>(prefab);
            //Addressables.InstantiateAsync(refPrefab, Random.insideUnitSphere*3, Quaternion.identity);

            //方式二：本地加载
            //Addressables.InstantiateAsync("LocalSphere", Random.insideUnitSphere * 3, Quaternion.identity);
            //方式三：远程加载
            Addressables.InstantiateAsync("RemoteSphere", Random.insideUnitSphere * 3, Quaternion.identity).Completed += AALoad_Completed;
            
        }

        if (GUILayout.Button("加载图片，音频资源"))
        {
            Texture texture = await Addressables.LoadAssetAsync<Texture>("图片名称").Task;
            //卸载
            Addressables.Release(texture);
        }
    }

    //异步方式一，走回调代理
    private void AALoad_Completed(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<GameObject> obj)
    {
        Debug.Log("第一个游戏对象加载完成"+obj.Result);
    }


    //异步方法二，async,await
    public async void AALoad_FuncAsync()
    {
        //类似于协程，程序执行到这里，CPU控制器会返回给Unity引擎，指定异步逻辑执行完成，才会执行await下面的代码
        GameObject go = await Addressables.InstantiateAsync("RemoteSphere", Random.insideUnitSphere * 3, Quaternion.identity).Task;

        //await异步方法执行完成，才会走到下面的代码
        Debug.Log(go.name);

        //是否实例对象
        Addressables.ReleaseInstance(go);
    }
    
}
