using System;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Threading;

namespace CH10_1_3
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestScheduler(NewThreadScheduler.Default);
            //TestScheduler(ThreadPoolScheduler.Instance);
            //TestScheduler(CurrentThreadScheduler.Instance);
            TestScheduler(new EventLoopScheduler());
            //var immediateScheduler = CurrentThreadScheduler.Instance;//ImmediateScheduler.Instance;
            //Console.WriteLine("Calling thread: {0} Current time: {1}",
            //    Thread.CurrentThread.ManagedThreadId, immediateScheduler.Now);
            //immediateScheduler.Schedule(Unit.Default,
            //    TimeSpan.FromSeconds(2),
            //    (s, _) =>
            //    {
            //        Console.WriteLine($"Outer Action - Thread:{Thread.CurrentThread.ManagedThreadId},Now:{s.Now}"
            //            );
            //        s.Schedule(Unit.Default,
            //            (s2, __) =>
            //            {
            //                Console.WriteLine($"Inner Action - Thread:{Thread.CurrentThread.ManagedThreadId},Now:{s2.Now}");
            //                return Disposable.Empty;
            //            });
            //        Console.WriteLine($"Outer Action - Done,Now:{s.Now}");
            //        return Disposable.Empty;
            //    });
            //Console.WriteLine("After the Schedule, Time: {0}", immediateScheduler.Now);
            Console.ReadKey();
        }

        public static void TestScheduler(IScheduler scheduler)
        {
            var count = 10;
            for (int i = 0; i < count; i++)
            {
                scheduler.Schedule(Unit.Default, (s, _) =>
                {
                    Console.WriteLine($"Action{i} - Thread:{Thread.CurrentThread.ManagedThreadId}");
                });

            }
        }
    }
}
