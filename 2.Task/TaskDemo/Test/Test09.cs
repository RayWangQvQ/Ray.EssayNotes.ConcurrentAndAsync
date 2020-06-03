using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Ray.Infrastructure.Test;

namespace Ray.EssayNotes.TaskDemo.Test
{
    [Description("使用TaskCompletionSource类创建一个不绑定线程的任务")]
    public class Test09 : ITest
    {
        public void Run()
        {
            TaskAwaiter<int> awaiter = GetAnswerToLife().GetAwaiter();

            awaiter.OnCompleted(() => Console.WriteLine(awaiter.GetResult()));
        }

        private Task<int> GetAnswerToLife()
        {
            var taskCompletionSource = new TaskCompletionSource<int>();

            var timer = new System.Timers.Timer(5000)
            {
                AutoReset = false
            };
            timer.Elapsed += delegate
            {
                timer.Dispose();
                taskCompletionSource.SetResult(42);
            };

            timer.Start();

            return taskCompletionSource.Task;
        }
    }
}
