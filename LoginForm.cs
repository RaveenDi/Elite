using Elite.Models;
using EliteBackend.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Elite
{
    public partial class LoginForm : Form
    {
        public static MongoDBService MongoDBService = new MongoDBService();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private async void buttonLogin_Click(object sender, EventArgs e)
        {
            if(textUsername.Text == "" && textPassword.Text == "")
            {
                MessageBox.Show("Username or Password field is empty.", "login failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                User user = await MongoDBService.GetUserByUsername(textUsername.Text);
                if (user == null || textPassword.Text != user.Password)
                {
                    MessageBox.Show("Username or Password is incorrect.", "login failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else
                {
                    new Dashboard(user).Show();
                    this.Hide();
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            new RegisterForm().Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
