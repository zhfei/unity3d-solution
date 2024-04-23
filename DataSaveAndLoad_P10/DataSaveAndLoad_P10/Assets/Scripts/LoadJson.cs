using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;


/// <summary>
///
/// </summary>
///
public class ItemJson
{
    public int id;
    public string name;
    public int type;
    public float attack;
    public float defence;
    public float data;
}

public class LoadJson : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Items文件必须要有json后缀，比如：Items.json 才能识别
        TextAsset jsonText = Resources.Load<TextAsset>("JSON/Items");

        Debug.Log("jsonText:"+ LoadJSON2(jsonText.text));

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //使用litJSON反序列化
    //JsonMapper：批量反序列化
    void LoadJSON1()
    {
        Dictionary<string, ItemJson> dict;

        TextAsset jsonText = Resources.Load<TextAsset>("JSON/Items");

        Debug.Log("jsonText:" + jsonText);

        dict = JsonMapper.ToObject<Dictionary<string, ItemJson>>(jsonText.text);

        foreach (var pair in dict)
        {
            Debug.LogFormat("{0}:{1}, {2}, {3}", pair.Key, pair.Value.id,
               pair.Value.name, pair.Value.attack);
        }
    }

    //逐个处理
    //LitJSON对类型匹配要求严格，使用单个处理可以进行类型转换
    Dictionary<string, ItemJson> LoadJSON2(string text)
    {
        Dictionary<string, ItemJson> dict = new Dictionary<string, ItemJson>();

        JsonData jsonData = JsonMapper.ToObject(text);

        foreach(KeyValuePair<string, JsonData> pair in jsonData)
        {
            int id = int.Parse(pair.Key);

            ItemJson item = new ItemJson();
            item.id = id;
            item.name = (string)pair.Value["name"];
            item.type = (int)pair.Value["type"];
            item.attack = float.Parse(pair.Value["attack"].ToString());
            item.defence = float.Parse(pair.Value["defence"].ToString());
            item.data = float.Parse(pair.Value["data"].ToString());

            dict.Add(id.ToString(),item);
        }

        return dict;
    }
}
