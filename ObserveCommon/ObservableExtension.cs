using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Text;
using System.Threading;

namespace ObserveCommon
{
    public static class ObservableExtension
    {
        public static IObservable<T> Log<T>(this IObservable<T> observable,string msg="")
        { 
            return observable.Do(x =>
            {
                Console.WriteLine($"{msg} - OnNext({x})");
            }, ex =>
            {
                Console.WriteLine($"{msg} - OnError:{ex}");
            }, () =>
            {
                Console.WriteLine($"{msg} - OnCompleted()");
            });
        }
        public static IObservable<T> LogWithThread<T>(
            this IObservable<T> observable,
            string msg = "")
        {
            return Observable.Defer(() =>
            {
                Console.WriteLine("{0} Subscription happened on Thread: {1}", msg,
                    Thread.CurrentThread.ManagedThreadId);
                return observable.Do(
                    x => Console.WriteLine("{0} - OnNext({1}) Thread: {2}", msg, x,
                        Thread.CurrentThread.ManagedThreadId),
                    ex =>
                    {
                        Console.WriteLine("{0} – OnError Thread:{1}", msg,
                            Thread.CurrentThread.ManagedThreadId);
                        Console.WriteLine("\t {0}", ex);
                    },
                    () => Console.WriteLine("{0} - OnCompleted() Thread {1}", msg,
                        Thread.CurrentThread.ManagedThreadId));
            });
        }
    }
}
