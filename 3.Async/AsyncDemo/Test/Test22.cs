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
    public class Test22 : ITest
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
            await PrintAnswerToLife();
            //await PrintAnswerToLife2();

            Console.WriteLine($"Print Done");
        }

        private async Task PrintAnswerToLife()
        {
            await Task.Delay(5000);
            int answer = "TheAnswerToLifeTheUniverseAndEverythingIs".Length;
            Console.WriteLine(answer);
        }

        private Task PrintAnswerToLife2()
        {
            var taskCompletionSource = new TaskCompletionSource<object>();
            TaskAwaiter awaiter = Task.Delay(5000).GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                try
                {
                    awaiter.GetResult();
                    int answer = "TheAnswerToLifeTheUniverseAndEverythingIs".Length;
                    Console.WriteLine(answer);
                    taskCompletionSource.SetResult(null);
                }
                catch (Exception ex)
                {
                    taskCompletionSource.SetException(ex);
                }
            });
            return taskCompletionSource.Task;
        }
    }
}
