using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;

namespace Ray.EssayNotes.AsyncAndThread.Test
{
    [Description("后台线程")]
    public class Test12 : ITest
    {
        public void Run()
        {
            try
            {
                new Thread(Go)
                {
                    IsBackground = true
                }
                    .Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.WriteLine("Done");
        }

        private void Go()
        {
            //do something
        }

        /*
         * 显式创建的线程默认都是前台线程（Foreground thread）
         * 只要有一个前台线程还在运行，应用程序就仍然保持运行状态。
         * 而后台线程（background thread）则不一样。应用程序不会考虑后台线程。
         * 当所有前台线程结束时，应用程序就会停止，且所有运行的后台线程也会随之终止。
         * （这里不好写sample，就没写）
         */
    }
}
