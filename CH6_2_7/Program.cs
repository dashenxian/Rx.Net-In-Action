using System;
using System.Reactive.Linq;
using ObserveCommon;

namespace CH6_2_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Observable.Range(1, 10)
                .Log("Next\t")
                .Where(i => i % 2 == 0)
                .Log("Where\t")
                .Select(i => i * 3)
                .Log("Select\t")
                .SubscribeConsole("final\t");
        }
    }
}
