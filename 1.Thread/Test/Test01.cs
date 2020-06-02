using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;

namespace Ray.EssayNotes.AsyncAndThread.Test
{
    [Description("使用原始Thread")]
    public class Test01 : ITest
    {
        public void Run()
        {
            var thread = new Thread(Print1);
            thread.Start();

            Print2();
        }

        private void Print1()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("A");
            }
        }

        private void Print2()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("B");
            }
        }
    }
}
