using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using ObserveCommon;

namespace CH10_3_3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Observable.Interval(TimeSpan.FromSeconds(10))
            //    .Take(1).LogWithThread("A")
            //    .Where(x => x % 2 == 0).LogWithThread("B")
            //    .SubscribeOn(NewThreadScheduler.Default).LogWithThread("C")
            //    .Select(x => x * x).LogWithThread("D")
            //    .ObserveOn(TaskPoolScheduler.Default).LogWithThread("E")
            //    .SubscribeConsole("squares by time");
            //Console.ReadLine();
            new[] { 0, 1, 2, 3, 4, 5 }.ToObservable()
                .Take(3).LogWithThread("A")
                .Where(x => x % 2 == 0).LogWithThread("B")
                .SubscribeOn(NewThreadScheduler.Default).LogWithThread("C")
                .Select(x => x * x).LogWithThread("D")
                .ObserveOn(TaskPoolScheduler.Default).LogWithThread("E")
                .SubscribeConsole("squares by time");
            Console.ReadLine();
        }
    }
}
