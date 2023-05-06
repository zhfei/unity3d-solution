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
        }
    }
}
