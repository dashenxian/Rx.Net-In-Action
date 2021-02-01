using System;
using System.Reactive.Linq;
using ObserveCommon;

namespace CH10_2_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Observable.Interval(TimeSpan.FromSeconds(1))
                .Timestamp()
                .Log("log")
                .Sample(TimeSpan.FromSeconds(3.5))
                .Take(3)
                .SubscribeConsole();
            Console.ReadKey();
        }
    }
}
