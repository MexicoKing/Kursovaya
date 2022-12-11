using InventoryManagementSystem.Model;
using System.Collections.Generic;

namespace InventoryManagementSystem.Controller
{
    public class OrderController
    {
        List<Order> orders;
        int id = 1;
        public int NewID()
        {
            return id++;
        }
        public OrderController()
        {
            orders = new List<Order>();
        }
        public List<Order> LoadData()
        {
            return orders;
        }
        public void Add(Order order)
        {
            orders.Add(order);
        }
        public void Update(Order order)
        {
            orders[orders.IndexOf(orders.Find(item => item.CustomerName == order.CustomerName))] = order;
        }
        public void Remove(string rowValue)
        {
            orders.Remove(orders.Find(item => item.CustomerName == rowValue));
        }
    }
}
