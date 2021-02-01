using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
using ObserveCommon;

namespace CH7_3_3
{
    class Program
    {
        static void Main(string[] args)
        {
            //int i = 0;
            //var numbers = Observable
            //    .Range(1, 5)
            //    .Select(_=>i++);
            ////numbers.SubscribeConsole();
            ////var zipd = numbers.Zip(numbers, (a, b) => a + b)
            ////    .SubscribeConsole();
            //var publishZip = numbers.Publish(publish => publish.Zip(publish, (a, b) => a + b))
            //    .SubscribeConsole();

            var coldObservable = Observable
                .Interval(TimeSpan.FromSeconds(1));

            var connectableObservable = coldObservable.Publish();
            connectableObservable.SubscribeConsole("First");
            connectableObservable.SubscribeConsole("Second");
            connectableObservable.Connect();
            Thread.Sleep(3000);

            connectableObservable.SubscribeConsole("Third");

            var coldConnectableObservable = connectableObservable.Replay();
            coldConnectableObservable.Connect();
            Thread.Sleep(3000);
            coldConnectableObservable.SubscribeConsole("Foce");
            Console.ReadKey();

            //connectableObservable.Throttle()
            //var list = new List<int> { };
            //list.Distinct()
        }
    }
}
