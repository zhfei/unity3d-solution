using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataTool : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //使用偏好设置保存一些小数据
    void UsePlayerPrefs()
    {
        //保存
        PlayerPrefs.SetInt("age",20);
        PlayerPrefs.SetFloat("Score",99.0f);
        PlayerPrefs.SetString("name","jack");
        //查询
        int age = PlayerPrefs.GetInt("age");
        float score = PlayerPrefs.GetFloat("Score");
        string name = PlayerPrefs.GetString("name");
        //删除
        PlayerPrefs.DeleteKey("age");
        PlayerPrefs.DeleteAll();

        //判断
        bool exist = PlayerPrefs.HasKey("score");
    }
}
