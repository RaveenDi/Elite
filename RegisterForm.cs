using Elite.Models;
using Elite.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elite
{
    public partial class RegisterForm : Form
    {
        public static BackendAPIService BackendAPI = new BackendAPIService();

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            new LoginForm().Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textConfirmPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void textPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void textUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async void buttonRegister_ClickAsync(object sender, EventArgs e)
        {
            if (textUsername.Text == "" || textPassword.Text == ""
                || textConfirmPassword.Text == ""
                || textFirstName.Text == "" || textLastName.Text == ""
                || (!radioMale.Checked && !radioFemale.Checked))
            {
                MessageBox.Show("All fields are required.", "Registration failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textPassword.Text != textConfirmPassword.Text)
            {
                MessageBox.Show("passwords are not matching.", "Registration failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!IsValidEmailAddress(textUsername.Text))
            {
                MessageBox.Show("Email Should be valid email address.", "Registration failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!IsCharacterLengthValid(textPassword.Text, 5))
            {
                MessageBox.Show("Email Should be valid email address.", "Registration failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                User userExisting = await BackendAPI.GetUserAsync(textUsername.Text);
                if (userExisting != null)
                {
                    MessageBox.Show("User is already exists.", "Registration failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    User user = new User();
                    user.Id = Guid.NewGuid().ToString();
                    user.Email = textUsername.Text;
                    user.Password = textPassword.Text;
                    user.FirstName = textFirstName.Text;
                    user.LastName = textLastName.Text;
                    user.Age = Decimal.ToInt32((decimal)textAge.Value);
                    user.Sex = radioMale.Checked ? "MALE" : "FEMALE";
                    bool result = await BackendAPI.AddUser(user);
                    if(!result)
                    {
                        MessageBox.Show("Regesitration is failed .", "Registration failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } else
                    {
                        new AdditionalDetailsForm1(user).Show();
                        this.Hide();
                    }
                }

            }
        }

        private bool IsValidEmailAddress(String email)
        {
            try
            {
                MailAddress m = new MailAddress(email);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private bool IsCharacterLengthValid(String Text, int Length)
        {
            return Text.Length >= Length;
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
