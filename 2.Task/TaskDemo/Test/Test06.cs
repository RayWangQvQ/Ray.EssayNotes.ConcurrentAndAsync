using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Ray.Infrastructure.Test;

namespace Ray.EssayNotes.TaskDemo.Test
{
    [Description("延续，TaskAwaiter实现")]
    public class Test06 : ITest
    {
        public void Run()
        {
            Task<int> task = Task.Run(Go);

            TaskAwaiter<int> taskAwaiter = task.GetAwaiter();

            //告诉先导任务执行完毕后，接着执行这里的委托：
            taskAwaiter.OnCompleted(() =>
            {
                int result = taskAwaiter.GetResult();
                //int result = task.Result;//两种获取任务执行结果的方法都行，这里可能会捕捉到先导任务的异常（不是包装后的AggregateException，而是原始异常，因为当前代码就处于先导任务的线程中）

                Console.WriteLine(result);
                Console.WriteLine($"OnCompleted线程：{Thread.CurrentThread.ManagedThreadId}");
            });

            Console.WriteLine("Done");
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
         * Awaiter直译为“等待者”
         * 这里任务完成后，会接着去执行OnCompleted方法内指定的委托
         * 且通常情况下，延续任务仍会在先导任务所在线程上运行，从而避免不必要的开销
         */
    }
}
