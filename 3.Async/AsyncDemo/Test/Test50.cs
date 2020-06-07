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
    [Description("FromResult")]
    public class Test50 : ITest
    {
        public void Run()
        {
            Console.WriteLine($"Run开始");

            Go();

            Console.WriteLine($"Run完成");
        }

        private Task<string> Go()
        {
            return Task.FromResult("abc");
        }
    }
}
