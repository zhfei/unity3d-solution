using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//0.声明委托类型
delegate void MyFunc1();
delegate int MyFunc2(int a);


/// <summary>
/// C#的委托使用
/// </summary>

public class TestDelegate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //1.定义delegate委托变量
        MyFunc1 f1;
        f1 = F;
        MyFunc2 f2;
        f2 = G;

        f1();
        f2(33);

        //2.将函数作为参数传递
        CallFunc(F,G,90);
        //列表，每个元素都是函数的引用
        List<MyFunc1> funcs = new List<MyFunc1>();
        funcs.Add(F);
        foreach(MyFunc1 f in funcs)
        {
            f();
        }

        //委托的+=与-=相当于UnityEvent的AddListenner和RemoveListener
        MyFunc2 g = null;
        g += GA;
        g += GB;
        g += GC;
        //依次调用GA,GB,GC
        g(3);

        //再加一次GA,去掉GC
        g += GA;
        g -= GC;
        g(5);
    }

    void F()
    {
        Debug.Log("F");
    }

    int G(int a)
    {
        Debug.Log("G:"+a);
        return 10;
    }

    void CallFunc(MyFunc1 f, MyFunc2 g, int n)
    {
        Debug.Log("间接调用函数");
        f();
        g(3);
    }

    int GA(int i)
    {
        Debug.Log("GA "+i);
        return 0;
    }
    int GB(int i)
    {
        Debug.Log("GB " + i);
        return 0;
    }
    int GC(int i)
    {
        Debug.Log("GC " + i);
        return 0;
    }

}
