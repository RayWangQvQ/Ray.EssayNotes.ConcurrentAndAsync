using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Ray.Infrastructure.Test;

namespace Ray.EssayNotes.AsyncPatternDemo.Test
{
    [Description("进度报告：IProgress")]
    public class Test21 : ITest
    {
        public void Run()
        {
            IProgress<int> progress = new Progress<int>(x => Console.WriteLine($"{x}%"));
            Foo(progress);
        }

        private async Task Foo(IProgress<int> progress)
        {
            for (int i = 1; i < 11; i++)
            {
                await Task.Delay(1000);
                progress.Report(i * 10);
            }
        }
    }
}
