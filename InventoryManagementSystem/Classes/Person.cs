namespace InventoryManagementSystem
{
    public abstract class Person
    {
        protected Person(string fullName, string phone)
        {
            _fullName = fullName;
            _phone = phone;
        }

        private string _fullName;
        private string _phone;

        public string FullName
        {
            get { return _fullName; }
        }
        public string Phone
        {
            get { return _phone; }
        }
        public override string ToString()
        {
            return FullName + " " + Phone;
        }
    }
}
