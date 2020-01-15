using Akka.Actor;
using System;
using System.Threading;

namespace FirstExample
{
    internal class TransferMoneyActor : ReceiveActor
    {
        public TransferMoneyActor()
        {
            Receive<TransferMoney>(DoWork, shouldHandle: null);
        }

        private void DoWork(TransferMoney msg)
        {
            Console.WriteLine("{0}:{1}", DateTime.Now, Thread.CurrentThread.ManagedThreadId);

            Thread.Sleep(5000);
        }
    }
}