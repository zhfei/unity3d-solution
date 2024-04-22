using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshPro))]
public class PrefTest : MonoBehaviour
{

    int counter = 0;
    TextMeshPro textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponent<TextMeshPro>();
        counter = PlayerPrefs.GetInt("counter");
        textMeshPro.text = counter.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            counter++;
            PlayerPrefs.SetInt("counter",counter);
            textMeshPro.text = counter.ToString();
        }

        if(Input.GetButtonDown("Cancel"))
        {
            counter = 0;
            PlayerPrefs.SetInt("counter",counter);
            textMeshPro.text = "0";
        }
    }
}
