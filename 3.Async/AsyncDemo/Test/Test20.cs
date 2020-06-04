using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ray.Infrastructure.Test;

namespace Ray.EssayNotes.AsyncDemo.Test
{
    [Description("await的本质")]
    public class Test20 : ITest
    {
        public void Run()
        {
            Console.WriteLine($"Run开始：{DateTime.Now.ToLongTimeString()}");

            //PrintAsync();
            Print2Async();

            Console.WriteLine($"Run完成：{DateTime.Now.ToLongTimeString()}");
        }

        private async Task PrintAsync()
        {
            int result = await WorkAsync();

            Console.WriteLine($"Print结果：{result}  {DateTime.Now.ToLongTimeString()}");
            Thread.Sleep(3000);
        }

        private void Print2Async()
        {
            TaskAwaiter<int> awaiter = WorkAsync().GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                int result = awaiter.GetResult();
                Console.WriteLine($"Print结果：{result}  {DateTime.Now.ToLongTimeString()}");
                Thread.Sleep(3000);
            });
        }

        private Task<int> WorkAsync()
        {
            return Task.Run(() =>
            {
                Thread.Sleep(3000);
                return 7;
            });
        }
    }
}
