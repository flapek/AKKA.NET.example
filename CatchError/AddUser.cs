namespace CatchError
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