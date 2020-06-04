using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Ray.Infrastructure.Test;

namespace Ray.EssayNotes.TaskDemo.Test
{
    [Description("Task.Delay")]
    public class Test34 : ITest
    {
        public void Run()
        {
            Task.Delay(3000);

            Task.Delay(3000)
                .GetAwaiter()
                .OnCompleted(() => Console.WriteLine("哈哈哈"));

            Task.Delay(3000)
                .ContinueWith(x => Console.WriteLine("嘿嘿嘿"));
        }
    }
}
