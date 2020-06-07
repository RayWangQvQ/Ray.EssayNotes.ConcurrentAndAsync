﻿using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Ray.Infrastructure.Test;

namespace Ray.EssayNotes.AsyncPatternDemo.Test
{
    [Description("任务组合器：WhenAny")]
    public class Test30 : ITest
    {
        public async void Run()
        {
            Task<int> winningTask = await Task.WhenAny(Delay1(), Delay2(), Delay3());
            Console.WriteLine("Run Done");
            //Console.WriteLine(winningTask.Result);
            Console.WriteLine(await winningTask);
        }

        private async Task<int> Delay1()
        {
            await Task.Delay(1000);
            Console.WriteLine("Delay1");
            return 1;
        }

        private async Task<int> Delay2()
        {
            await Task.Delay(1000);
            Console.WriteLine("Delay2");
            return 2;
        }

        private async Task<int> Delay3()
        {
            await Task.Delay(1000);
            Console.WriteLine("Delay3");
            return 3;
        }
    }
}
