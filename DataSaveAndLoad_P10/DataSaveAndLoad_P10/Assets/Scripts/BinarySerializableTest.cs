using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;

[Serializable] //表示类属于“可序列化的”，可以用BinaryFormatter序列化这个类
public class PlayerData2
{
    public float posX;
    public float posY;
    public int hp;
    [NonReorderable] //表示属性，字段不能被序列化
    public float progress;

    public override string ToString()
    {
        //return base.ToString();
        return string.Format("PlayerData pos:({0},{1}), hp:{2},progress:{3}.",posX,posY,hp,progress);
    }
}

public class BinarySerializableTest : MonoBehaviour
{

    public PlayerData2 testPD;

    // Start is called before the first frame update
    void Start()
    {
        PlayerData2 pd2 = new PlayerData2();
        pd2.posX = 1;
        pd2.posY = 15;
        pd2.hp = 100;
        pd2.progress = 50;

        // C# 二进制序列化
        //创建内存流
        MemoryStream stream = new MemoryStream();
        //二进制格式化器
        BinaryFormatter formatter = new BinaryFormatter();
        //将对象pd序列化到内存流中
        formatter.Serialize(stream, pd2);

        //把内存流转化为byte[], 方便写入文件或者发送网络包
        byte[] binData = stream.ToArray();

        // C# 二进制反序列化
        //使用Seek将指针回到流的开头
        stream.Seek(0, SeekOrigin.Begin);

        PlayerData2 pd3 = formatter.Deserialize(stream) as PlayerData2;
        Debug.Log("pd3"+pd3);

        //借助byte[] 还原内存流
        MemoryStream ms = new MemoryStream(binData);
        PlayerData2 pd4 = formatter.Deserialize(ms) as PlayerData2;
        Debug.Log("pd4:"+pd4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
