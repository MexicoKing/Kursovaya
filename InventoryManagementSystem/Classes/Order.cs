using System;

namespace InventoryManagementSystem.Model
{
    public class Order
    {
        public Order(int orderId, DateTime orderDate, int productId, string productName, int customerId, string customerName, int quantity, int price, int totalAmount)
        {
            _ordrId = orderId;
            _orderDate = orderDate;
            _productId = productId;
            _productName = productName;
            _customerId = customerId;
            _customerName = customerName;
            _quantity = quantity;
            _price = price;
            _totalAmount = totalAmount;
        }

        private int _ordrId;
        private DateTime _orderDate;
        private int _productId;
        private string _productName;
        private int _customerId;
        private string _customerName;
        private int _quantity;
        private int _price;
        private int _totalAmount;

        public int OrderId
        {
            get { return _ordrId; }
        }
        public DateTime OrderDate
        {
            get { return _orderDate; }
        }
        public int ProductId
        {
            get { return _productId; }
        }
        public string ProductName
        {
            get { return _productName; }
        }
        public int CustomerId
        {
            get { return _customerId; }
        }
        public string CustomerName
        {
            get { return _customerName; }
        }
        public int Quantity
        {
            get { return _quantity; }
        }
        public int Price
        {
            get { return _price; }
        }
        public int TotalAmount
        {
            get { return _totalAmount; }
        }
    }
}
