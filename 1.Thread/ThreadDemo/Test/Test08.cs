using System;
using System.ComponentModel;
using System.Threading;
using Ray.Infrastructure.Test;

namespace Ray.EssayNotes.ThreadDemo.Test
{
    [Description("内存共享：拥有同一个对象的引用")]
    public class Test08 : ITest
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
                _isDone = true;
                Console.WriteLine("Done");
            }
        }

        /*
         * 这里只会执行一次，因为两个线程对_isDone是共享的（但是这里是线程不安全的，有可能被执行两次，下一个用例解释）
         * 静态字段也是实现共享的一种常用方法
         */
    }
}
