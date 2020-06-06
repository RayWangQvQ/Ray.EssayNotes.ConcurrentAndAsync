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
    [Description("异步函数返回值")]
    public class Test30 : ITest
    {
        public void Run()
        {
            Console.WriteLine($"Run开始：{DateTime.Now.ToLongTimeString()}");

            A();
            B();

            Console.WriteLine($"Run完成：{DateTime.Now.ToLongTimeString()}");
        }

        private async Task<bool> A()
        {
            await Task.Delay(1000);

            return true;//这里并不是返回Task<bool>，而是bool
        }

        private Task<bool> B()
        {
            //return true;//这里编译不通过
            return Task.FromResult(true);
        }
    }
}
