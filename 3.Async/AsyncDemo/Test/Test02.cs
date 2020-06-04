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
    [Description("改为细粒度并发")]
    public class Test02 : ITest
    {
        public void Run()
        {
            Console.WriteLine($"Run开始：{DateTime.Now.ToLongTimeString()}");

            Task.Run(Print);

            Console.WriteLine($"Run完成：{DateTime.Now.ToLongTimeString()}");
        }

        private void Print()
        {
            for (int i = 0; i < 5; i++)
            {
                TaskAwaiter<int> awaiter = GetPrimesCountAsync(i * 1000000 + 2, 1000000)
                    .GetAwaiter();

                awaiter.OnCompleted(() =>
                {
                    Console.Write(
                        $"{awaiter.GetResult()} primes between ... and ...");//这里已经拿不到i了，前面内存共享讲过了

                    Console.Write($"  {DateTime.Now.ToLongTimeString()}\r\n");
                });
            }
            Console.WriteLine($"Print循环完成：{DateTime.Now.ToLongTimeString()}");
        }

        /// <summary>
        /// 改为异步方法（不用等到返回）
        /// </summary>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
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
