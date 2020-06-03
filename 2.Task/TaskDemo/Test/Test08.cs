using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Ray.Infrastructure.Test;

namespace Ray.EssayNotes.TaskDemo.Test
{
    [Description("使用TaskCompletionSource类创建任务")]
    public class Test08 : ITest
    {
        public void Run()
        {
            var taskCompletionSource = new TaskCompletionSource<int>();

            var thread = new Thread(() =>
             {
                 Thread.Sleep(3000);
                 taskCompletionSource.SetResult(42);
             });
            thread.IsBackground = true;
            thread.Start();

            Thread.Sleep(5000);
            Task<int> task = taskCompletionSource.Task;

            Console.WriteLine(task.Result);
        }
    }
}
