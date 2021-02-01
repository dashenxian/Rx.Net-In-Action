using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using ObserveCommon;

namespace CH7_2_1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var coldObservable = Observable.Create<string>(async o =>
            {
                o.OnNext("Hello");
                await Task.Delay(TimeSpan.FromSeconds(1));
                o.OnNext("Rx");
            }).Timestamp();
            coldObservable.SubscribeConsole("o1");
            await Task.Delay(TimeSpan.FromSeconds(.5));
            coldObservable.SubscribeConsole("o2");
            Console.ReadKey();
        }
    }
}
