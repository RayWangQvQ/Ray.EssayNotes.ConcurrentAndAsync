using System;
using System.ComponentModel;
using System.Threading;
using Ray.Infrastructure.Test;

namespace Ray.EssayNotes.ThreadDemo.Test
{
    [Description("线程池")]
    public class Test17 : ITest
    {
        public void Run()
        {
            Console.WriteLine($"哈哈哈，当前线程：{Thread.CurrentThread.ManagedThreadId}；是否来自线程池：{Thread.CurrentThread.IsThreadPoolThread}");

            ThreadPool.QueueUserWorkItem(x => Work());
            //Task.Factory.StartNew(Work);//.NET 4.0
            //Task.Run(Work);//.NET 4.5
        }

        private void Work()
        {
            Console.WriteLine($"嘿嘿嘿，当前线程：{Thread.CurrentThread.ManagedThreadId}；是否来自线程池：{Thread.CurrentThread.IsThreadPoolThread}");
        }
    }
}
