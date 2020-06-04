using System;
using System.ComponentModel;
using System.Threading;
using Ray.Infrastructure.Test;

namespace Ray.EssayNotes.ThreadDemo.Test
{
    [Description("使用Join等待线程执行结束")]
    public class Test03 : ITest
    {
        public void Run()
        {
            var thread = new Thread(PrintA);
            thread.Start();
            thread.Join();
            //bool isTimeOut = thread.Join(TimeSpan.FromMinutes(1));//join还可以指定一个过期时间

            PrintB();
        }

        private void PrintA()
        {
            Console.WriteLine($"PrintA所在线程：{Thread.CurrentThread.ManagedThreadId}");
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("A");
            }
        }

        private void PrintB()
        {
            Console.WriteLine($"PrintB所在线程：{Thread.CurrentThread.ManagedThreadId}");
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("B");
            }
        }

        /*
         * join原意为“汇合”，即汇合到主线程的意思，执行时会阻塞当前线程，等待开启的thread执行结束后再继续执行主线程
         * 阻塞：线程暂停执行，且不再占用处理器时间片
         */
    }
}
