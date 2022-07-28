using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _2._Ad_Astra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([?<=#|\|])(?<foodType>[A-Za-z ]+)\1(?<foodDate>[\d]{2}\/[\d]{2}\/[\d]{2})\1(?<nutrition>[\d]+)\1";

            string input = Console.ReadLine();
            const int DAILY_CALORIES = 2000;
            int allFoodNutrition = 0;

            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);
            StringBuilder output = new StringBuilder();

            foreach (Match item in matches)
            {
                string foodType = item.Groups["foodType"].Value;
                string foodDate = item.Groups["foodDate"].Value;
                int foodNutrition = int.Parse(item.Groups["nutrition"].Value);
                
                allFoodNutrition += foodNutrition;

                output.AppendLine($"Item: {foodType}, Best before: {foodDate}, Nutrition: {foodNutrition}");
            }

            if (allFoodNutrition < DAILY_CALORIES)
            {
                Console.WriteLine("You have food to last you for: 0 days!");
            }
            else
            {
                Console.WriteLine($"You have food to last you for: {allFoodNutrition / DAILY_CALORIES} days!");
                Console.WriteLine(output.ToString());
            }
        }
    }
}
