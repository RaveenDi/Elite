using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Util
{
    public static double GetBMI(double height, double weight) => (double)(weight / Math.Pow(height, 2));

    public static double GetBodyFatPercentage(string sex, double height, double waist, double neck, double hip)
    {
        if (sex.Equals("MALE"))
        {
            double value = 1.0324 - 0.19077 * Math.Log10(waist - neck) + 0.15456 * Math.Log10(height);
            return (495 / value) - 450;
        }
        else
        {
            double value = 1.29579 - 0.35004 * Math.Log10(waist + hip - neck) + 0.022100 * Math.Log10(height);
            return (495 / value) - 450;
        }
    }

    public static double GetBasalMetabolicRate(string sex, double height, double weight, int age)
    {
        if (sex.Equals("MALE"))
        {
            return 88.362 + (13.397 * weight) + (4.799 * height) - (5.677 * age);
        }
        else
        {
            return 447.593 + (9.247 * weight) + (3.098 * height) - (4.330 * age);
        }
    }

    public static string getBMIStatus(Double value)
    {
        if (value >= 30.0)
        {
            return "Obese";
        }
        else if (value >= 25.0)
        {
            return "Overweight";
        }
        else if (value > 18.5)
        {
            return "Healthy";
        }
        else
            return "Underweight";
    }

    public static double getTDEEValue(String value)
    {
        if (value == "L1")
        {
            return 1.2;
        }
        else if (value == "L2")
        {
            return 1.375;
        }
        else if (value == "L3")
        {
            return 1.55;
        }
        else if (value == "L4")
        {
            return 1.725;
        }
        else
        {
            return 1.9;
        }
    }

    public static string getTDEELevel(String value)
    {
        if (value == "Sedentary (little to no exercise + work a desk job)")
        {
            return "L1";
        }
        else if (value == "Lightly Active (light exercise 1-3 days / week)")
        {
            return "L2";
        }
        else if (value == "Moderately Active (moderate exercise 3-5 days / week)")
        {
            return "L3";
        }
        else if (value == "Very Active (heavy exercise 6-7 days / week)")
        {
            return "L4";
        }
        else
        {
            return "L5";
        }
    }
}