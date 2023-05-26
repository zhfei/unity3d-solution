using System;
namespace Day08
{
    //结构体和类的使用方法几乎一样，区别：类在堆中保存，结构体在栈中保存。
    public struct Teacher
    {
        private string name;
        //结构体中只有static, const修饰的字段可以被初始化。
        private static int age = 0; 
        public int Age { get; set; }
    }
}
