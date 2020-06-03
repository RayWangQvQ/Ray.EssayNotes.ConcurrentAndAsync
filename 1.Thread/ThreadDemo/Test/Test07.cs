using System;
using System.ComponentModel;
using System.Threading;
using Ray.Infrastructure.Test;

namespace Ray.EssayNotes.ThreadDemo.Test
{
    [Description("内存共享：栈")]
    public class Test07 : ITest
    {
        public void Run()
        {
            new Thread(Go)
                .Start();

            Go();
        }

        private void Go()
        {
            //定义并使用了一个局部变量i
            for (int i = 0; i < 5; i++)
            {
                Console.Write(i);
            }
        }

        /*
         * CLR为每一个线程分配了独立的内存栈，从而保证了局部变量的隔离
         */
    }
}
