using System;
using System.Reactive.Linq;
using System.Threading;
using ObserveCommon;

namespace CH6_2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!{0}",DateTime.Now);

            //var sub = Observable.Range(1, 5)
            //        .Timestamp()
            //        .DelaySubscription(TimeSpan.FromSeconds(5))
            //        .SubscribeConsole()
            //    ;
            //Console.ReadKey();


            Console.WriteLine("Hello World!{0}", DateTime.Now);

            var sub = Observable.Range(1, 5)
                    .Timestamp()
                    .DelaySubscription(TimeSpan.FromSeconds(5))
                ;

            Thread.Sleep(TimeSpan.FromSeconds(2));

            Console.WriteLine("SubscribeConsole!{0}", DateTime.Now);

            sub.SubscribeConsole();

            Console.ReadKey();
        }
    }
}
