using InventoryManagementSystem.Controller;
using InventoryManagementSystem.Model;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class OrderModuleForm : Form
    {
        OrderController orderController;
        CustomerController customerController;
        ProductController productController;
        int qty = 0;
        public OrderModuleForm(OrderController orderController, CustomerController customerController, ProductController productController)
        {
            this.orderController = orderController;
            this.customerController = customerController;
            this.productController = productController;
            InitializeComponent();
            LoadCustomer();
            LoadProduct();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void LoadCustomer()
        {
            int i = 0;
            dgvCustomer.Rows.Clear();
            foreach(Customer customer in customerController.LoadData())
            {
                i++;
                dgvCustomer.Rows.Add(i, customer.CustomerId, customer.FullName);
            }
        }

        public void LoadProduct()
        {
            int i = 0;
            dgvProduct.Rows.Clear();
            foreach (Product product in productController.LoadData())
            {
                i++;
                dgvProduct.Rows.Add(i, product.ProductId, product.ProductName, product.Quantity, product.Price, product.Desctiption, product.Category);
            }
        }

        private void txtSearchCust_TextChanged(object sender, EventArgs e)
        {
            LoadCustomer();
        }

        private void txtSearchProd_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }

        
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt16(UDQty.Value) > qty)
            {
                MessageBox.Show("Instock quantity is not enough!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                UDQty.Value = UDQty.Value - 1;
                return;
            }
            if (Convert.ToInt16(UDQty.Value) > 0)
            {
                int total = Convert.ToInt16(txtPrice.Text) * Convert.ToInt16(UDQty.Value);
                txtTotal.Text = total.ToString();
            }
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCId.Text = dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtCName.Text = dgvCustomer.Rows[e.RowIndex].Cells[2].Value.ToString();
        }
        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtPid.Text = dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPName.Text = dgvProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtPrice.Text = dgvProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtDescription.Text = dgvProduct.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtCategory.Text = dgvProduct.Rows[e.RowIndex].Cells[6].Value.ToString();
            qty = Convert.ToInt16(dgvProduct.Rows[e.RowIndex].Cells[3].Value.ToString());
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCId.Text == "")
                {
                    MessageBox.Show("Please select customer!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtPid.Text == "")
                {
                    MessageBox.Show("Please select product!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Are you sure you want to insert this order?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MessageBox.Show("Order has been successfully inserted.");
                    qty -= Convert.ToInt16(UDQty.Value);
                    productController.Update(new Product(int.Parse(txtPid.Text), txtPName.Text, qty, int.Parse(txtPrice.Text), txtDescription.Text, txtCategory.Text));
                    orderController.Add(new Order (orderController.NewID(), dtOrder.Value, int.Parse(txtPid.Text), txtPName.Text, int.Parse(txtCId.Text), txtCName.Text, Convert.ToInt16(UDQty.Value), int.Parse(txtPrice.Text), Convert.ToInt16(UDQty.Value)*int.Parse(txtPrice.Text)));
                    Clear();
                    LoadProduct();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Clear()
        {
            txtCId.Clear();
            txtCName.Clear();

            txtPid.Clear();
            txtPName.Clear();

            txtPrice.Clear();
            UDQty.Value = 0;
            txtTotal.Clear();
            dtOrder.Value = DateTime.Now;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();                        
        }
    }
}
