using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ray.Infrastructure.Test;

namespace Ray.EssayNotes.AsyncDemo.Test
{
    [Description("粗粒度并发")]
    public class Test01 : ITest
    {
        public void Run()
        {
            Console.WriteLine($"Run开始：{DateTime.Now.ToLongTimeString()}");

            //DisplayPrimeCounts();
            Task.Run(Print);

            Console.WriteLine($"Run完成：{DateTime.Now.ToLongTimeString()}");
        }

        private void Print()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(
                    $"{GetPrimesCount(i * 1000000 + 2, 1000000)} primes between {i * 1000000} and {(i + 1) * 1000000 - 1}");
            }
            Console.WriteLine($"Print循环完成：{DateTime.Now.ToLongTimeString()}");
        }

        private int GetPrimesCount(int start, int count)
        {
            return ParallelEnumerable.Range(start, count)
                .Count(n => Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0));
        }
    }
}
