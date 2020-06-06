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
    [Description("FromResult")]
    public class Test40 : ITest
    {
        public void Run()
        {
            Console.WriteLine($"Run开始：{GetTimeAndThreadId}");

            Go();

            Console.WriteLine($"Run完成：{GetTimeAndThreadId}");
        }

        private Task<string> Go()
        {
            return Task.FromResult("");
        }

        private async Task PrintAsync()
        {
            Console.WriteLine("进入Print");
            Task<int> task = GetAnswerToLife();
            int result = await task;
            Console.WriteLine($"Print结束：{GetTimeAndThreadId}");
        }

        private async Task<int> GetAnswerToLife()
        {
            Console.WriteLine("进入Get");
            Task task = Task.Delay(5000);
            await task;
            int answer = 21 * 2;
            Console.WriteLine($"Get结束：{GetTimeAndThreadId}");
            return answer;
        }

        private string GetTimeAndThreadId =>
            $"{DateTime.Now.ToLongTimeString()}【{Thread.CurrentThread.ManagedThreadId}】";
    }
}
