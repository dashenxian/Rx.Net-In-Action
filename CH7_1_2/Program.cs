using System;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ObserveCommon;

namespace CH7_1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var tcs = new TaskCompletionSource<bool>();
            var task = tcs.Task;
            var sbj = new AsyncSubject<bool>();
            task.ContinueWith(t =>
            {
                switch (t.Status)
                {
                    case TaskStatus.RanToCompletion:
                        sbj.OnNext(t.Result);
                        sbj.OnCompleted();
                        break;
                    case TaskStatus.Faulted:
                        sbj.OnError(t.Exception.InnerException);
                        break;
                    case TaskStatus.Canceled:
                        sbj.OnError(new TaskCanceledException(t));
                        break;
                }
            }, TaskContinuationOptions.ExecuteSynchronously);
            tcs.SetResult(true);
            sbj.SubscribeConsole("first");
            sbj.SubscribeConsole("Second");
            tcs.SetResult(false);
            Console.ReadKey();
        }
    }
}
