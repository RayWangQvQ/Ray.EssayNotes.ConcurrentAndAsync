using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Ray.Infrastructure.Test;

namespace Ray.EssayNotes.TaskDemo.Test
{
    [Description("Wait方法")]
    public class Test02 : ITest
    {
        public void Run()
        {
            Console.WriteLine($"哈哈哈，Run线程：{Thread.CurrentThread.ManagedThreadId}；是否来自线程池：{Thread.CurrentThread.IsThreadPoolThread}");

            Task task = Task.Run(Work);

            Console.WriteLine(task.IsCompleted);
            task.Wait();
            Console.WriteLine(task.IsCompleted);
        }

        private void Work()
        {
            Thread.Sleep(3000);
            Console.WriteLine($"嘿嘿嘿，Work线程：{Thread.CurrentThread.ManagedThreadId}；是否来自线程池：{Thread.CurrentThread.IsThreadPoolThread}");
        }
    }
}
