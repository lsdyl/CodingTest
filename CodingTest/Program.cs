using System;

namespace CodingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("主函数接收参数如下：");
            for (int i = 0; i < args.Length; i++)
            {
                Console.Write($"参数{i}：");
                Console.WriteLine(args[i]);
            }
        }
    }
}
