using System;

namespace Day02
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string gunName = "AK 47";
            string gunCap = "300";

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

        }
    }
}
