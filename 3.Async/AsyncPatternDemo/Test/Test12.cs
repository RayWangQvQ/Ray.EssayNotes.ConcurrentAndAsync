using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Ray.Infrastructure.Test;

namespace Ray.EssayNotes.AsyncPatternDemo.Test
{
    [Description("取消操作：生成令牌时设置自动取消时间")]
    public class Test12 : ITest
    {
        public void Run()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(5000);
            Foo(cancellationTokenSource.Token);
        }

        private async Task Foo(CancellationToken cancellationToken)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
                await Task.Delay(1000, cancellationToken);//Delay方法支持传入取消令牌，这样就不用自己判断自己throw了
            }
        }
    }
}
