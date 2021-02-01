using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Text;

namespace ObserveCommon
{
    public static class CompositeDisposableExtensions
    {
        public static CompositeDisposable AddToCompositeDisposable(this IDisposable disposable,
            CompositeDisposable compositeDisposable)
        {
            if (compositeDisposable == null)
            {
                throw new ArgumentNullException(nameof(compositeDisposable));
            }
            compositeDisposable.Add(disposable);
            return compositeDisposable;
        }
    }
}
