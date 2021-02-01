using System;
using ObserveCommon;

namespace CH4_1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbersObservable = new NumbersObservable(5);
            //var subscription = numbersObservable.Subscribe(new ConsoleObserver<int>("numbers"));
            var subscription = numbersObservable.SubscribeConsole();
        }
    }
}
