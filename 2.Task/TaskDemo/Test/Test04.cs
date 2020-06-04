using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Ray.Infrastructure.Test;

namespace Ray.EssayNotes.TaskDemo.Test
{
    [Description("返回值")]
    public class Test04 : ITest
    {
        public void Run()
        {
            Console.WriteLine($"哈哈哈，Run线程：{Thread.CurrentThread.ManagedThreadId}；是否来自线程池：{Thread.CurrentThread.IsThreadPoolThread}");

            Task<bool> task = Task.Run(Work);
            bool success = task.Result;//如果任务还未执行完毕，调用Result属性会阻塞当前线程，直至任务结束
            Console.WriteLine($"任务结果：{success}");
        }

        private bool Work()
        {
            Thread.Sleep(3000);
            Console.WriteLine($"嘿嘿嘿，Work线程：{Thread.CurrentThread.ManagedThreadId}；是否来自线程池：{Thread.CurrentThread.IsThreadPoolThread}");
            return true;
        }

        /*
         * 可以将Task<TResult> 理解为一个“未来值”，它封装了Result并将在之后生效。
         * 有趣的是，当Task和Task<TResult>第一次出现在的CTP时，后者的名称是Future<TResult>。
         */
    }
}
