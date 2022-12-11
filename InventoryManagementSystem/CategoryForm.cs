using System;
using InventoryManagementSystem.Controller;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class CategoryForm : Form
    {
        CategoryController categoryController;
        public CategoryForm()
        {
            categoryController = new CategoryController();
            InitializeComponent();
            LoadCategory();
        }

        public void LoadCategory()
        {
            dgvCategory.Rows.Clear();
            List<Category> categories = categoryController.LoadData();
            int i = 0;
            foreach (var item in categories)
            {
                i++;
                dgvCategory.Rows.Add(i, item.CategoryId.ToString(), item.CategoryName);               
            }
        }

        public CategoryController CategoryController
        {
            get { return categoryController; }
        }

        private void dgvCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvCategory.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                CategoryModuleForm formModule = new CategoryModuleForm(categoryController);
                formModule.lblCatId.Text = dgvCategory.Rows[e.RowIndex].Cells[1].Value.ToString();
                formModule.txtCatName.Text = dgvCategory.Rows[e.RowIndex].Cells[2].Value.ToString();

                formModule.btnSave.Enabled = false;
                formModule.btnUpdate.Enabled = true;
                formModule.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this category?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    categoryController.Remove(dgvCategory.Rows[e.RowIndex].Cells[2].Value.ToString());
                    MessageBox.Show("Record has been successfully deleted!");
                }
            }
            LoadCategory();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CategoryModuleForm formModule = new CategoryModuleForm(categoryController);
            formModule.btnSave.Enabled = true;
            formModule.btnUpdate.Enabled = false;
            formModule.ShowDialog();
            LoadCategory();
        }
    }
}
