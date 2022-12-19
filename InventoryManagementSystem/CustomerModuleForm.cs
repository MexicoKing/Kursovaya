using System;
using System.Windows.Forms;
using InventoryManagementSystem.Controller;

namespace InventoryManagementSystem
{
    public partial class CustomerModuleForm : Form
    {
        CustomerController customerController;

        public CustomerModuleForm(CustomerController customerController)
        {
            this.customerController = customerController;
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {               
                if (MessageBox.Show("Are you sure you want to save this customer?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    customerController.Add(new Customer(customerController.NewID(), txtCName.Text, txtCPhone.Text));
                    MessageBox.Show("User has been successfully saved.");
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
            txtCName.Clear();
            txtCPhone.Clear();           
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           try
            { 
                if (MessageBox.Show("Are you sure you want to update this Customer?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    customerController.Update(new Customer(customerController.NewID(), txtCName.Text, txtCPhone.Text));
                    MessageBox.Show("Customer has been successfully updated!");
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
