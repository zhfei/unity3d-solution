using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo0
{
    class MainClass
    {
        public static void Main(string[] args)
        {
             
            int num; // 变量声明是在内存中开辟一块内存空间，名称叫做num
            num = 20; // 赋值是往这个内存空间中赋值
            Console.WriteLine(num);

            Console.WriteLine("请输入枪的名称：");
            string gunName = Console.ReadLine();
            Console.WriteLine("请输入弹夹容量：");
            string zidanRongLiang = Console.ReadLine();
            Console.WriteLine("请输入当前弹夹内子弹数量：");
            string zidanShuLiang = Console.ReadLine();
            Console.WriteLine("请输入剩余子弹数量：");
            string zidanShuLiangShengYu = Console.ReadLine();
            Console.WriteLine("请输入枪的名称：" + gunName + "请输入弹夹容量：" + zidanRongLiang);
        }
    }
}
