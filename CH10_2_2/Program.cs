using System;
using System.Reactive.Linq;
using ObserveCommon;

namespace CH10_2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var deviceHeartbeat = Observable.Timer(TimeSpan.FromSeconds(1))
                .Concat(Observable.Timer(TimeSpan.FromSeconds(2)))
                .Concat(Observable.Timer(TimeSpan.FromSeconds(4)));

            deviceHeartbeat.TimeInterval()
                .SubscribeConsole();

            Console.ReadKey();
        }
    }
}
