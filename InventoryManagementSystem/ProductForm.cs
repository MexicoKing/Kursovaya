using InventoryManagementSystem.Controller;
using System;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class ProductForm : Form
    {
        ProductController productController;
        CategoryController categoryController;
        public ProductForm(CategoryController categoryController)
        {
            this.categoryController = categoryController;
            productController = new ProductController();
            InitializeComponent();
            
            LoadProduct();
        }

        public ProductController ProductController
        {
            get { return productController; }
        }

        private void LoadProduct()
        {
            dgvProduct.Rows.Clear();
            int i = 0; 
            foreach (var item in productController.LoadData())
            {
                i++;
                dgvProduct.Rows.Add(i, item.ProductId.ToString(), item.ProductName, item.Quantity.ToString(), item.Price.ToString(), item.Desctiption, item.Category);
            }
        }
        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvProduct.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                ProductModuleForm productModule = new ProductModuleForm(productController, categoryController);
                productModule.lblPid.Text = dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
                productModule.txtPName.Text = dgvProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
                productModule.txtPQty.Text = dgvProduct.Rows[e.RowIndex].Cells[3].Value.ToString();
                productModule.txtPPrice.Text = dgvProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
                productModule.txtPDes.Text = dgvProduct.Rows[e.RowIndex].Cells[5].Value.ToString();
                productModule.comboCat.Text = dgvProduct.Rows[e.RowIndex].Cells[6].Value.ToString();

                productModule.btnSave.Enabled = false;
                productModule.btnUpdate.Enabled = true;                
                productModule.ShowDialog();
            }   
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this product?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    productController.Remove(dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString());
                    MessageBox.Show("Record has been successfully deleted!");
                }
            }
            LoadProduct();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            ProductModuleForm formModule = new ProductModuleForm(productController, categoryController);
            formModule.btnSave.Enabled = true;
            formModule.btnUpdate.Enabled = false;
            formModule.ShowDialog();
            LoadProduct();
        }
    }
}
