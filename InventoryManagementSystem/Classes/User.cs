namespace InventoryManagementSystem
{
    public class User : Person
    {
        private string _userName;
        private string _password;
        public User(string userName, string password, string fullName, string phone) : base(fullName, phone)
        {
            _userName = userName;
            _password = password;
        }
        public string UserName
        {
            get { return _userName; }
        }
        public string Password
        {
            get { return _password; }
        }
        public string ToFileString
        {
            get { return _userName+"  "+ FullName + "  "+_password+"  "+Phone; }
        }
    }
}
