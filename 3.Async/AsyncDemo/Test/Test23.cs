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
    public class Test23 : ITest
    {
        public void Run()
        {
            Console.WriteLine($"Run开始：{DateTime.Now.ToLongTimeString()}");

            //PrintAsync();
            PrintAsync();

            Console.WriteLine($"Run完成：{DateTime.Now.ToLongTimeString()}");
        }

        private async Task PrintAsync()
        {
            await GetAnswerToLife();

            Console.WriteLine($"Print Done");
        }

        private async Task<int> GetAnswerToLife()
        {
            await Task.Delay(5000);
            int answer = 21 * 2;
            return answer;
        }
    }
}
