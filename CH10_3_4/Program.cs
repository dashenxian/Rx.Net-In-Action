using System;
using System.Reactive.Linq;
using System.Runtime;
using System.Threading;

namespace CH10_3_4
{
    class Program
    {
        static void Main(string[] args)
        {
            //OneObservableSynchronization();
            MultipleObservableSynchronization();
            Console.ReadKey();
        }

        private static void OneObservableSynchronization()
        {
            var messenger = new Messenger();
            Observable.FromEventPattern<string>(h => messenger.MessageReceived += h,
                    h => messenger.MessageReceived -= h)
                .Select(i => i.EventArgs)
                .Synchronize()
                .Subscribe(x =>
                {
                    Console.WriteLine($"Message {x} Received");
                    Thread.Sleep(2000);
                    Console.WriteLine($"Message {x} Exit");
                });

            for (int i = 0; i < 3; i++)
            {
                var msg = $"Msg{i}";
                ThreadPool.QueueUserWorkItem((_) => { messenger.Notify(msg); });
            }
        }

        public static void MultipleObservableSynchronization()
        {
            var gate = new object();
            var messenger = new Messenger();
            Observable.FromEventPattern<string>(h => messenger.MessageReceived += h,
                    h => messenger.MessageReceived -= h)
                .Select(i => i.EventArgs)
                .Synchronize(gate)
                .Subscribe(x =>
                {
                    Console.WriteLine($"Message {x} Received");
                    Thread.Sleep(2000);
                    Console.WriteLine($"Message {x} Exit");
                });

            Observable.FromEventPattern<FriendRequest>(h => messenger.FriendRequestRecieved += h,
                    h => messenger.FriendRequestRecieved -= h)
                .Select(i => i.EventArgs)
                .Synchronize(gate)
                .Subscribe(x =>
                {
                    Console.WriteLine($"FriendRequest {x.UserId} Received");
                    Thread.Sleep(2000);
                    Console.WriteLine($"FriendRequest {x.UserId} Exit");
                });

            for (int i = 0; i < 3; i++)
            {
                var msg = $"Msg{i}";
                var userId = $"UserId{i}";
                ThreadPool.QueueUserWorkItem(_ => { messenger.Notify(msg); });
                ThreadPool.QueueUserWorkItem(_ => { messenger.Notify(new FriendRequest { UserId = userId }); });
            }
        }
    }
}
