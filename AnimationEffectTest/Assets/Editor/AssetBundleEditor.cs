using UnityEditor;
using System.IO;


/// <summary>
///
/// </summary>

public class AssetBundleEditor 
{
    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAssetBundles() {
        string dir = "AssetBundles";
        if (!Directory.Exists(dir)) {
            Directory.CreateDirectory(dir);
        }
        BuildPipeline.BuildAssetBundles(dir, BuildAssetBundleOptions.None, BuildTarget.iOS);
    }
}
