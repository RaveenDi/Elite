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

namespace Elite
{
    public partial class Profile : Form
    {
        public static MongoDBService MongoDBService = new MongoDBService();

        public static User _user;

        public Profile(User User)
        {
            InitializeComponent();
            _user = User;
            fname.Text = _user.FirstName;
            lname.Text = _user.LastName;
            age.Value = _user.Age;
            weight.Value = (decimal)_user.Weight;
            height.Value = (decimal)_user.Height;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await MongoDBService.RemoveUser(_user.Id);
            new LoginForm().Show();
            this.Hide();
        }

        private async void button2_Click(object sender, EventArgs e)
        {

            User user = await MongoDBService.GetUserByUsername(_user.Email);
            user.FirstName = fname.Text;
            user.LastName = lname.Text;
            user.Age = Decimal.ToInt32(age.Value);
            user.Height = Decimal.ToInt32(height.Value);
            user.Weight = Decimal.ToInt32(weight.Value);
            await MongoDBService.Updateuser(_user.Email, user);
            MessageBox.Show("Successfully uppdate.", "Start up success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Dashboard(_user).Show();
            this.Hide();
        }
    }
}
