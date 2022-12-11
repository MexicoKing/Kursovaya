using InventoryManagementSystem.Controller;
using System;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class ProductModuleForm : Form
    {
        ProductController productController;
        public ProductModuleForm(ProductController productController, CategoryController categoryController)
        {
            this.productController = productController;
            InitializeComponent();
            productController.LoadCategory(comboCat, categoryController);
        }
        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to save this product?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    productController.Add(new Product(productController.NewID(), txtPName.Text, int.Parse(txtPQty.Text), int.Parse(txtPPrice.Text), txtPDes.Text, comboCat.Text));
                    MessageBox.Show("Product has been successfully saved.");
                    Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void Clear()
        {
            txtPName.Clear();
            txtPQty.Clear();
            txtPPrice.Clear();
            txtPDes.Clear();
            comboCat.Text = "";
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to update this product?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    productController.Update(new Product(productController.NewID(), txtPName.Text, int.Parse(txtPQty.Text), int.Parse(txtPPrice.Text), txtPDes.Text, comboCat.Text));
                    MessageBox.Show("Product has been successfully updated!");
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
