using System;

namespace Ninja.Tmp1.FrontGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var routerOptions = Ninja.Tmp1.Api.RouterConfiguration.Options();
            /*
                        var allMessages = Ninja.Tmp1.AssemblyInfo.Assembly
                            .GetTypes()
                            .Where(t => typeof(IMessage<T>).IsAssignableFrom(t) && !t.IsAbstract && !t.IsInterface)
                            .ToDictionary(t =>
            */
        }
    }
}
