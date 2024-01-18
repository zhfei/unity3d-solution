using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///
/// </summary>

public class LoadFromFile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AssetBundle share = AssetBundle.LoadFromFile("AssetBundles/share.ab");
        AssetBundle ab = AssetBundle.LoadFromFile("AssetBundles/cube.ab");
        GameObject profab = ab.LoadAsset<GameObject>("Cube");
        Instantiate(profab);

        //Object[] objs = ab.LoadAllAssets();
        //foreach (Object obj in objs) {
        //    Instantiate(obj);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
