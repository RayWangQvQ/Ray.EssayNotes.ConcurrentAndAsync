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
    [Description("使用ConfigureAwait阻止大量回弹")]
    public class Test50 : ITest
    {
        public void Run()
        {
            Console.WriteLine($"Run开始");

            A();

            Console.WriteLine($"Run完成");
        }

        private async void A()
        {
            await B();
        }

        private async Task B()
        {
            for (int i = 0; i < 1000; i++)
            {
                await C().ConfigureAwait(false);
            }
        }

        private async Task C()
        {

        }
    }
}
