using System;
using System.Reactive.Linq;
using ObserveCommon;

namespace CH5_1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(System.Reflection.Assembly.GetExecutingAssembly().GetName().Version);
           
            var magicalPrimeGenerator= new MagicalPrimeGenerator();
            magicalPrimeGenerator
                .GeneratePrimes(5)
                .Timestamp()
                .SubscribeConsole("Magic");
        }
    }
}
