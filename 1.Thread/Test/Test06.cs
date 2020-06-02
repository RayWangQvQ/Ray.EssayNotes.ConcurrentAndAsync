using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;

namespace Ray.EssayNotes.AsyncAndThread.Test
{
    [Description("阻塞与自旋")]
    public class Test06 : ITest
    {
        public void Run()
        {
            var thread = new Thread(PrintA);
            thread.Start();

            PrintB();
        }

        private void PrintA()
        {
            PrintDateNow("A");
            Thread.Sleep(1000);//阻塞1秒
            PrintDateNow("A");
        }

        private void PrintB()
        {
            PrintDateNow("B");
            DateTime dateTimeout = DateTime.Now.AddMilliseconds(1000);
            while (DateTime.Now < dateTimeout) ;//利用定期循环的自旋实现“暂定”1秒，等待事件
            PrintDateNow("B");
        }

        private void PrintDateNow(string name)
        {
            Console.WriteLine($"{name}:{DateTime.Now.ToLongTimeString()}");
        }

        /*
         * I/O密集：一个操作大部分时间都花在等待事件上（如输入、输出、Console.ReadLine）
         * 计算密集：一个操作大部分时间都花在CPU计算上
         * 自旋其实是将I/O密集转换为了计算密集
         * 通常来说，自旋是非常浪费处理器时间，因为CLR和操作系统都会认为这个线程正在执行重要的运算，因此就会为其分配相应的资源。
         * 但是非常短暂的自旋在条件可以很快得到满足的场景（例如几毫秒）下是非常高效的，因为它避免了上下文切换带来的延迟和开销。
         * 阻塞并非零开销。这是因为每一个线程在存活时会占用1MB的内存，并对CLR和操作系统带来持续性的管理开销。
         * 因此，阻塞可能会给繁重的I/O密集型程序（例如要处理成百上千的并发操作）带来麻烦。
         * 所以，这些程序更适于使用回调的方式，在等待时完全解除这些线程。
         * 后面讨论异步模式将更好的解决这个问题。
         */
    }
}
