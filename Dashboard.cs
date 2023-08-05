using Elite.Models;
using Elite.Service;
using Elite.Service;
using System;
using System.Drawing.Imaging;
using System.Drawing;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.IO;
using System.Drawing.Printing;
using System.Threading;

namespace Elite
{
    public partial class Dashboard : Form
    {
        public static BackendAPIService BackendAPI = new BackendAPIService();

        public static User updatedUser;

        Bitmap MemoryImage;

        private PrintDocument printDocument1 = new PrintDocument();

        private PrintPreviewDialog previewdlg = new PrintPreviewDialog();

        public Dashboard(User user)
        {
            InitializeComponent();

            printDocument1.PrintPage += new PrintPageEventHandler(printdoc1_PrintPage);

            updatedUser = user;
            double bmi = Util.getBMI(user);
            BMI.Text = bmi.ToString();

            string bmiStatus = Util.getBMIStatus(bmi);
            BMIStatus.Text = bmiStatus;

            GW.Text = updatedUser.WeightGoal.Weight.ToString() + " Kg";
            CurrentWeight.Text = updatedUser.Weight.ToString() + " Kg";

            double bmr = Util.GetBasalMetabolicRate(user);
            double bfp = Util.GetBodyFatPercentage(user);
            double tdeeValue = Util.getTDEEValue(updatedUser.AveargeActivityType);
            double tdee = Math.Round(bmr * tdeeValue, 2);

            BMR.Text = bmr.ToString() + " Calories";
            BFP.Text = bfp.ToString() + "%";
            TDEE.Text = tdee.ToString() + " Calories";

            Double CalorieAdjustment = 0;

            if (user.Weight > updatedUser.WeightGoal.Weight)
            {
                double SafeLooseWeightKgPerDay = 0.06;
                double DailyCalorie = 7700 * SafeLooseWeightKgPerDay;
                double CalorieDeficit = tdee - DailyCalorie;
                CalorieAdjustment = CalorieDeficit;

                ADC.Text = (Math.Round(CalorieDeficit, 2)).ToString() + " Calories";

                predict1.Text = (Math.Round((user.Weight - SafeLooseWeightKgPerDay * 7), 2)).ToString() + " Kg";
                predict2.Text = (Math.Round((user.Weight - SafeLooseWeightKgPerDay * 14), 2)).ToString() + " Kg";
                predict3.Text = (Math.Round((user.Weight - SafeLooseWeightKgPerDay * 21), 2)).ToString() + " Kg";
                predict4.Text = (Math.Round((user.Weight - SafeLooseWeightKgPerDay * 30), 2)).ToString() + " Kg";

                bmi1.Text = Util.getBMIStatus(Util.GetBMI(user.Height/100, (user.Weight - SafeLooseWeightKgPerDay * 7)));
                bmi2.Text = Util.getBMIStatus(Util.GetBMI(user.Height/100, (user.Weight - SafeLooseWeightKgPerDay * 14)));
                bmi3.Text = Util.getBMIStatus(Util.GetBMI(user.Height/100, (user.Weight - SafeLooseWeightKgPerDay * 21)));
                bmi4.Text = Util.getBMIStatus(Util.GetBMI(user.Height/100, (user.Weight - SafeLooseWeightKgPerDay * 30)));

            } else
            {
                double SafeGainWeightKgPerDay = 0.06;
                double DailyCalorie = 7700 * SafeGainWeightKgPerDay;
                double CalorieDeficit = tdee + DailyCalorie;
                CalorieAdjustment = CalorieDeficit;
                ADC.Text = (Math.Round(CalorieDeficit, 2)).ToString() + " Calories";

                predict1.Text = (Math.Round((user.Weight + SafeGainWeightKgPerDay * 7), 2)).ToString();
                predict2.Text = (Math.Round((user.Weight + SafeGainWeightKgPerDay * 14), 2)).ToString();
                predict3.Text = (Math.Round((user.Weight + SafeGainWeightKgPerDay * 21), 2)).ToString();
                predict4.Text = (Math.Round((user.Weight + SafeGainWeightKgPerDay * 30), 2)).ToString();

                bmi1.Text = Util.getBMIStatus(Math.Round(Util.GetBMI(user.Height / 100, (user.Weight + SafeGainWeightKgPerDay * 7)), 2));
                bmi2.Text = Util.getBMIStatus(Math.Round(Util.GetBMI(user.Height / 100, (user.Weight + SafeGainWeightKgPerDay * 14)), 2));
                bmi3.Text = Util.getBMIStatus(Math.Round(Util.GetBMI(user.Height / 100, (user.Weight + SafeGainWeightKgPerDay * 21)), 2));
                bmi4.Text = Util.getBMIStatus(Math.Round(Util.GetBMI(user.Height / 100, (user.Weight + SafeGainWeightKgPerDay * 30)), 2));
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
            new MealPlan(updatedUser).Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new WorkoutPlan(updatedUser).Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Profile(updatedUser).Show();
            this.Hide();
        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Print(this.panel1);
        }

        public void Print(Panel pnl)
        {
            Panel pannel = pnl;
            GetPrintArea(pnl);
            previewdlg.Document = printDocument1;
            previewdlg.ShowDialog();
        }

        public void GetPrintArea(Panel pnl)
        {
            MemoryImage = new Bitmap(pnl.Width, pnl.Height);
            pnl.DrawToBitmap(MemoryImage, new Rectangle(0, 0, pnl.Width, pnl.Height));
        }

        void printdoc1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(MemoryImage, (pagearea.Width / 2) - (this.panel1.Width / 2), this.panel1.Location.Y);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (MemoryImage != null)
            {
                e.Graphics.DrawImage(MemoryImage, 0, 0);
                Thread t1 = new Thread(() => base.OnPaint(e));
                t1.Start();
            }
        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void BMIStatus_Click(object sender, EventArgs e)
        {

        }
    }
}
