using System;
using System.Reactive.Linq;
using ObserveCommon;

namespace CH9_1_5
{
    class Program
    {
        static void Main(string[] args)
        {
            var first = Observable.Interval(TimeSpan.FromSeconds(1))
                .Take(2)
                .Select(i=>$"first:{i}");
            var second = Observable.Interval(TimeSpan.FromSeconds(1))
                .Take(4)
                .Select(i => $"second:{i}");
            var third = Observable.Interval(TimeSpan.FromSeconds(1))
                .Take(2)
                .Select(i => $"third:{i}");
            var merge = new[] {first, second, third}.ToObservable()
                .Merge(2);
            merge.SubscribeConsole();
            Console.ReadKey();
        }
    }
}
