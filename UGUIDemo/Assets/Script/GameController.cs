using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
///
/// </summary>

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Init()
    {
        for (int row = 0; row < 4; row++)
        {
            for (int col = 0; col < 4; col++)
            {
                CreateSprite(row,col);
            }
        }
    }

    void CreateSprite(int row, int col)
    {
        GameObject go = new GameObject(row.ToString()+col.ToString());
        go.AddComponent<Image>();
        go.transform.SetParent(this.transform,false);
    }
}
