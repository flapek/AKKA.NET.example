using Akka.Actor;
using Akka.Configuration;
using System;
using System.Linq;
using static RemoteActorsServer.Messeges;

namespace RemoteActorsClient
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
		    port = 0
		    hostname = localhost
        }
    }
}
");

            using (var system = ActorSystem.Create("MyClient", config))
            {
                var chatClient = system.ActorOf(Props.Create<ChatClientActor>());
                chatClient.Tell(new ConnectRequest()
                {
                    Username = "Roggan",
                });

                while (true)
                {
                    var input = Console.ReadLine();
                    if (input.StartsWith("/"))
                    {
                        var parts = input.Split(' ');
                        var cmd = parts[0].ToLowerInvariant();
                        var rest = string.Join(" ", parts.Skip(1));

                        if (cmd == "/nick")
                        {
                            chatClient.Tell(new NickRequest
                            {
                                NewUsername = rest
                            });
                        }
                        if (cmd == "/exit")
                        {
                            Console.WriteLine("exiting");
                            break;
                        }
                    }
                    else
                    {
                        chatClient.Tell(new SayRequest()
                        {
                            Text = input,
                        });
                    }
                }

                system.Terminate().Wait();
            }
        }
    }
}
