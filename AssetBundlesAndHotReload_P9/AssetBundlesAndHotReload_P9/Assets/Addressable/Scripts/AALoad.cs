using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class AALoad : MonoBehaviour
{
    public GameObject prefab;
    public AssetReference refPrefab;

    private void OnGUI()
    {
        if(GUILayout.Button("实例化AA预制体"))
        {
            //预制体加载方式1：引用加载
            //GameObject.Instantiate<GameObject>(prefab);
            //Addressables.InstantiateAsync(refPrefab, Random.insideUnitSphere*3, Quaternion.identity);

            //方式二：本地加载
            //Addressables.InstantiateAsync("LocalSphere", Random.insideUnitSphere * 3, Quaternion.identity);
            //方式三：远程加载
            Addressables.InstantiateAsync("RemoteSphere", Random.insideUnitSphere * 3, Quaternion.identity);
            
        }
    }
}
