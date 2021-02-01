using System;
using System.Collections.Generic;
using System.Text;

namespace CH10_3_4
{
    class Messenger
    {
        public event EventHandler<string> MessageReceived = delegate { };
        public event EventHandler<FriendRequest> FriendRequestRecieved = delegate { };

        public void Notify(string msg)
        {
            MessageReceived(this, msg);
        }

        public void Notify(FriendRequest friendRequest)
        {
            FriendRequestRecieved(this, friendRequest);
        }
    }
    internal class FriendRequest
    {
        public string UserId { get; set; }

    }
}
