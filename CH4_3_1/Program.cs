using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using ObserveCommon;

namespace CH4_3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //var list = new List<string> {"Shira", "Yonatan", "Gabi", "Tamir"};
            //var observe = list.ToObservable();
            //observe.SubscribeConsole();

            NumbersAndThrow()
                .ToObservable()
                .SubscribeConsole();
        }

        static IEnumerable<int> NumbersAndThrow()
        {
            yield return 1;
            yield return 2;
            yield return 3;
            yield return 4;
            throw new Exception("测试错误");
            yield return 5;
        }
    }
}
