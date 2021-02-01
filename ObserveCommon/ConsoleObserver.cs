using System;
using System.Collections.Generic;
using System.Text;

namespace ObserveCommon
{
    class ConsoleObserver<T> : IObserver<T>
    {
        private readonly string _name;

        public ConsoleObserver(string name = "")
        {
            _name = name;
        }
        public void OnCompleted()
        {
            Console.WriteLine($"{_name} - OnCompleted()");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine($"{_name} - OnError:");
            Console.WriteLine($"\t {error}");
        }

        public void OnNext(T value)
        {
            Console.WriteLine($"{_name} - OnNext({value})");
        }
    }
}
