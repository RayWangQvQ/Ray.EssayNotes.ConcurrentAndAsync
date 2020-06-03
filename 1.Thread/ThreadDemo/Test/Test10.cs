using System;
using System.ComponentModel;
using System.Threading;
using Ray.Infrastructure.Test;

namespace Ray.EssayNotes.ThreadDemo.Test
{
    [Description("线程安全：排它锁")]
    public class Test10 : ITest
    {
        private bool _isDone;
        private readonly object _locker = new object();

        public void Run()
        {
            new Thread(Go)
                .Start();

            Go();
        }

        private void Go()
        {
            lock (_locker)
            {
                if (!_isDone)
                {
                    //使用线程休眠模拟Do Something
                    Thread.Sleep(1000);

                    _isDone = true;
                    Console.WriteLine("Done");
                }
            }
        }

        /*
         * 当多个线程同时竞争一个锁时（锁可以是任意引用类型的对象，这里是_locker），只有一个线程会获取成功，此时其他线程都会进行等待（阻塞），直到锁被释放。
         * 这样，就保证了一次只有一个线程能够进入这个代码块。
         * 锁并不是万能药，其本身也存在一些问题（比如死锁）。
         */
    }
}
