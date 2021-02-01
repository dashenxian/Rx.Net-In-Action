using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CH5_1_1
{
    class MagicalPrimeGenerator
    {
        private readonly IEnumerable<int> List = new int[]
        {
            1, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31
        };
        public IEnumerable<int> Generate(int amount)
        {
            foreach (var item in List.Take(amount))
            {
                Thread.Sleep(2000);
                yield return item;

            }
        }

        public IObservable<int> GeneratePrimes(int amount)
        {
            return Observable.Create<int>(o =>
             {
                 foreach (var item in Generate(amount))
                 {
                     o.OnNext(item);
                 }

                 o.OnCompleted();
                 return Disposable.Empty;
             });
        }
    }
}
