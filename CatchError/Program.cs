using Akka.Actor;
using System;

namespace CatchError
{
    class Program
    {

        // http://www.pzielinski.com/?p=2980
        // http://www.pzielinski.com/?p=2986

        static void Main(string[] args)
        {
            var system = ActorSystem.Create("FooHierarchySystem");
            IActorRef userControllerActor =
                system.ActorOf<ApplicationUserControllerActor>("ApplicationUserControllerActor");

            userControllerActor.Tell(new AddUser("Piotr"));
            userControllerActor.Tell(new AddUser("Pawel"));
            var actor1 = system.ActorSelection("/user/ApplicationUserControllerActor/Piotr");
            var actor2 = system.ActorSelection("/user/ApplicationUserControllerActor/Pawel");

            Console.ReadLine();
            actor1.Tell("Sample message I");
            Console.ReadLine();
            actor1.Tell("error");
            Console.ReadLine();
            actor1.Tell("Sample message II");

            Console.ReadLine();
        }
    }
}
