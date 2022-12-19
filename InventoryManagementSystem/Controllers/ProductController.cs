using System.Collections.Generic;
using System.Windows.Forms;

namespace InventoryManagementSystem.Controller
{
    public class ProductController
    {
        List<Product> products;
        int id = 1;
        public ProductController()
        {
            products = new List<Product>() 
            { 
                new Product (NewID(), "product1", 5, 20, "someDesctiption", "earphones"),
                new Product (NewID(), "product2", 2, 25, "someDesctiption2", "laptops"),
                new Product (NewID(), "product3", 1, 30, "someDesctiption3", "smartphones")
            };
        }
        public void LoadCategory(ComboBox comboBox, CategoryController categoryController)
        {
            foreach (Category category in categoryController.LoadData())
            {
                comboBox.Items.Add(category.CategoryName);
            }
        }
        public List<Product> LoadData()
        {
            return products;
        }
        public int NewID()
        {
            return id++;
        }
        public void Add(Product product)
        {
            products.Add(product);
        }
        public void Update(Product product)
        {
            products[products.IndexOf(products.Find(item => item.ProductId == product.ProductId))] = product;
        }
        public void Remove(string rowValue)
        {
            products.Remove(products.Find(item => item.ProductId.ToString() == rowValue));
        }
    }
}
