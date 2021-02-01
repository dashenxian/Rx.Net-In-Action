using System;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace CH6_1_3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Observable.Range(1, 5)
            //    .Select(i => i / (i - 3))
            //    .Subscribe(
            //        i => Console.WriteLine("{0}", i)
            //        ,e=> Console.WriteLine(e.Message))
            //    ;

            Observable.Range(1, 5)
                .Select(i => Task.Run(() => i / (i - 3)))
                .Concat()
                .Subscribe(i => Console.WriteLine("{0}", i)
                ,e=> Console.WriteLine(e.Message))
                ;
            Console.WriteLine("完成");
        }
    }
}
