using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class MainForm : Form
    {
        private Form activeForm = null;
        private List<Form> forms;

        public MainForm()
        {
            InitializeComponent();
            UserForm userForm = new UserForm();
            CategoryForm categoryForm = new CategoryForm();
            CustomerForm customerForm = new CustomerForm();
            ProductForm productForm = new ProductForm(categoryForm.CategoryController);
            OrderForm orderForm = new OrderForm(customerForm.CustomerController, productForm.ProductController);
            forms = new List<Form>() { userForm, categoryForm, customerForm, productForm, orderForm };
        }
         
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Hide();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            openChildForm(forms[0]);
        }
        private void btnCategory_Click(object sender, EventArgs e)
        {
            openChildForm(forms[1]);
        }
        private void btnCustomer_Click(object sender, EventArgs e)
        {
            openChildForm(forms[2]);
        }
        private void btnProduct_Click(object sender, EventArgs e)
        {
            openChildForm(forms[3]);
        }
        private void btnOrder_Click(object sender, EventArgs e)
        {
            openChildForm(forms[4]);
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Applicaton?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
