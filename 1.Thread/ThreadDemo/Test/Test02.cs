using System;
using System.ComponentModel;
using System.Threading;
using Ray.Infrastructure.Test;

namespace Ray.EssayNotes.ThreadDemo.Test
{
    [Description("打印线程Id及名称")]
    public class Test02 : ITest
    {
        public void Run()
        {
            Thread.CurrentThread.Name = "主线程";
            Console.WriteLine($"Run所在线程：{Thread.CurrentThread.ManagedThreadId}（{Thread.CurrentThread.Name}）");

            var thread = new Thread(PrintA) { Name = "新线程" };
            thread.Start();

            PrintB();
        }

        private void PrintA()
        {
            Console.WriteLine($"PrintA所在线程：{Thread.CurrentThread.ManagedThreadId}（{Thread.CurrentThread.Name}）");
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("A");
            }
        }

        private void PrintB()
        {
            Console.WriteLine($"PrintB所在线程：{Thread.CurrentThread.ManagedThreadId}（{Thread.CurrentThread.Name}）");
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("B");
            }
        }

        /*
         * vs调试时，可以点击调式->窗口->线程，打开线程窗口查看当前运行的线程
         */
    }
}
