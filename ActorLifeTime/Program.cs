using Akka.Actor;
using System;

namespace ActorLifeTime
{
    class Program
    {
        // http://www.pzielinski.com/?p=2939

        static void Main(string[] args)
        {
            var system = ActorSystem.Create("system");
            var actor = system.ActorOf<FooActor>();

            actor.Tell("Hello World!");
            system.Terminate();

            Console.ReadLine();
        }
    }
}
