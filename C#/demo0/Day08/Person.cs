using System;

namespace Day08
{
    public class Person
    {
        //1.数据成员
        /*
         * 字段：存储数据
         * 属性：包含字段
         */
        //2.方法成员
        /*
         * 构造函数：用于创建对象
         * 方法：提供功能
         */


        //1.私有字段，成员变量
        private string name;
        private int age;

        //属性，用于get,set私有成员变量
        public string Name {
            //读取私有成员保护
            get {
                return this.name;
            }
            //写入私有成员保护
            set
            {
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
                if (value >= 18 && value <= 20)
                {
                    this.age = value;
                }
                else {

                    throw new Exception("输入年龄不可用");
                }

                
            }
        }
        //公共字段：属性+数据字段， 一个字段+两个方法
        public string Sex;

        //2.构造方法, 一个类如果类中没有写构造函数，编译器就会自己加一个默认的。如果用户自己加了，那么系统就不在添加默认的了
        //构造方法特征：无返回值，方法名和类名一样
        public Person(): this("",0)
        {

        }

        public Person(string name): this(name,0)
        {

        }

        public Person(string name, int age)
        {
            //this.name = name;
            //this.age = age;
            //使用属性设置，走安全过滤
            this.Name = name;
            this.Age = age;
        }
    }
}
