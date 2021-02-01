using System;
using System.Reactive.Linq;
using ObserveCommon;

namespace CH10_2_5
{
    class Program
    {
        static void Main(string[] args)
        {
            var observable = Observable
                .Return("Update A")
                .Concat(Observable.Timer(TimeSpan.FromSeconds(1)).Select(_ => "Update B"))
                .Concat(Observable.Timer(TimeSpan.FromSeconds(1)).Select(_ => "Update C"))
                .Concat(Observable.Timer(TimeSpan.FromSeconds(3)).Select(_ => "Update D"))
                .Concat(Observable.Timer(TimeSpan.FromSeconds(3)).Select(_ => "Update E"));
            observable
                .Throttle(TimeSpan.FromSeconds(2))
                .SubscribeConsole("Throttle");
            Console.ReadKey();
        }
    }
}
