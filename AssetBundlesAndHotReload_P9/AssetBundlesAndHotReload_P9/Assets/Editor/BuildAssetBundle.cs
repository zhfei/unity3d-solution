using UnityEditor;
using System.IO;

public class BuildAssetBundle 
{
    //在主菜单中添加选项
    [MenuItem("Asset Bundles/Build AssetBundles")]
    static void BuildAllAssetBundles()
    {
        //要创建的目录
        string dir = "AssetBundles";
        if(!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        //创建资产包，用于iOS平台的发布
        BuildPipeline.BuildAssetBundles(dir,BuildAssetBundleOptions.None,BuildTarget.iOS);
    }
        
}
