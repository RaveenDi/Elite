using Elite.Models;
using Elite.Service;
using MongoDB.Driver;
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
    public partial class MealPlan : Form
    {
        public static BackendAPIService BackendAPI = new BackendAPIService();

        public static User _user;

        List<Meal> _list = new List<Meal>();

        public MealPlan(User user)
        {
            InitializeComponent();
            _user = user;
            getAllMealPlans();
        }

        public async void getAllMealPlans()
        {
            _user = await BackendAPI.GetUserAsync(_user.Email);
            if(_user.Meals == null) {
                _list = new List<Meal>();
            } else
            {
                _list = _user.Meals.ToList(); 
            }
            
            MealList.DataSource = _list;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            String ID = textID.Text;
            _list.RemoveAll(x => x.Id == ID);
            User user = await BackendAPI.GetUserAsync(_user.Email);
            user.Meals = _list;
            await BackendAPI.Updateuser(_user.Email, user);
            getAllMealPlans();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if(textBoxName.Text == "" || textQuantity.Value == 0)
            {
                MessageBox.Show("Please fill the required fields.", "Start up failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            } else
            {
                Meal meal = new Meal();
                meal.Id = Guid.NewGuid().ToString();
                meal.Name = textBoxName.Text;
                meal.Calorie = Decimal.ToInt32(textCalorie.Value);
                meal.Quantity = Decimal.ToInt32(textQuantity.Value);

                _list.Add(meal);
                User user =  await BackendAPI.GetUserAsync(_user.Email);
                user.Meals = _list;
                await BackendAPI.Updateuser(_user.Email, user);
                getAllMealPlans();
            }
        }

        private void MealList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textID.Text = MealList.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBoxName.Text = MealList.Rows[e.RowIndex].Cells[1].Value.ToString();
            textCalorie.Text = MealList.Rows[e.RowIndex].Cells[2].Value.ToString();
            textQuantity.Text = MealList.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            foreach (var meal in _list)
            {
                if(textID.Text == meal.Id)
                {
                    meal.Name = textBoxName.Text;
                    meal.Calorie = Decimal.ToInt32(textCalorie.Value);
                    meal.Quantity = Decimal.ToInt32(textQuantity.Value);
                    break;
                }
            }
            User user = await BackendAPI.GetUserAsync(_user.Email);
            user.Meals = _list;
            await BackendAPI.Updateuser(_user.Email, user);
            getAllMealPlans();

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Dashboard(_user).Show();
            this.Hide();
        }
    }
}
