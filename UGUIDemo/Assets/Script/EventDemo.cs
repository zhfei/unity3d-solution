using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///
/// </summary>

public class EventDemo : MonoBehaviour
{
    public void Func1()
    {
        print("Func1");
    }

    public void Func2(string name)
    {
        print(name);
    }

    public void Func3_EndEdit(string name)
    {
        print("Func3_EndEdit: " + name);
    }
}
