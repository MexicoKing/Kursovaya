using InventoryManagementSystem.Controller;
using System;
using System.Collections.Generic;
using InventoryManagementSystem.Model;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class OrderForm : Form
    {
        OrderController orderController;
        CustomerController customerController;
        ProductController productController;
        public OrderForm(CustomerController customerController, ProductController productController)
        {
            orderController = new OrderController();
            this.customerController = customerController;
            this.productController = productController;
            InitializeComponent();
            LoadOrder();
        }

        public void LoadOrder()
        {
            double total = 0;
            int i = 0;
            dgvOrder.Rows.Clear();
            List<Order> orders = orderController.LoadData();
            foreach (var item in orders)
            {
                i++;
                dgvOrder.Rows.Add(i, item.OrderId.ToString(), Convert.ToDateTime(item.OrderDate.ToString()).ToString("dd/MM/yyyy"), item.ProductId.ToString(), item.ProductName.ToString(), item.CustomerId.ToString(), item.CustomerName.ToString(), item.Quantity.ToString(), item.Price.ToString(), item.TotalAmount.ToString());
                total += Convert.ToInt32(item.TotalAmount.ToString());
            }
            lblQty.Text = i.ToString();
            lblTotal.Text = total.ToString();
        }

        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvOrder.Columns[e.ColumnIndex].Name;

            if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this order?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    orderController.Remove(dgvOrder.Rows[e.RowIndex].Cells[4].Value.ToString());
                    MessageBox.Show("Record has been successfully deleted!");
                }
            }
            LoadOrder();
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            OrderModuleForm moduleForm = new OrderModuleForm(orderController, customerController, productController);
            moduleForm.ShowDialog();
            LoadOrder();
        }
    }
}
