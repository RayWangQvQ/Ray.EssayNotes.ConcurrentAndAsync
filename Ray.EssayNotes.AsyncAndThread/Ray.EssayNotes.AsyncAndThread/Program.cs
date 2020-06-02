using System;
using Ray.EssayNotes.AsyncAndThread.Test;
using Ray.Infrastructure.Extensions.Json;

namespace Ray.EssayNotes.AsyncAndThread
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            while (true)
            {
                Console.WriteLine("\r\n请输入测试用例：");
                Console.WriteLine(TestFactory.Selections.AsFormatJsonStr());

                string num = Console.ReadLine();
                if (num.IsNullOrWhiteSpace()) continue;

                ITest test = TestFactory.Create(num);
                test.Run();
            }
        }
    }
}
