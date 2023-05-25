using System;

namespace Day08
{
    public class Person
    {
        //私有字段，成员变量
        private string name;
        private int age;

        //公有属性，用于get,set私有成员变量
        public string Name {
            get {
                return this.name;
            }

            set {
                this.name = value;
            }
        }
        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                this.age = value;
            }
        }

        // 构造方法
        public Person()
        {

        }
    }
}
