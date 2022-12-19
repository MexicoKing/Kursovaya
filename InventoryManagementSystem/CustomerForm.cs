using System;
using System.Collections.Generic;
using System.Windows.Forms;
using InventoryManagementSystem.Controller;

namespace InventoryManagementSystem
{
    public partial class CustomerForm : Form
    {
        CustomerController customerController;
        public CustomerForm()
        {
            customerController = new CustomerController();
            InitializeComponent();
            LoadCustomer();
        }
        public CustomerController CustomerController
        {
            get { return customerController; }
        }
        public void LoadCustomer()
        {
            dgvCustomer.Rows.Clear();
            int i = 0;
            List<Customer> customers = customerController.LoadData();
            foreach (Customer customer in customers)
            {
                i++;
                dgvCustomer.Rows.Add(i, customer.CustomerId.ToString(), customer.FullName, customer.Phone);
            }
        }

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvCustomer.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                CustomerModuleForm customerModule = new CustomerModuleForm(customerController);
                customerModule.lblCId.Text = dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
                customerModule.txtCName.Text = dgvCustomer.Rows[e.RowIndex].Cells[2].Value.ToString();
                customerModule.txtCPhone.Text = dgvCustomer.Rows[e.RowIndex].Cells[3].Value.ToString();

                customerModule.btnSave.Enabled = false;
                customerModule.btnUpdate.Enabled = true;
                customerModule.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this customer?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    customerController.Remove(dgvCustomer.Rows[e.RowIndex].Cells[2].Value.ToString());
                    MessageBox.Show("Record has been successfully deleted!");
                }
            }
            LoadCustomer();
        }

        private void btnAddCstm_Click(object sender, EventArgs e)
        {
            CustomerModuleForm moduleForm = new CustomerModuleForm(customerController);
            moduleForm.btnSave.Enabled = true;
            moduleForm.btnUpdate.Enabled = false;
            moduleForm.ShowDialog();
            LoadCustomer();
        }
    }
}
