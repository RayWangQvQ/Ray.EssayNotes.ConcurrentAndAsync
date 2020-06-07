using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Ray.Infrastructure.Test;

namespace Ray.EssayNotes.AsyncPatternDemo.Test
{
    [Description("取消操作：令牌注册回调事件，被删除时触发")]
    public class Test13 : ITest
    {
        public void Run()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(5000);
            cancellationTokenSource.Token.Register(() => Console.WriteLine("令牌被删除了"));//注册一个委托

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
