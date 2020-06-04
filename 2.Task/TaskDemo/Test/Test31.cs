using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Ray.Infrastructure.Test;

namespace Ray.EssayNotes.TaskDemo.Test
{
    [Description("TaskCompletionSource：编写自己的Task.Run()方法")]
    public class Test31 : ITest
    {
        public void Run()
        {
            Task<int> task = Run(() =>
            {
                Thread.Sleep(3000);
                return 42;
            });

            task.GetAwaiter()
                .OnCompleted(() => Console.WriteLine(task.Result));
        }

        private Task<TResult> Run<TResult>(Func<TResult> function)
        {
            var taskCompletionSource = new TaskCompletionSource<TResult>();

            var thread = new Thread(() =>
             {
                 try
                 {
                     TResult result = function();
                     taskCompletionSource.SetResult(result);
                 }
                 catch (Exception e)
                 {
                     taskCompletionSource.SetException(e);
                 }
             });
            thread.Start();

            return taskCompletionSource.Task;
        }

        /*
         * 这里和调用Task.Factory.StartNew，并传递TaskCreationOptions. LongRunning参数是等价的。
         * 它们都会请求一个非线程池线程。
         */
    }
}
