using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
///
/// </summary>

public class RuntimeAddEventHandlerTest : MonoBehaviour
{

    Button button;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = transform.GetChild(0).GetComponent<Button>();
        btn.onClick.AddListener(Btn1Click);

        btn = transform.GetChild(1).GetComponent<Button>();
        btn.onClick.AddListener(()=> { Debug.Log("按钮2被点击了"); });

        btn = transform.GetChild(2).GetComponent<Button>();
        btn.onClick.AddListener(Btn3Click);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Btn1Click()
    {
        Debug.Log("Btn1点击");
    }

    void Btn3Click()
    {
        Debug.Log("Btn3点击");

        Button btn3 = transform.GetChild(2).GetComponent<Button>();
        btn3.onClick.RemoveAllListeners();
    }
}
