using System.Collections.Generic;

namespace InventoryManagementSystem.Controller
{
    public class CustomerController
    {
        List<Customer> customers;
        int id=1;
        public CustomerController()
        {
            customers = new List<Customer>() { 
            new Customer(NewID(), "Bob", "+375333333"),
            new Customer(NewID(), "Ann", "+375333333"),
            new Customer(NewID(), "Robin", "+375333333"),
            new Customer(NewID(), "Alex", "+375333333"),
            };
        }
        public List<Customer> LoadData()
        {
            return customers;
        }
        public int NewID()
        {
            return id++;
        }
        public void Remove(string rowValue)
        {
            customers.Remove(customers.Find(item => item.FullName == rowValue));
        }
        public void Add(Customer customer)
        {
            customers.Add(customer);
        }
        public void Update(Customer customer)
        {
            customers[customers.IndexOf(customers.Find(item => item.CustomerId == customer.CustomerId))] = customer;
        }
    }
}
