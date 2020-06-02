using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;

namespace Ray.EssayNotes.AsyncAndThread.Test
{
    [Description("异常捕捉")]
    public class Test11 : ITest
    {
        private bool _isDone;
        private readonly object _locker = new object();

        public void Run()
        {
            try
            {
                new Thread(Go)
                    .Start();
                //Thread.Sleep(5000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.WriteLine("Done");
        }

        private void Go()
        {
            throw null;
        }

        /*
         * 这里的try不会捕获新创建的线程中的异常
         * 原因并不是主线程已经执行到try外面（利用休眠使主线程等待，其实仍然捕获不到）
         * 可以理解为：每一个线程都能看作独立的执行路径，所以主线程里捕获不到其他线程的异常
         */
    }
}
