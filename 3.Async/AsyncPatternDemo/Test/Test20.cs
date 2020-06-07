using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Ray.Infrastructure.Test;

namespace Ray.EssayNotes.AsyncPatternDemo.Test
{
    [Description("进度报告：利用传入委托自己实现")]
    public class Test20 : ITest
    {
        public void Run()
        {
            Action<int> onProgressPerChanged = i => Console.WriteLine($"{i}%");
            Foo(onProgressPerChanged);
        }

        private async Task Foo(Action<int> onProgressPerChanged)
        {
            for (int i = 1; i < 11; i++)
            {
                await Task.Delay(1000);
                onProgressPerChanged(i * 10);
            }
        }
    }
}
