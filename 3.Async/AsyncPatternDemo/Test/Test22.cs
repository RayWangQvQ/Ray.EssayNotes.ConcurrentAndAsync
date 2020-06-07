using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Ray.Infrastructure.Test;

namespace Ray.EssayNotes.AsyncPatternDemo.Test
{
    [Description("进度报告：Progress的ProgressChanged事件")]
    public class Test22 : ITest
    {
        public void Run()
        {
            var progress = new Progress<int>();
            //todo
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
