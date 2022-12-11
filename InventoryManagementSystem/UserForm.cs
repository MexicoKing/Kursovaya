using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class UserForm : Form
    {
        UserController userController;
        public UserForm()
        {
            userController = new UserController();
            InitializeComponent();
            LoadUser();
        }

        public void LoadUser()
        {
            dgvUser.Rows.Clear();

            List<User> users = userController.LoadData();
            int i = 0;
            foreach (var item in users)
            {
                i++;
                dgvUser.Rows.Add(i, item.UserName, item.FullName, item.Password, item.Phone);
            }
        }

        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvUser.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                UserModuleForm userModule = new UserModuleForm(userController);
                userModule.txtUserName.Text = dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString();
                userModule.txtFullName.Text = dgvUser.Rows[e.RowIndex].Cells[2].Value.ToString();
                userModule.txtPass.Text = dgvUser.Rows[e.RowIndex].Cells[3].Value.ToString();
                userModule.txtRepass.Text = userModule.txtPass.Text;
                userModule.txtPhone.Text = dgvUser.Rows[e.RowIndex].Cells[4].Value.ToString();

                userModule.btnSave.Enabled = false;
                userModule.btnUpdate.Enabled = true;
                userModule.txtUserName.Enabled = false;
                userModule.ShowDialog(); 
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this user?","Delete Record",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    userController.Remove(dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString());
                    MessageBox.Show("Record has been successfully deleted!");
                }
            }
            LoadUser();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            UserModuleForm userModule = new UserModuleForm(userController);
            userModule.btnSave.Enabled = true;
            userModule.btnUpdate.Enabled = false;
            userModule.ShowDialog();
            LoadUser();
        }
    }
}
