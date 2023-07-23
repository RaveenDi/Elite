using Elite.Models;
using Elite.Service;
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
    public partial class AdditionalDetailsForm1 : Form
    {
        public static BackendAPIService BackendAPI = new BackendAPIService();

        public static User _user;

        public AdditionalDetailsForm1(User user)
        {
            InitializeComponent();
            _user = user;
            labelWelcome.Text = "Welcome " + user.FirstName + "!";
            textHeight.Value = (decimal)_user.Height;
            textNeck.Value = (decimal)_user.Neck;
            textWaist.Value = (decimal)_user.Waist;
            textWeight.Value = (decimal)_user.Weight;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private async void buttonDone_Click(object sender, EventArgs e)
        {
            if(textHeight.Value <= 0 || textNeck.Value <= 0 || textWaist.Value <= 0
                || textWeight.Value <= 0 || textHip.Value <= 0)
            {
                MessageBox.Show("Please enter measured values.", "Start up failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                User UpdatedUser = await BackendAPI.GetUserAsync(_user.Email);
                UpdatedUser.Height = Decimal.ToInt32((decimal)textHeight.Value);
                UpdatedUser.Neck = Decimal.ToInt32((decimal)textNeck.Value);
                UpdatedUser.Waist = Decimal.ToInt32((decimal)textWaist.Value);
                UpdatedUser.Weight = Decimal.ToInt32((decimal)textWeight.Value);
                UpdatedUser.Hip = Decimal.ToInt32((decimal)textHip.Value);
                await BackendAPI.Updateuser(_user.Email, UpdatedUser);
                new Startup(_user).Show();
                this.Hide();
            }
        }

        private void labelWelcome_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
