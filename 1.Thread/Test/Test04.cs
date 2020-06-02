using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;

namespace Ray.EssayNotes.AsyncAndThread.Test
{
    [Description("原始Thread：使用Sleep命令当前线程休眠(阻塞)")]
    public class Test04 : ITest
    {
        public void Run()
        {
            var thread = new Thread(PrintA) { Name = "测试线程" };
            thread.Start();
            //thread.Join();

            PrintB();
        }

        private void PrintA()
        {
            Console.WriteLine($"PrintA所在线程：{Thread.CurrentThread.ManagedThreadId}({Thread.CurrentThread.Name})");
            Thread.Sleep(2000);
            //Thread.Sleep(0);
            Console.WriteLine($"PrintA所在线程：{Thread.CurrentThread.ManagedThreadId}({Thread.CurrentThread.Name})");
        }

        private void PrintB()
        {
            Console.WriteLine($"PrintB所在线程：{Thread.CurrentThread.ManagedThreadId}");
        }

        /*
         * Sleep实际会使线程阻塞
         * 阻塞：线程暂停执行，且不再占用处理器时间片
         */
    }
}
