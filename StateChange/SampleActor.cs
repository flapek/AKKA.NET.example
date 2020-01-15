using Akka.Actor;
using System;

namespace StateChange
{
    internal class SampleActor : UntypedActor
    {
        protected override void OnReceive(object message)
        {
            Console.WriteLine("Otrzymano wiadomosc ze stanu I {0}", message);
            Become(GoToState2);
            //BecomeStacked(GoToState2);
        }

        private void GoToState2(object message)
        {
            Console.WriteLine("Otrzymano wiadomosc ze stanu II {0}", message);
            //UnbecomeStacked();
        }
    }
}