﻿using Akka.Actor;
using Akka.Configuration;
using System;

namespace RemoteActorsServer
{

    // http://www.pzielinski.com/?p=3071

    class Program
    {
        static void Main(string[] args)
        {
            var config = ConfigurationFactory.ParseString(@"
akka {  
    actor {
        provider = remote
    }
    remote {
        dot-netty.tcp {
            port = 8081
            hostname = 0.0.0.0
            public-hostname = localhost
        }
    }
}
");

            using (var system = ActorSystem.Create("MyServer", config))
            {
                system.ActorOf(Props.Create(() => new ChatServerActor()), "ChatServer");

                Console.ReadLine();
            }
        }
    }
}