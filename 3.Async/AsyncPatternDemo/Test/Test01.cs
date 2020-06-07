using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Ray.Infrastructure.Test;

namespace Ray.EssayNotes.AsyncPatternDemo.Test
{
    [Description("取消操作：不考虑线程安全")]
    public class Test01 : ITest
    {
        public void Run()
        {
            CancellationToken cancellationToken = new CancellationToken();
            Foo(cancellationToken);

            Task.Run(() =>
            {
                Task.Delay(5000).Wait();
                cancellationToken.Cancel();
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

        private class CancellationToken
        {
            public bool IsCancellationRequested { get; set; }
            public void Cancel()
            {
                IsCancellationRequested = true;
            }
            public void ThrowIfCancellationRequested()
            {
                if (IsCancellationRequested)
                {
                    Console.WriteLine("已取消");
                    throw new OperationCanceledException();
                }
            }
        }
    }
}
