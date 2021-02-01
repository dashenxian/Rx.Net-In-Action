using System;
using System.Reactive.Linq;
using ObserveCommon;

namespace CH11_2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Observable.Interval(TimeSpan.FromSeconds(1))
            //    .Take(3)
            //    .Finally(() => { Console.WriteLine("Finally"); })
            //    .SubscribeConsole();

            Observable.Throw<int>(new NotImplementedException())
                .Finally(() => { Console.WriteLine("Finally"); })
                .SubscribeConsole();

            Console.ReadKey();


        }
    }
}
