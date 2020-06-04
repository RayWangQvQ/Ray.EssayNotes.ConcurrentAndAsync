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
    [Description("使用async和await关键字一步到位")]
    public class Test10 : ITest
    {
        public void Run()
        {
            Console.WriteLine($"Run开始：{DateTime.Now.ToLongTimeString()}");

            PrintAsync();
            /*
             * 调用异步方法，并不意味着会立即向下执行
             * 异步是指该方法内部可能存在需要长时操作的工作，只有遇到改工作的时候，才会异步，即返回到当前位置，继续向下执行
             * 也就是，执行到PrintAsync时会进入方法继续执行，只有遇到await时，才会立即返回，接着向下异步地执行
             */

            Console.WriteLine($"Run完成：{DateTime.Now.ToLongTimeString()}");
        }

        private async Task PrintAsync()
        {
            for (int i = 0; i < 5; i++)
            {
                int count = await GetPrimesCountAsync(i * 1000000 + 2, 1000000);

                Console.Write(
                    $"{count} primes between {i * 1000000} and {(i + 1) * 1000000 - 1}");

                Console.Write($"  {DateTime.Now.ToLongTimeString()}\r\n");
            }
            Console.WriteLine($"Print循环完成：{DateTime.Now.ToLongTimeString()}");
        }

        private Task<int> GetPrimesCountAsync(int start, int count)
        {
            return Task.Run(() => ParallelEnumerable.Range(start, count)
                .Count(n => Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
        }
    }
}
