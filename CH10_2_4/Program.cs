using System;
using System.Reactive.Linq;
using ObserveCommon;

namespace CH10_2_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Observable.Range(1, 5)
                .Timestamp()
                .Delay(x => Observable.Timer(TimeSpan.FromSeconds(x.Value)))
                .Timestamp()
                .SubscribeConsole();
            Console.ReadKey();
        }
    }
}
