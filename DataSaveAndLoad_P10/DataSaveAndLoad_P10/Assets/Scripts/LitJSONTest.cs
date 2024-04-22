using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class LitJSONTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        JsonData jsonData = new JsonData();
        jsonData["name"] = "jack";
        jsonData["age"] = 20;
        Debug.Log(jsonData.ToJson());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
