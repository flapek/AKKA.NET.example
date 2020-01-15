namespace AKKA.NET.example
{
    internal class AddUser
    {
        public string UserName { get; private set; }

        public AddUser(string userName)
        {
            UserName = userName;
        }
    }
}