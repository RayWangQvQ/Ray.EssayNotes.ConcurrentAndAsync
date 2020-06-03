using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Ray.Infrastructure.Test;

namespace Ray.EssayNotes.TaskDemo.Test
{
    [Description("启动任务")]
    public class Test01 : ITest
    {
        public void Run()
        {
            Console.WriteLine($"哈哈哈，当前线程：{Thread.CurrentThread.ManagedThreadId}；是否来自线程池：{Thread.CurrentThread.IsThreadPoolThread}");

            Task.Factory.StartNew(Work);//.NET 4.0
            Task.Run(Work);//.NET 4.5
        }

        private void Work()
        {
            Console.WriteLine($"嘿嘿嘿，当前线程：{Thread.CurrentThread.ManagedThreadId}；是否来自线程池：{Thread.CurrentThread.IsThreadPoolThread}");
        }
    }
}
