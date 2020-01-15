using Akka.Actor;
using System;

namespace ActorLifeTime
{
    class FooActor : UntypedActor
    {
        protected override void OnReceive(object message)
        {
            Console.WriteLine("Received: {0}", message);
        }

        protected override void PreStart()
        {
            Console.WriteLine("PreStart");
            base.PreStart();
        }

        protected override void PostStop()
        {
            Console.WriteLine("PostStop");
            base.PostStop();
        }

        protected override void PreRestart(Exception reason, object message)
        {
            Console.WriteLine("PreRestart");
            base.PreRestart(reason, message);
        }

        protected override void PostRestart(Exception reason)
        {
            Console.WriteLine("PostRestart");
            base.PostRestart(reason);
        }
    }
}