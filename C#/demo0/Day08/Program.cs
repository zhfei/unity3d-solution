using System;
using System.Collections.Generic;

namespace Day08
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Person p = new Person();
            p.Name = "hanmeimei";
            p.Age = 18;
            Console.WriteLine("{0},{1}",p.Name, p.Age);

            //列表
            List<Person> list = new List<Person>();
            list.Add(p);

            foreach (var item in list)
            {
                Console.WriteLine(item.Name);
            }

            //字典
            Dictionary<string, Person> dict = new Dictionary<string, Person>();
            dict.Add("jack", p);
            object po = dict["jack"];
            Person p2 = (Person)po;
            Console.WriteLine(p2.Age);

            //static静态常量
            Console.WriteLine("学习分数：{0}", Student.score);
        }
    }
}
