using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using ObserveCommon;

namespace CH9_1_6
{
    class Program
    {
        static void Main(string[] args)
        {
            //var textsSubject = new Subject<string>();
            //IObservable<string> texts = textsSubject.AsObservable();
            //texts
            //    .Select(txt => Observable.Return(txt + "-Result")
            //        .Delay(TimeSpan.FromMilliseconds(txt == "R1" ? 10 : 0))
            //    )
            //    .Switch()
            //    .SubscribeConsole("Merging from observable");
            //textsSubject.OnNext("R1");
            //textsSubject.OnNext("R2");
            //Thread.Sleep(20);
            //textsSubject.OnNext("R3");
            //Console.ReadKey();

            var server1 = Observable.Interval(TimeSpan.FromSeconds(1))
                .Select(i => $"server1-{i}");
            var server2 = Observable.Interval(TimeSpan.FromSeconds(1))
                .Select(i => $"server1-{i}");
            Observable.Amb(server1, server2)
                .Take(3)
                .SubscribeConsole();
            Console.ReadKey();
        }
    }
}
