using System;

namespace Day07
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //装箱，拆箱

            //装箱
            int a = 10;
            object obj = a;
            Console.WriteLine(a);

            //拆箱
            int b = (int)obj;
            Console.WriteLine(b);

            //出现装箱，拆箱现象一般出现在：一个函数的参数是obect引用类型，传参时传递了int基本类型，导致装箱
            //解决这类问题的方法：使用函数重载，泛型来避免
        }
    }
}
