using System;
using System.Text;

namespace Day07
{
    [Flags] //表示枚举可以执行与操作
    enum PersonStyle:int {
        tail = 1,
        rich = 2,
        handsome = 4,
        white = 8
    }

    class MainClass
    {
        public static void Main1(string[] args)
        {
            #region
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
            #endregion
        }

        public static void Main(string[] args)
        {
            //可变字符串，避免频繁执行拆箱，装箱，造成内存垃圾
            StringBuilder sb = new StringBuilder(10);
            for (int i = 0; i < 10; i++)
            {
                sb.Append(i);
            }
            string res = sb.ToString();
            Console.WriteLine(res);

            Func1(PersonStyle.handsome);
        }

        private static void Func1(PersonStyle ps)
        {
            switch (ps)
            {
                case PersonStyle.handsome:
                    Console.WriteLine("大智慧");
                    return;
                default:
                    break;
            }

            //按位与，或判断
            if ((ps & PersonStyle.handsome) != 0)
            {
                Console.WriteLine("大智慧");
            }
            if ((ps & PersonStyle.white) == PersonStyle.white)
            {
                Console.WriteLine("肤白貌美");
            }


        }
    }
}
