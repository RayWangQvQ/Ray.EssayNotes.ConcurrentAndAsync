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
    [Description("await的本质：await表达式")]
    public class Test21 : ITest
    {
        public void Run()
        {
            Console.WriteLine($"Run开始：{DateTime.Now.ToLongTimeString()}");

            Go();

            Console.WriteLine($"Run完成：{DateTime.Now.ToLongTimeString()}");
        }

        private async Task Go()
        {
            await new MyTest<int>();
        }

        public class MyTest<TResult>
        {
            public MyAwaiter<TResult> GetAwaiter()
            {
                throw new NotImplementedException();
            }
        }

        public class MyAwaiter<TResult> : INotifyCompletion
        {
            public bool IsCompleted => throw new NotImplementedException();
            public void OnCompleted(Action continuation)
            {
                throw new NotImplementedException();
            }
            public TResult GetResult()
            {
                throw new NotImplementedException();
            }
        }

        /*
         * await等待的表达式通常情况下是一个Task任务。
         * 但实际上，只要该对象拥有GetAwaiter方法，且该方法的返回值为可等待对象（awaitable object）
         * （这个对象需实现INotify-Completion.OnCompleted方法，具有返回恰当类型的GetResult方法和一个bool类型的IsCompleted属性）
         * 则编译器都可以接受。
         */
    }
}
