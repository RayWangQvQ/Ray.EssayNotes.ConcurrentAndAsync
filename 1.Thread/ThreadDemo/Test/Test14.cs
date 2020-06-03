using System;
using System.ComponentModel;
using System.Threading;
using Ray.Infrastructure.Test;

namespace Ray.EssayNotes.ThreadDemo.Test
{
    [Description("线程间的信号发送")]
    public class Test14 : ITest
    {
        private ManualResetEvent _manualResetEvent = new ManualResetEvent(false);

        public void Run()
        {
            var thread = new Thread(PrintA);
            thread.Start();

            PrintB();
        }

        private void PrintA()
        {
            _manualResetEvent.WaitOne();//这儿会阻塞当前线程，直到_manualResetEvent被Set

            for (int i = 0; i < 1000; i++)
            {
                Console.Write("A");
            }
        }

        private void PrintB()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("B");
            }
            _manualResetEvent.Set();//设置信号事件的状态，通知所有阻塞的线程开始运行
        }

        /*
         * 提升一个线程的优先级需要慎重，因为其他线程的执行时间就可能减少而处于（饥饿）状态。
         * 如果是希望一个线程比【其他进程】中的线程有更高的优先级，那么还必须使用System.Diagnostics命名空间下的Process类来提高进程本身的优先级
         */
    }
}
