using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Ray.Infrastructure.Test;

namespace Ray.EssayNotes.TaskDemo.Test
{
    [Description("异常捕捉")]
    public class Test10 : ITest
    {
        public void Run()
        {
            try
            {
                Task<bool> task = Task.Run(Go);

                //Thread.Sleep(5000);
                task.Wait();
                //var success = task.Result;

                //Console.WriteLine(task.IsCanceled);//说明任务抛出了OperationCanceledException异常
                //Console.WriteLine(task.IsFaulted);//说明任务抛出了其他异常
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.WriteLine("Done");
        }

        private bool Go()
        {
            throw new Exception();
        }

        /*
         * 新建线程的异常不会影响主线程的运行（所以也不会被主线程捕捉到）
         * 当主线程阻塞等待新建线程结果时（Wait或Result），主线程会重新捕捉到新建线程的异常（AggregateException）
         */
    }
}
