using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using ObserveCommon;

namespace CH7_1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //var sub = new Subject<int>();
            //sub.SubscribeConsole("First");
            //sub.SubscribeConsole("Second");
            //sub.OnNext(1);
            //sub.OnNext(2);
            //sub.OnCompleted();
            //sub.OnNext(3);
            //Console.ReadKey();

            var sub = new Subject<string>();
            Observable.Interval(TimeSpan.FromSeconds(1))
                .Select(i => $"First-{i}")
                .Take(5)
                .Subscribe(sub);

            Observable.Interval(TimeSpan.FromSeconds(2))
                .Select(i => $"Second-{i}")
                .Take(5)
                .Subscribe(sub);

            sub.SubscribeConsole();
            Console.ReadKey();
        }
    }
}
