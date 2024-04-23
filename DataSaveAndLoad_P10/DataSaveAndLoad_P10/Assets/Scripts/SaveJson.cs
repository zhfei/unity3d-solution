using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;


class PlayData
{
    public float posX;
    public float posY;
    public int hp; //血量
    public float progress; //进度

    //支持模型嵌套，LitJson会自动归档和解归档
    //public ItemJson item;
    //public List<ItemJson> items;
}


public class SaveJson : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayData pd = new PlayData();

        pd.posX = 1;
        pd.posY = 2;
        pd.hp = 100;
        pd.progress = 50;

        //对象转json, 返回json字符串
        string json = JsonMapper.ToJson(pd);
        Debug.Log(json);

        //json转对象
        PlayData playData = JsonMapper.ToObject<PlayData>(json);

        //保存json到本地
        string path = Application.persistentDataPath + "/player_data.json";
        //使用using语法打开文件，表示文件会自动妥善关闭，简化异常处理
        using (FileStream fs = new FileStream(path, FileMode.Create))
        {
            //字符串转成原始字节码，指定编码
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(json);
            //将字节码写入文件
            fs.Write(bytes,0,bytes.Length);
        }
        Debug.Log("json写入了"+path);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
