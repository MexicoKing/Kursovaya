using System.Collections.Generic;

namespace InventoryManagementSystem.Controller
{
    public class CategoryController
    {
        List<Category> categories;
        int id = 1;
        public CategoryController()
        {
            categories = new List<Category>() { 
            new Category(NewID(), "smartphones"),
            new Category(NewID(), "laptops"),
            new Category(NewID(), "earphones"),
            };
        }   
        public List<Category> LoadData()
        {
            return categories;
        }

        public void Add(Category category)
        {
            categories.Add(category);
        }
        public void Update(Category category)
        {
            categories[categories.IndexOf(categories.Find(item => item.CategoryId == category.CategoryId))] = category;
        }
        public int NewID()
        {
            return id++;
        }
        public void Remove(string rowValue)
        {
            categories.Remove(categories.Find(item => item.CategoryName == rowValue));
        }
    }
}
