using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Text;

namespace CH4_1_1
{
    class NumbersObservable:IObservable<int>
    {
        private readonly int _amount;

        public NumbersObservable(int amount)
        {
            _amount = amount;
        }
        public IDisposable Subscribe(IObserver<int> observer)
        {
            for (int i = 0; i < _amount; i++)
            {
                observer.OnNext(i);
                //if (i==3)
                //{
                //    throw new Exception("错除了");
                //}
            }

            observer.OnCompleted();
            observer.OnNext(_amount);
            return Disposable.Empty;
        }
    }
}
