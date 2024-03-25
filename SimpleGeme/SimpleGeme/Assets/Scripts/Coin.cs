using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        //other:为外部撞击我的游戏物体
        Debug.Log(other.name+": 撞击了我");

        Destroy(this.gameObject, 0.5f);
    }
}
