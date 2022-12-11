using System;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void labelClear_Click(object sender, EventArgs e)
        {
            textPass.Clear();
            textName.Clear();
        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxShowPassword.Checked)
            {
                textPass.UseSystemPasswordChar = true;
            }
            else
            {
                textPass.UseSystemPasswordChar = false;
            }
        }

        private void pictureBoxCloseForm_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Applicaton?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                /*MessageBox.Show("Welcome " + textName.Text + " ! ", "ACCESS GRANTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainForm main = new MainForm();
                this.Hide();
                main.ShowDialog();*/
                if (textPass.Text == "123" && textName.Text == "Admin")
                {
                    MessageBox.Show("Welcome " + textName.Text + " ! ", "ACCESS GRANTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainForm main = new MainForm();
                    this.Hide();
                    main.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Invalid username or password!", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
