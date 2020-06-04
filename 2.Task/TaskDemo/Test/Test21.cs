using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Ray.Infrastructure.Test;

namespace Ray.EssayNotes.TaskDemo.Test
{
    [Description("延续，TaskAwaiter实现：使用ConfigureAwait配置延续是否捕获上下文")]
    public class Test21 : ITest
    {
        public void Run()
        {
            Task<int> task = Task.Run(Go);

            ConfiguredTaskAwaitable<int>.ConfiguredTaskAwaiter taskAwaiter =
                task.ConfigureAwait(false)
                    .GetAwaiter();

            /*
             * 如果提供了同步上下文，则OnCompleted就会自动捕获它，并将延续提交到这个上下文中。
             * 这对于富客户端应用程序来说非常重要，因为这意味着将延续放回UI线程中。
             * 但如果编写的是一个程序库，则通常不希望出现上述行为。此时可以使用ConfigureAwait(false)指定其不自动捕捉上下文
             * 即延续任务通常仍会在先导任务所在线程上运行
             */

            taskAwaiter.OnCompleted(() =>
            {
                int result = taskAwaiter.GetResult();

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
    }
}
