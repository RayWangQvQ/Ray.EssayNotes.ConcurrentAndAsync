using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Ray.Infrastructure.Test;

namespace Ray.EssayNotes.AsyncDemo.Test
{
    [Description("继续细粒度：将Print方法本身也改为异步方法")]
    public class Test04 : ITest
    {
        public void Run()
        {
            Console.WriteLine($"Run开始：{DateTime.Now.ToLongTimeString()}");

            PrintAsync();
            /*
             * 调用异步方法，该方法表示其内部存在需要较长时间执行的工作，
             * 而该工作将以异步的方式执行，我们不需要在此刻同步的等待结果
             */

            Console.WriteLine($"Run完成：{DateTime.Now.ToLongTimeString()}");
        }

        private Task PrintAsync()
        {
            var machine = new PrimesStateMachine();
            machine.PrintFrom(0, 5);
            return machine.Task;
        }

        /// <summary>
        /// 状态机
        /// </summary>
        class PrimesStateMachine
        {
            TaskCompletionSource<object> taskCompletionSource = new TaskCompletionSource<object>();
            public Task Task => taskCompletionSource.Task;

            public void PrintFrom(int i, int times)
            {
                TaskAwaiter<int> awaiter = GetPrimesCountAsync(i * 1000000 + 2, 1000000)
                    .GetAwaiter();

                awaiter.OnCompleted(() =>
                {
                    Console.WriteLine(
                        $"{awaiter.GetResult()} primes between ... and ...");

                    if (++i < times) PrintFrom(i, times);
                    else Console.WriteLine($"Print结束：{DateTime.Now.ToLongTimeString()}\r\n");
                });
            }

            private Task<int> GetPrimesCountAsync(int start, int count)
            {
                return Task.Run(() => ParallelEnumerable.Range(start, count)
                    .Count(n => Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
            }
        }


        /*
         * 这里输出的顺序是不对的，可以使用【延续的递归调用】解决，见下一个用例
         */
    }
}
