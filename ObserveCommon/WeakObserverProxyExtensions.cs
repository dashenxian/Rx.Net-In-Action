using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;

namespace ObserveCommon
{
    public static class WeakObserverProxyExtensions
    {
        public static IObservable<T> AsWeakObservable<T>(this IObservable<T> observable)
        {
            return Observable.Create<T>(o =>
            {
                var weakObserverProxy = new WeakObserverProxy<T>(o);
                var subscription = observable.Subscribe(weakObserverProxy);
                weakObserverProxy.SetSubscription(subscription);
                return weakObserverProxy.AsDisposable();
            });
        }
    }
}
