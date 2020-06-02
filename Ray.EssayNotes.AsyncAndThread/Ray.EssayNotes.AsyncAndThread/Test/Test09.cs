using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;

namespace Ray.EssayNotes.AsyncAndThread.Test
{
    [Description("内存共享：线程不安全")]
    public class Test09 : ITest
    {
        private bool _isDone;
        public void Run()
        {
            new Thread(Go)
                .Start();

            Go();
        }

        private void Go()
        {
            if (!_isDone)
            {
                //使用线程休眠模拟Do Something
                Thread.Sleep(1000);

                _isDone = true;
                Console.WriteLine("Done");
            }
        }

        /*
         * 这里因为在_isDone被某个线程设置为true之前，主线程和新建线程先后都进入了if语句，
         * 所以导致打印了2次Done，这与我们想要实现的结果并不符合，
         * 即共享状态可能会引起线程不安全问题。
         * 解决方法是可使用锁机制来解决
         * 但是，最好的方法是避免使用共享状态（比如后面要说的使用异步编程）
         */
    }
}
