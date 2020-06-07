using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Ray.Infrastructure.Test;

namespace Ray.EssayNotes.AsyncPatternDemo.Test
{
    [Description("取消操作：线程安全的CancellationTokenSource")]
    public class Test10 : ITest
    {
        public void Run()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            Foo(cancellationTokenSource.Token);

            Task.Run(() =>
            {
                Task.Delay(5000).Wait();
                cancellationTokenSource.Cancel();
            });
        }

        private async Task Foo(CancellationToken cancellationToken)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
                await Task.Delay(1000);
                cancellationToken.ThrowIfCancellationRequested();
            }
        }
    }
}
