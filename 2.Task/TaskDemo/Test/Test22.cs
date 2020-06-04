using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Ray.Infrastructure.Test;

namespace Ray.EssayNotes.TaskDemo.Test
{
    [Description("延续：ContinueWith实现")]
    public class Test22 : ITest
    {
        public void Run()
        {
            Task<int> task = Task.Run(Go);

            Task continueTask = task.ContinueWith(x =>
             {
                 int result = x.Result;
                 Console.WriteLine(result);
                 Console.WriteLine($"延续线程：{Thread.CurrentThread.ManagedThreadId}");
             });

            continueTask.ContinueWith(x =>
            {
                Console.WriteLine($"延续的延续线程：{Thread.CurrentThread.ManagedThreadId}");
            });

            Console.WriteLine("Run结束");
        }

        /// <summary>
        /// 计算2到3000000之间有多少个素数
        /// </summary>
        /// <returns></returns>
        private int Go()
        {
            Console.WriteLine($"Go线程：{Thread.CurrentThread.ManagedThreadId}");
            int count = Enumerable.Range(2, 3000000)
                .Count(x =>
                    Enumerable.Range(2, (int)Math.Sqrt(x) - 1)
                        .All(i => x % i > 0));
            return count;
        }

        /*
         * ContinueWith与OnCompleted相同，都可以指定一个委托，让任务结束后执行
         * 不同的是：
         * 1.ContinueWith返回一个Task，这使其可以连续的添加延续操作；
         * 2.ContinueWith捕获到的是AggregateException异常；
         * 3.ContinueWith会请求线程池，所以通常不会和先导任务使用同一个线程，如要指定则需使用TaskContinuationOptions.ExecuteSynchronously；
         * 4.因为3的原因，所以ContinueWith也不会自动捕获同步上线文，所以如果需要将延续封送到UI应用程序上还需要书写额外的代码；
         * 5.ContinueWith更适用于并行编程场景
         */
    }
}
