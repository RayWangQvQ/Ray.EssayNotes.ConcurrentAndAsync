﻿using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Ray.Infrastructure.Test;

namespace Ray.EssayNotes.TaskDemo.Test
{
    [Description("延续：TaskAwaiter")]
    public class Test06 : ITest
    {
        public void Run()
        {
            Task<int> task = Task.Run(Go);

            TaskAwaiter<int> taskAwaiter = task.GetAwaiter();
            //ConfiguredTaskAwaitable<int>.ConfiguredTaskAwaiter taskAwaiter = task.ConfigureAwait(false).GetAwaiter();//todo

            taskAwaiter.OnCompleted(() =>
            {
                int result = taskAwaiter.GetResult();
                Console.WriteLine(result);
                Console.WriteLine($"当前线程：{Thread.CurrentThread.ManagedThreadId}");
            });

            Console.WriteLine("Done");
        }

        /// <summary>
        /// 计算2到3000000之间有多少个素数
        /// </summary>
        /// <returns></returns>
        private int Go()
        {
            int count = Enumerable.Range(2, 3000000)
                .Count(x =>
                    Enumerable.Range(2, (int)Math.Sqrt(x) - 1)
                        .All(i => x % i > 0));
            return count;
        }
    }
}
