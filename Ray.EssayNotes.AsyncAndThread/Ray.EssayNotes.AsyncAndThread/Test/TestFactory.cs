using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Ray.EssayNotes.AsyncAndThread.Test
{
    public class TestFactory
    {
        public static ITest Create(string num)
            => Assembly.GetExecutingAssembly().
                CreateInstance($"Ray.EssayNotes.AsyncAndThread.Test.Test{num}")
                .As<ITest>();

        public static Dictionary<string, string> Selections
            => Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(x => x.IsClass
                            && !x.IsAbstract
                            && !x.IsInterface
                            && typeof(ITest).IsAssignableFrom(x))
                .ToDictionary(x => x.Name.Substring(x.Name.Length - 2),
                    x => x.GetCustomAttribute(typeof(DescriptionAttribute))?.As<DescriptionAttribute>().Description);

    }
}
