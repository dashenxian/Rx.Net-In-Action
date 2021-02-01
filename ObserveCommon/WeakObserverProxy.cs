using System;
using System.Collections.Generic;
using System.Text;

namespace ObserveCommon
{
    public class WeakObserverProxy<T> : IObserver<T>
    {
        private IDisposable _subscriptionToSource;
        private readonly WeakReference<IObserver<T>> _weakObserver;

        public WeakObserverProxy(IObserver<T> observer) => _weakObserver = new WeakReference<IObserver<T>>(observer);

        internal void SetSubscription(IDisposable subscriptionToSource) => _subscriptionToSource = subscriptionToSource;

        void NotifyObserver(Action<IObserver<T>> action)
        {
            if (_weakObserver.TryGetTarget(out IObserver<T> observer))
            {
                action(observer);
            }
            else
            {
                _subscriptionToSource.Dispose();
            }
        }
        public void OnCompleted()
        {
            NotifyObserver(observer => observer.OnCompleted());
        }

        public void OnError(Exception error)
        {
            NotifyObserver(observer => observer.OnError(error));
        }

        public void OnNext(T value)
        {
            NotifyObserver(observer => observer.OnNext(value));
        }

        public IDisposable AsDisposable()
        {
            return _subscriptionToSource;
        }
    }
}
