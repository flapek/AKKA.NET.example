using Akka.Actor;
using System;

namespace RemoteActorsClient
{
    public class EchoReceiverActor : ReceiveActor
    {
        public EchoReceiverActor()
        {
            Receive<string>(msg =>
            {
                Console.WriteLine($"Received on {AppDomain.CurrentDomain.FriendlyName}:{msg}");
            });

            Receive<EchoMsg>(msg =>
            {
                var remoteActor = Context.ActorSelection("akka.tcp://Server@localhost:8081/user/EchoServerActor");
                remoteActor.Tell(msg);
            });
        }
    }
    public class EchoMsg
    {
        public string Text { get; set; }
    }
}
