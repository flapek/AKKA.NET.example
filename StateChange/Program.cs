using Akka.Actor;
using System;

namespace StateChange
{
    class Program
    {

        // http://www.pzielinski.com/?p=2920

        static void Main(string[] args)
        {
            var system = ActorSystem.Create("JakasNazwa");
            var actor1 = system.ActorOf<SampleActor>();


            for (int i = 0; i < 10; i++)
            {
                actor1.Tell(i.ToString());
            }

            Console.ReadLine();
        }
    }
}
