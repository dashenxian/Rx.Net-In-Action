using System;
using System.Reactive.Linq;
using System.Threading;
using ObserveCommon;

namespace CH11_2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var subscription = Observable
                .Interval(TimeSpan.FromSeconds(1))
                .AsWeakObservable()
                .SubscribeConsole();

            Console.WriteLine("Collecting");
            GC.Collect();
            Thread.Sleep(2000); //2 seconds

            GC.KeepAlive(subscription);
            Console.WriteLine("Done sleeping");
            Console.WriteLine("Collecting");

            subscription = null;
            GC.Collect();
            Thread.Sleep(2000); //2 seconds
            Console.WriteLine("Done sleeping");
        }
    }
}
