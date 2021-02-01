using System;
using System.Reactive.Linq;
using ObserveCommon;

namespace CH6_2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Observable.Interval(TimeSpan.FromSeconds(1))
            //    .Timestamp()
            //    .TakeUntil(DateTimeOffset.Now.AddSeconds(5))
            //    .SubscribeConsole();
            //Console.ReadKey();

            Observable.Timer(DateTimeOffset.Now, TimeSpan.FromSeconds(1))
                .Select(i => DateTimeOffset.Now)
                .TakeUntil(DateTimeOffset.Now.AddSeconds(5))
                .SubscribeConsole();
            Console.ReadKey();
        }
    }
}
