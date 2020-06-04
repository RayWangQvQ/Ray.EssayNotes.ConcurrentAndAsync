using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Ray.Infrastructure.Test;

namespace Ray.EssayNotes.TaskDemo.Test
{
    [Description("TaskCompletionSource：创建任务")]
    public class Test30 : ITest
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

        /*
         * TaskCompletionSource可以创建一个任务，
         * 但是这种任务并非那种需要执行启动操作并在随后停止的任务；而是在操作结束或出错时手动创建的“附属”任务。
         * 因为其Task属性返回一个Task对象，所以我们可以等待这个对象，也可以和其他的所有任务一样，在其上附加延续。
         */
    }
}
