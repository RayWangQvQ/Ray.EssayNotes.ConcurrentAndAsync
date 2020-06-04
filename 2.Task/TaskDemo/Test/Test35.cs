using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Ray.Infrastructure.Test;

namespace Ray.EssayNotes.TaskDemo.Test
{
    [Description("Task.Delay")]
    public class Test35 : ITest
    {
        public void Run()
        {
            ThreadPool.SetMaxThreads(20, 20);
            
            var tasks = new List<Task>();
            for (var c = 0; c < 20; c++)
            {
                tasks.Add(Task.Run(() =>
                {
                    Task.Delay(3000).Wait();    //Task.Delay 也会使用线程池，线程池满的时候，会导致它无法结束
                }));
            }
            Task.WaitAll(tasks.ToArray());
        }
    }
}
