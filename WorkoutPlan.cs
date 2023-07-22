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
    public partial class WorkoutPlan : Form
    {
        public static MongoDBService MongoDBService = new MongoDBService();

        public static User _user;

        List<Workout> _list = new List<Workout>();

        public WorkoutPlan(User user)
        {
            InitializeComponent();
            _user = user;
            getAllWorkoutPlans();
        }

        public async void getAllWorkoutPlans()
        {
            _user = await MongoDBService.GetUserByUsername(_user.Email);
            if (_user.Workouts == null)
            {
                _list = new List<Workout>();
            }
            else
            {
                _list = _user.Workouts.ToList();
            }

            MealList.DataSource = _list;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text == "" || textTime.Value == 0)
            {
                MessageBox.Show("Please fill the required fields.", "Start up failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                Workout workout = new Workout();
                workout.Id = Guid.NewGuid().ToString();
                workout.Name = textBoxName.Text;
                workout.Calorie = Decimal.ToInt32(textCalorie.Value);
                workout.Time = Decimal.ToInt32(textTime.Value);

                _list.Add(workout);
                User user = await MongoDBService.GetUserByUsername(_user.Email);
                user.Workouts = _list;
                await MongoDBService.Updateuser(_user.Email, user);
                getAllWorkoutPlans();
            }
        }

        private void MealList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textID.Text = MealList.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBoxName.Text = MealList.Rows[e.RowIndex].Cells[1].Value.ToString();
            textCalorie.Text = MealList.Rows[e.RowIndex].Cells[2].Value.ToString();
            textTime.Text = MealList.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            foreach (var meal in _list)
            {
                if (textID.Text == meal.Id)
                {
                    meal.Name = textBoxName.Text;
                    meal.Calorie = Decimal.ToInt32(textCalorie.Value);
                    meal.Time = Decimal.ToInt32(textTime.Value);
                    break;
                }
            }
            User user = await MongoDBService.GetUserByUsername(_user.Email);
            user.Workouts = _list;
            await MongoDBService.Updateuser(_user.Email, user);
            getAllWorkoutPlans();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            String ID = textID.Text;
            _list.RemoveAll(x => x.Id == ID);
            User user = await MongoDBService.GetUserByUsername(_user.Email);
            user.Workouts = _list;
            await MongoDBService.Updateuser(_user.Email, user);
            getAllWorkoutPlans();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Dashboard(_user).Show();
            this.Hide();
        }
    }
}
