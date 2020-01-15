using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKKA.NET.example
{
    class ApplicationUserActor : UntypedActor
    {
        private readonly string _userName;

        public ApplicationUserActor(string userName)
        {
            _userName = userName;
        }

        protected override void OnReceive(object message)
        {

            Console.WriteLine("Received by {0}: {1}", _userName, message);
        }

        protected override void PreStart()
        {
            Console.WriteLine("{0}: PreStart", _userName);
            base.PreStart();
        }

        protected override void PostStop()
        {
            Console.WriteLine("{0}: PostStop", _userName);
            base.PostStop();
        }

        protected override void PreRestart(Exception reason, object message)
        {
            Console.WriteLine("{0}: PreRestart", _userName);
            base.PreRestart(reason, message);
        }

        protected override void PostRestart(Exception reason)
        {
            Console.WriteLine("{0}: PostRestart", _userName);
            base.PostRestart(reason);
        }
    }
}
