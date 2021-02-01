using System;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Threading;

namespace CH10_1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine($"MainTread:{Thread.CurrentThread.ManagedThreadId}");
            //IScheduler scheduler = NewThreadScheduler.Default;
            //scheduler.Schedule(Unit.Default
            //    , TimeSpan.FromSeconds(2)
            //    , (sche, _) =>
            //    {
            //        Console.WriteLine($"Thread:{Thread.CurrentThread.ManagedThreadId},Time:{sche.Now.LocalDateTime}");
            //        return Disposable.Empty;
            //    });
            //Console.WriteLine($"MainTread:{Thread.CurrentThread.ManagedThreadId}");

            IScheduler scheduler = NewThreadScheduler.Default;
            Func<IScheduler, int, IDisposable> action = null;
            action = (sche, callNumber) =>
            {
                Console.WriteLine($"Hello {callNumber},Now {sche.Now.LocalDateTime},Thread {Thread.CurrentThread.ManagedThreadId}");
                return sche.Schedule(callNumber + 1, TimeSpan.FromSeconds(2), action);
            };
            var dispos = scheduler.Schedule(0, TimeSpan.FromSeconds(2), action);

            Thread.Sleep(10000);
            dispos.Dispose();
        }
    }
}
