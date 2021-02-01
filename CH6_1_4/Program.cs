using System;
using System.Reactive.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace CH6_1_4
{
    class Program
    {
        static void Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            cts.Token.Register(() => Console.WriteLine("结束订阅"));

            Observable.Interval(TimeSpan.FromSeconds(1))
                .Subscribe(x => { Console.WriteLine($"x:{x}"); }, cts.Token);

            cts.CancelAfter(TimeSpan.FromSeconds(5));
            Console.ReadKey();
        }
    }
}
