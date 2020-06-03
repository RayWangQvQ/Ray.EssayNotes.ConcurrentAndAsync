using System;
using Ray.Infrastructure.Extensions.Json;
using Ray.Infrastructure.Test;

namespace Ray.EssayNotes.TaskDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var factory = new TestFactory();
            while (true)
            {
                Console.WriteLine("\r\n请输入测试用例：");
                Console.WriteLine(factory.Selections.AsFormatJsonStr());
                var num = Console.ReadLine();
                ITest test = factory.Create(num);
                test.Run();
            }
        }
    }
}
