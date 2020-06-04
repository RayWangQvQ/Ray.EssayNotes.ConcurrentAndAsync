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
    [Description("继续优化：利用延续的递归调用实现顺序输出")]
    public class Test03 : ITest
    {
        public void Run()
        {
            Console.WriteLine($"Run开始：{DateTime.Now.ToLongTimeString()}");

            Task.Run(Print);

            Console.WriteLine($"Run完成：{DateTime.Now.ToLongTimeString()}");
        }

        private void Print()
        {
            PrintFrom(0, 5);
        }

        /// <summary>
        /// 利用递归循环打印结果
        /// </summary>
        /// <param name="i">起始数</param>
        /// <param name="times">循环次数</param>
        private void PrintFrom(int i, int times)
        {
            TaskAwaiter<int> awaiter = GetPrimesCountAsync(i * 1000000 + 2, 1000000)
                .GetAwaiter();

            awaiter.OnCompleted(() =>
            {
                Console.WriteLine(
                    $"{awaiter.GetResult()} primes between ... and ...");

                if (++i < times) PrintFrom(i, times);//递归，前一个任务（Task）完成才会在触发OnCompleted时去执行下一个任务
                else Console.WriteLine($"Print结束：{DateTime.Now.ToLongTimeString()}\r\n");
            });
        }

        private Task<int> GetPrimesCountAsync(int start, int count)
        {
            return Task.Run(() => ParallelEnumerable.Range(start, count)
                .Count(n => Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
        }

        /*
         * 这里输出的顺序是不对的，可以使用【延续的递归调用】解决，见下一个用例
         */
    }
}
