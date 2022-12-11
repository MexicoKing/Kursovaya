namespace InventoryManagementSystem
{
    public class Category
    {
        private string _categoryName;
        private int _categoryId;

        public Category(int categoryId, string categoryName)
        {
            _categoryId = categoryId;
            _categoryName = categoryName;
        }

        public string CategoryName
        {
            get { return _categoryName; }
        }
        public int CategoryId
        {
            get { return _categoryId; }
        }
    }
}
