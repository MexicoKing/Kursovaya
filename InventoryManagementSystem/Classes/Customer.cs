namespace InventoryManagementSystem
{
    public class Customer : Person
    {
        private int _customerId;
        public Customer(int customerId, string customerName, string customerNumber) : base(customerName, customerNumber)
        {
            _customerId = customerId;
        }
        public int CustomerId
        {
            get { return _customerId; }
        }
    }
}
