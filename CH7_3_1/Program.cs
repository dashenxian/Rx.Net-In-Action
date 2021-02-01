using System;
using System.Reactive.Linq;
using System.Threading;
using ObserveCommon;

namespace CH7_3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var coldObservable = Observable
                .Interval(TimeSpan.FromSeconds(1))
                .Take(5);
            var connectableObservable = coldObservable.Publish();
            connectableObservable.SubscribeConsole("First");
            connectableObservable.SubscribeConsole("Second");

            connectableObservable.Connect();
            Thread.Sleep(2100);
            connectableObservable.SubscribeConsole("Third");
            Console.ReadKey();
        }
    }
}
