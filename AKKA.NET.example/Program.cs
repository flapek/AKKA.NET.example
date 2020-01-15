using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKKA.NET.example
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = ActorSystem.Create("FooHierarchySystem");
            IActorRef userControllerActor =
                system.ActorOf<ApplicationUserControllerActor>("ApplicationUserControllerActor");

            userControllerActor.Tell(new AddUser("Piotr"));
            userControllerActor.Tell(new AddUser("Pawel"));

            Console.ReadLine();
            Console.WriteLine("Sending a message to ApplicationActor(Piotr)...");
            var actor1 = system.ActorSelection("/user/ApplicationUserControllerActor/Piotr");
            actor1.Tell("Testing actor 1");

            Console.ReadLine();
            Console.WriteLine("Sending a message to ApplicationActor(Pawel)...");
            var actor2 = system.ActorSelection("/user/ApplicationUserControllerActor/Pawel");
            actor2.Tell("Testing actor 2");

            Console.ReadLine();
            Console.WriteLine("Requesting the system shutdown.");

            system.Terminate();

            Console.ReadLine();
        }
    }
}
