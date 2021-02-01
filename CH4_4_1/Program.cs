using System;
using System.Reactive.Linq;
using ObserveCommon;

namespace CH4_4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //var observe = Observable.Generate(0,
            //    i => i < 10,
            //    i => i + 1,
            //    i => i * 2
            //);
            var observe = Observable.Range(0, 10).Select(i => i * 2);
            observe.SubscribeConsole("Generate");
        }
    }
}
