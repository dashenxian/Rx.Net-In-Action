using System;
using System.Collections.Generic;
using System.Text;

namespace ObserveCommon
{
    public static class SubscribeConsoleExtension
    {
        public static IDisposable SubscribeConsole<T>(this IObservable<T> observable, string name="")
        {
            return observable.Subscribe(new ConsoleObserver<T>(name));
        }
    }
}
