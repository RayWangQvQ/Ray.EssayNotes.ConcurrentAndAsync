using System;
using System.ComponentModel;
using System.Threading;
using Ray.Infrastructure.Test;

namespace Ray.EssayNotes.ThreadDemo.Test
{
    [Description("使用Thread开启新线程")]
    public class Test01 : ITest
    {
        public void Run()
        {
            var thread = new Thread(PrintA);
            thread.Start();

            PrintB();
        }

        private void PrintA()
        {
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
        }
    }
}
