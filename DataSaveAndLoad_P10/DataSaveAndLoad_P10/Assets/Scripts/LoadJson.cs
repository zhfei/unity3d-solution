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
        Dictionary<string, ItemJson> dict;

        TextAsset jsonText = Resources.Load<TextAsset>("JSON/Items");

        Debug.Log("jsonText:"+ jsonText.ToString());

        dict = JsonMapper.ToObject<Dictionary<string, ItemJson>>(jsonText.text);

        foreach(var pair in dict)
        {
            Debug.LogFormat("{0}:{1}, {2}, {3}",pair.Key,pair.Value.id,
               pair.Value.name, pair.Value.attack);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
