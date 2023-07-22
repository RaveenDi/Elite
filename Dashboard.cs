using Elite.Models;
using EliteBackend.Services;
using System;
using System.Windows.Forms;

namespace Elite
{
    public partial class Dashboard : Form
    {
        public static MongoDBService MongoDBService = new MongoDBService();

        public static User User;

        public Dashboard(User user)
        {
            InitializeComponent();
            User = user;
            double UserHeight = User.Height / 100;
            double UserWeight = User.Weight;
            BMI.Text = (Math.Round(Util.GetBMI(UserHeight, user.Weight), 2)).ToString();
            BMIStatus.Text = Util.getBMIStatus(Util.GetBMI((User.Height/100), user.Weight));
            GW.Text = User.WeightGoal.Weight.ToString() + " Kg";
            CurrentWeight.Text =  User.Weight.ToString() + " Kg";
            BMR.Text = (Math.Round(Util.GetBasalMetabolicRate(User.Sex, User.Height, user.Weight, User.Age), 2)).ToString() + " Calories";
            BFP.Text = (Math.Round(Util.GetBodyFatPercentage(User.Sex, User.Height, User.Waist, User.Neck, User.Hip), 2)).ToString() + "%";
            TDEE.Text = (Math.Round(Util.GetBasalMetabolicRate(User.Sex, User.Height, user.Weight, User.Age), 2) * Util.getTDEEValue(User.AveargeActivityType)).ToString() + " Calories";
            Double CalorieAdjustment = 0;

            if (user.Weight > User.WeightGoal.Weight)
            {
                double SafeLooseWeightKgPerDay = 0.06;
                double tdee = Util.GetBasalMetabolicRate(User.Sex, User.Height, user.Weight, User.Age) * Util.getTDEEValue(User.AveargeActivityType);
                double DailyCalorie = 7700* SafeLooseWeightKgPerDay;
                double CalorieDeficit = tdee - DailyCalorie;
                CalorieAdjustment = CalorieDeficit;
                ADC.Text = (Math.Round(CalorieDeficit, 2)).ToString() + " Calories";

                predict1.Text = (Math.Round((user.Weight - SafeLooseWeightKgPerDay * 7), 2)).ToString() + " Kg";
                predict2.Text = (Math.Round((user.Weight - SafeLooseWeightKgPerDay * 14), 2)).ToString() + " Kg";
                predict3.Text = (Math.Round((user.Weight - SafeLooseWeightKgPerDay * 21), 2)).ToString() + " Kg";
                predict4.Text = (Math.Round((user.Weight - SafeLooseWeightKgPerDay * 30), 2)).ToString() + " Kg";

                bmi1.Text = Util.getBMIStatus(Math.Round(Util.GetBMI(UserHeight, (user.Weight - SafeLooseWeightKgPerDay * 7)), 2));
                bmi2.Text = Util.getBMIStatus(Math.Round(Util.GetBMI(UserHeight, (user.Weight - SafeLooseWeightKgPerDay * 14)), 2));
                bmi3.Text = Util.getBMIStatus(Math.Round(Util.GetBMI(UserHeight, (user.Weight - SafeLooseWeightKgPerDay * 21)), 2));
                bmi4.Text = Util.getBMIStatus(Math.Round(Util.GetBMI(UserHeight, (user.Weight - SafeLooseWeightKgPerDay * 30)), 2));

            } else
            {
                double SafeGainWeightKgPerDay = 0.06;
                double tdee = Util.GetBasalMetabolicRate(User.Sex, User.Height, user.Weight, User.Age) * Util.getTDEEValue(User.AveargeActivityType);
                double DailyCalorie = 7700* SafeGainWeightKgPerDay;
                double CalorieDeficit = tdee + DailyCalorie;
                CalorieAdjustment = CalorieDeficit;
                ADC.Text = (Math.Round(CalorieDeficit, 2)).ToString() + " Calories";

                predict1.Text = (Math.Round((user.Weight + SafeGainWeightKgPerDay * 7), 2)).ToString();
                predict2.Text = (Math.Round((user.Weight + SafeGainWeightKgPerDay * 14), 2)).ToString();
                predict3.Text = (Math.Round((user.Weight + SafeGainWeightKgPerDay * 21), 2)).ToString();
                predict4.Text = (Math.Round((user.Weight + SafeGainWeightKgPerDay * 30), 2)).ToString();

                bmi1.Text = Util.getBMIStatus(Math.Round(Util.GetBMI(UserHeight, (user.Weight + SafeGainWeightKgPerDay * 7)), 2));
                bmi2.Text = Util.getBMIStatus(Math.Round(Util.GetBMI(UserHeight, (user.Weight + SafeGainWeightKgPerDay * 14)), 2));
                bmi3.Text = Util.getBMIStatus(Math.Round(Util.GetBMI(UserHeight, (user.Weight + SafeGainWeightKgPerDay * 21)), 2));
                bmi4.Text = Util.getBMIStatus(Math.Round(Util.GetBMI(UserHeight, (user.Weight + SafeGainWeightKgPerDay * 30)), 2));
            }

            CarbAL.Text = (Math.Round((CalorieAdjustment * 0.5), 2).ToString() + " Calories");
            FatAL.Text = (Math.Round((CalorieAdjustment * 0.2), 2).ToString() + " Calories");
            ProAL.Text = (Math.Round((CalorieAdjustment * 0.3), 2).ToString() + " Calories");

            CarbGA.Text = (Math.Round(((CalorieAdjustment * 0.5) / 4), 2).ToString() + " g");
            FatGA.Text = (Math.Round(((CalorieAdjustment * 0.5) / 9), 2).ToString() + " g");
            ProGA.Text = (Math.Round(((CalorieAdjustment * 0.5) / 4), 2).ToString() + " g");



        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click_1(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click_1(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            new MealPlan(User).Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new WorkoutPlan(User).Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Profile(User).Show();
            this.Hide();
        }

        private void label25_Click(object sender, EventArgs e)
        {

        }
    }
}
