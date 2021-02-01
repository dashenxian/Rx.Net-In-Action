using System;
using System.Reactive.Linq;
using ObserveCommon;

namespace CH6_2_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Observable.Range(1, 3)
                .Repeat(2)
                .SubscribeConsole();
        }
    }
}
