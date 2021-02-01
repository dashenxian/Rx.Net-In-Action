using System;
using System.IO;
using System.Reactive.Linq;
using ObserveCommon;

namespace CH4_4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //var observe = Observable.Generate(
            //    File.OpenText("TextFile1.txt"),
            //    s => !s.EndOfStream,
            //    s => s,
            //    s => s.ReadLine()
            //);

            var observe = Observable.Using(
                () => File.OpenText("TextFile1.txt"),
                stream =>
                    Observable.Generate(
                        stream,
                        s => !s.EndOfStream,
                        s => s,
                        s => s.ReadLine()
                        )
                    );

            observe.SubscribeConsole("File");
        }
    }
}
