using System;
using System.ComponentModel;
using System.Threading;
using Ray.Infrastructure.Test;

namespace Ray.EssayNotes.ThreadDemo.Test
{
    [Description("使用Yield或Sleep(0)让出线程对CPU的占用")]
    public class Test05 : ITest
    {
        public void Run()
        {
            var thread = new Thread(PrintA);
            thread.Start();

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

            Console.WriteLine("让出线程对CPU的占用");
            Thread.Yield();
            //Thread.Sleep(0);

            for (int i = 0; i < 1000; i++)
            {
                Console.Write("B");
            }
        }
    }
}
