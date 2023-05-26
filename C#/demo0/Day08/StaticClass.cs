using System;
namespace Day08
{
    //static 静态类不能被实例化，只能包含static静态属性，常用作工具使用，
    static class StaticClass
    {
        public static string name;
        static StaticClass()
        {
        }
    }
}
