using Akka.Actor;
using System;

namespace AKKA.NET.example
{
    public class ApplicationUserControllerActor : ReceiveActor
    {
        public ApplicationUserControllerActor()
        {
            Receive<AddUser>(msg => AddUser(msg));
        }

        private void AddUser(AddUser msg)
        {
            Console.WriteLine("Requested a new user: {0}", msg.UserName);

            IActorRef newActorRef =
                Context.ActorOf(Props.Create(() => new ApplicationUserActor(msg.UserName)), msg.UserName);
        }

        protected override void PreStart()
        {
            Console.WriteLine("ApplicationUserControllerActor: PreStart");
            base.PreStart();
        }

        protected override void PostStop()
        {
            Console.WriteLine("ApplicationUserControllerActor: PostStop");
            base.PostStop();
        }

        protected override void PreRestart(Exception reason, object message)
        {
            Console.WriteLine("ApplicationUserControllerActor: PreRestart");
            base.PreRestart(reason, message);
        }

        protected override void PostRestart(Exception reason)
        {
            Console.WriteLine("ApplicationUserControllerActor: PostRestart");
            base.PostRestart(reason);
        }
    }
}