﻿using System;

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

        public static void Main2(string[] args)
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

        public static void Main(string[] args)
        {
            #region
            //方法
            string str = "我是李雷！";
            str = str.Insert(4, "吗");

            int inde = str.IndexOf("李");

            str = str.Replace("我", "我们");

            str = str.Remove(2);

            bool res = str.Contains("是");

            bool res2 = str.StartsWith("我");

            //递归
            int res3 = getFact(5);
            Console.WriteLine("{0}", res3);

            //数组

            // var类型推导
            int[] list = new int[] { 1, 2, 3, 4, 5 };
            foreach (var item in list) {
                Console.WriteLine("item: {0} \r\t", item);
            }
            var v1 = 1;
            var v2 = '1';
            var v3 = "1";

            //定义数组,Array：所有数组的父类
            Array arr1 = new int[2];
            Array arr2 = new double[3];
            // 数组的使用
            int listL = list.Length;
            Array.Sort(list);
            object obj = list.Clone();
            int[] objList = (int[])obj;
            Console.WriteLine(objList[0]);

            //二维数组
            //[行数，列数]
            int[,] twoList = new int[3, 5];
            twoList[0, 2] = 10;
            //获取行数
            int rowNum = twoList.GetLength(0);
            //获取列数
            int columNum = twoList.GetLength(1);

            //交错数组，是不规则的二维数组（表，有的行长，有的行短），交错数组的元素个数是行数。
            //定义一个交错数组
            int[][] list2;
            //创建一个有5个元素的交错数组
            list2 = new int[5][];
            //第0个元素赋值
            list2[0] = new int[3];
            //第1个元素赋值
            list2[1] = new int[7];
            //给交错数组赋值,给交错数组的第0个元素 的 第2个元设置成1
            list2[0][2] = 1;

            int tot = Add(10, 20, 30);
            int tot2 = Add(new int[]{ 10,20,30});
            Console.WriteLine("{0}{1}",tot,tot2);

            int funParam = 1;
            Fun1(funParam);
            Console.WriteLine("{0}", funParam);
            Fun2(ref funParam);
            Console.WriteLine("{0}", funParam);
            Fun3(out funParam);
            Console.WriteLine("{0}", funParam);


            #endregion
        }

        // 递归：5的阶乘
        private static int getFact(int num) {
            if (num == 1) return 1;
            return num * getFact(num - 1);
        }

        //被params修饰的参数可以传数组，也可以传多个参数，编译器内部会自动封装成数组
        private static int Add(params int[] arr) {
            int sum = 0;
            foreach(int num in arr)
            {
                sum += num;
            }
            return sum;
        }

        //函数参数：值参数， 传递的是实参变量的值
        private static void Fun1(int a)
        {
            a = 10;
        }
        //函数参数：引用参数，传递的是实参变量的内存地址，在函数内部可以直接修改外界调用的变量的值
        private static void Fun2(ref int a)
        {
            a = 20; //可以修改外界的入参， ref表示函数内可以修改函数外部的数据
        }
        //函数参数：返回参数，传递的是实参的内存地址，用于从函数内返回数据到外面
        private static void Fun3(out int a)
        {
            a = 30; 
        }
    }
}
