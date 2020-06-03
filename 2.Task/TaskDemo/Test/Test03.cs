using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Ray.Infrastructure.Test;

namespace Ray.EssayNotes.TaskDemo.Test
{
    [Description("长任务")]
    public class Test03 : ITest
    {
        public void Run()
        {
            Console.WriteLine($"哈哈哈，当前线程：{Thread.CurrentThread.ManagedThreadId}；是否来自线程池：{Thread.CurrentThread.IsThreadPoolThread}");

            Task task = Task.Factory.StartNew(Work, TaskCreationOptions.LongRunning);//这样可以避免使用线程池线程
        }

        private void Work()
        {
            Thread.Sleep(3000);
            Console.WriteLine($"嘿嘿嘿，当前线程：{Thread.CurrentThread.ManagedThreadId}；是否来自线程池：{Thread.CurrentThread.IsThreadPoolThread}");
        }

        /*
         * 默认情况下，CLR会将任务运行在线程池线程上，这种线程非常适合执行短小的计算密集的任务。
         * 在线程池上运行一个长时间执行的任务并不会造成问题；但是如果要并行运行多个长时间运行的任务（特别是会造成阻塞的任务），则会对性能造成影响。
         * 在这种情况下，相比于使用TaskCreationOptions.LongRunning而言，更好的方案是：
         * · 如果运行的是I/O密集型任务，则使用TaskCompletionSource和异步函数（asynchronous functions）通过回调函数而非使用线程实现并发性。
         * · 如果任务是计算密集型，则使用生产者/消费者队列可以控制这些任务造成的并发数量，避免出现线程和进程饥饿的问题（参见23.7节）。
         */
    }
}
