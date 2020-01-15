using Akka.Actor;
using System;

namespace FirstExample
{
    // http://www.pzielinski.com/?p=2912

    class Program
    {
        static void Main(string[] args)
        {
            var system = ActorSystem.Create("JakasNazwa");

            var actor1 = system.ActorOf<TransferMoneyActor>();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("{0}: Wysylanie wiadomosci nr {1}", DateTime.Now, i);
                actor1.Tell(new TransferMoney("nadawca", "odbiorca"));
            }

            Console.ReadLine();
        }
    }
}
