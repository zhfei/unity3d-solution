using System;
namespace Day08
{
    public class Student: Person
    {
        public static int score;

        //静态构造方法，只在类对象被创建时调用一次
        static Student()
        {
            //初始化类的静态变量
            score = 10;
        }
        //实例构造方法
        public Student()
        {
            //初始化类的实例成员变量
        }
    }
}
