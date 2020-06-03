using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Ray.Infrastructure.Test;

namespace Ray.EssayNotes.TaskDemo.Test
{
    [Description("TaskCompletionSource：自己实现一个Delay")]
    public class Test12 : ITest
    {
        public void Run()
        {
            Delay(3000)
                .GetAwaiter()
                .OnCompleted(() => Console.WriteLine(77));
        }

        private Task Delay(int milliseconds)
        {
            var taskCompletionSource = new TaskCompletionSource<object>();

            var timer = new System.Timers.Timer(milliseconds)
            {
                AutoReset = false
            };
            timer.Elapsed += delegate
            {
                timer.Dispose();
                taskCompletionSource.SetResult(null);
            };

            timer.Start();

            return (Task)taskCompletionSource.Task;
        }
    }
}
