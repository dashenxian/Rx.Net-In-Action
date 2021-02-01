using System;
using System.Reactive.Linq;
using ObserveCommon;

namespace CH6_2_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Observable.Range(1, 10)
                .SkipWhile(i => i > 2)
                //.TakeWhile(i => i > 7)
                .SubscribeConsole();

            //-OnNext(2)
            //- OnNext(3)
            //- OnNext(4)
            //- OnNext(5)
            //- OnNext(6)
            //- OnCompleted()

            Console.ReadKey();
        }
    }
}
