using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using ObserveCommon;

namespace CH4_3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var observe =
                Observable.Create<string>(o =>
            {
                o.OnNext("London");
                o.OnNext("Tel-Aviv");
                o.OnNext("Tokyo");
                o.OnNext("Rome");
                o.OnCompleted();
                return Disposable.Empty;
            });
            //ToEnumerable
            //var list = observe.ToEnumerable();
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}

            //ToList
            //var list = observe.ToList();
            //list.Select(i=>string.Join(',',i))
            //    .SubscribeConsole("list ready");

            //ToDictionary
            var list = observe.ToDictionary(v => v.Length);
            list.Select(i => string.Join(',', i))
                .SubscribeConsole("list ready");
        }
    }
}
