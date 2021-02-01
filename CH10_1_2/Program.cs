using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using ObserveCommon;

namespace CH10_1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine($"MainTread:{Thread.CurrentThread.ManagedThreadId}");
            //Observable.Interval(TimeSpan.FromSeconds(1),CurrentThreadScheduler.Instance)
            //    .Subscribe(x =>
            //    {
            //        Console.WriteLine($"Tread:{Thread.CurrentThread.ManagedThreadId}");
            //    });
            //Console.ReadKey();

            Console.WriteLine($"MainTread:{Thread.CurrentThread.ManagedThreadId}");
            var obs = Observable.Range(1, 5, NewThreadScheduler.Default)
                .Repeat()
                .Subscribe(x =>
                {
                    Console.WriteLine($"{x}:Tread:{Thread.CurrentThread.ManagedThreadId}");
                });

            //obs.Dispose();
        }
    }
}
