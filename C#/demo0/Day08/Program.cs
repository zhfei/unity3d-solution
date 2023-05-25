using System;


namespace Day08
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Person p = new Person();
            p.Name = "hanmeimei";
            p.Age = 20;
            Console.WriteLine("{0},{1}",p.Name, p.Age);
        }
    }
}
