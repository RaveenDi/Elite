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
    public partial class Startup : Form
    {
        public static MongoDBService MongoDBService = new MongoDBService();

        public  static User User;

        public Startup(User user)
        {
            InitializeComponent();
            labelWelcome.Text = "Welcome " + user.FirstName + "!";
            User = user;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            if(textWeightGoal.Value <= 0 || numericUpDownDays.Value < 30 
                || comboBoxActivity.Text == "")
            {
                MessageBox.Show("Please enter folowing values.", "Start up failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            } else
            {
                WeightGoal weightGoal = new WeightGoal();
                weightGoal.Weight = Decimal.ToInt32((decimal)textWeightGoal.Value);
                weightGoal.Days = Decimal.ToInt32((decimal)numericUpDownDays.Value);
                User UpdatedUser = await MongoDBService.GetUserByUsername(User.Email);
                UpdatedUser.AveargeActivityType = Util.getTDEELevel(comboBoxActivity.Text);
                UpdatedUser.WeightGoal = weightGoal;

                await MongoDBService.Updateuser(User.Email, UpdatedUser);
                new Dashboard(User).Show();

            }
        }

        private void cm_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxActivity_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
