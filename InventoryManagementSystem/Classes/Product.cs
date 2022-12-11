namespace InventoryManagementSystem
{
    public class Product
    {
        private int _productId;
        private string _productName;
        private int _quantity;
        private int _price;
        private string _category;
        private string _description;

        public Product(int productId, string productName, int quantity, int price, string desctiption, string category)
        {
            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            Price = price;
            Desctiption = desctiption;
            Category = category;
        }

        public int ProductId
        {
            get { return _productId; }
            set { _productId = value; }
        }
        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public string Desctiption
        {
            get { return _description; }
            set { _description = value; }
        }
        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }
    }
}
