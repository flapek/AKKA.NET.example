namespace FirstExample
{
    internal class TransferMoney
    {
        public string From { get; private set; }
        public string To { get; private set; }

        public TransferMoney(string from, string to)
        {
            From = @from;
            To = to;
        }
    }
}