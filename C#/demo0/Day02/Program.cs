using System;

namespace Day02
{
    class MainClass
    {
        public static void Main1(string[] args)
        {
            #region
            string gunName = "AK 47";
            string gunCap = "300";

            // 1.字符串
            // 使用占位符来定义格式字符串
            string des = string.Format("枪的名称:{0}, 枪的子弹容量:{1}", gunName, gunCap);
            Console.WriteLine(des);

            // 字符串常用格式化
            Console.WriteLine("金额：{0:c}",10); //货币￥10.00
            Console.WriteLine("{0:d2}", 5); //05,不足2位用0填充
            Console.WriteLine("{0:f1}", 1.26); //1.3 根据指定精度四舍五入
            Console.WriteLine("{0:p0}", 0.1); //10% 以百分号显示

            //转义符，改变字符串原始含义 \", \', \0(表示空字符)
            Console.WriteLine("我爱\"Unity!\"");

            //\r\n回车换行， \t水平制表符，相当于按了一下tab键
            Console.WriteLine("我爱学习\tUnity");


            //2.算术运算
            int n1 = 5, n2 = 2;
            int r1 = n1 / n2; // 5/2 = 2.5 值为截断整数 2(除法运算中 顶部的商)
            int r2 = n1 % n2; // 5%2 = 1(除法运算中 底部的余数)
            //使用场景
            bool r3 = n1 % 2 == 0;//奇数偶数判断
            int r4 = n1 % 10;//获取十进制的个位数

            //3.快捷运算符
            //快捷运算符 +=, -=, *=, /=

            //4.一元运算符（符号的左边或右边只有一个变量: ++, --）， 二元， 三元(三目运算符 a>0?a:1)
            int singleOp = 10;
            Console.WriteLine(singleOp++);
            Console.WriteLine(++singleOp);
            //singleOp++ 和 ++singleOp只对单条语句有影响，对下一条语句没有影响。


            //5.数据类型转换
            //a.Parse转换：string类型转换成其他数据类型
            string numStr = "18";
            int num = int.Parse(numStr);
            float numF = float.Parse(numStr);
            //b.ToString转换：任意类型转换为string类型
            int num2 = 22;
            string num2Str = num2.ToString();
            Console.WriteLine(num2Str);

            //练习题：逐个取出字符串里的数字，进行相加取合
            string lineNumStr = Console.ReadLine();
            int lineNum = int.Parse(lineNumStr);
            int num0 = lineNum/10 % 10; //十位
            int num1 = lineNum / 100 % 10; //百位

            char numC = lineNumStr[0];
            string num22Str = numC.ToString();
            int num22 = int.Parse(num2Str);


            #region
            // 在VS加一个折叠符，方便编程
            #endregion


            //c.隐式类型转换
            Byte b1 = 250;
            b1 += 10; // 快捷运算符不会做类型提升，所以不保存
                      // b1 = b1 + 10; // 二元运算符会做类型提升，这里可能出现内存溢出，所以报错

            #endregion
        }

        public static void Main(string[] args)
        {
            #region
            //语句：选择语句，循环语句，跳转语句

            Console.WriteLine("请输入性别：");
            string sex = Console.ReadLine();
            //选择语句
            //if
            if (sex == "男") {
                Console.WriteLine("你好，男士");
            } else {
                Console.WriteLine("你好，女士");
            }
            //switch
            switch (sex)
            {
                case "男":
                    Console.WriteLine("你好，男士");
                    break;
                default:
                    break;
            }

            //循环语句
            //for (初始化; 循环条件; 增减变量)
            //{
            //    循环体
            //}
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("老王");
            }

            //while (条件)
            //{
            //    循环体
            //}
            // while循环需要自己定义初始化条件，自己单独写变量增减， 而for循环是自带这些条件的。
            int wNum = 0;
            while (wNum < 5)
            {
                Console.WriteLine("老田");
                wNum++;
            }

            //先做一遍再判断
            do
            {
                Console.WriteLine("你好，老李");
            } while (wNum < 10);

            //跳转语句：continue, break, return
            //continue: 结束当前循环， break:结束最近的循环体， return:结束当前函数

            #endregion
        }
    }
}
