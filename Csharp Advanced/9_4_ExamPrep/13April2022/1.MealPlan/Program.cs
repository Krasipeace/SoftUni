using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.MealPlan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int SALAD_CALORIES = 350;
            const int SOUP_CALORIES = 490;
            const int PASTA_CALORIES = 680;
            const int STEAK_CALORIES = 790;

            int mealsCounter = 0;

            Queue<string> meals = new Queue<string>(Console.ReadLine().Split(" ").ToArray());
            Stack<int> dailyIntake = new Stack<int>(Console.ReadLine().Split(" ").Select(c => int.Parse(c)).ToArray());

            while (meals.Count > 0 && dailyIntake.Count > 0)
            {
                int currentMealCalories = 0;
                string currentMeal = meals.Peek();

                currentMealCalories = GetCurrentMealCalories(SALAD_CALORIES, SOUP_CALORIES, PASTA_CALORIES, STEAK_CALORIES, currentMealCalories, currentMeal);

                meals.Dequeue();
                int currentDailyCalories = dailyIntake.Peek();

                if (currentMealCalories < currentDailyCalories)
                {
                    dailyIntake.Push(dailyIntake.Pop() - currentMealCalories);
                }
                else
                {
                    int dailyIntakeLeft = currentMealCalories - dailyIntake.Pop();
                    if (dailyIntake.Count != 0)
                    {
                        dailyIntake.Push(dailyIntake.Pop() - dailyIntakeLeft);
                    }
                }
                mealsCounter++;
            }
            PrintResults(mealsCounter, meals, dailyIntake);
        }

        static int GetCurrentMealCalories(int SALAD_CALORIES, int SOUP_CALORIES, int PASTA_CALORIES, int STEAK_CALORIES, int currentMealCalories, string currentMeal)
        {
            switch (currentMeal)
            {
                case "salad":
                    currentMealCalories = SALAD_CALORIES;
                    break;
                case "soup":
                    currentMealCalories = SOUP_CALORIES;
                    break;
                case "pasta":
                    currentMealCalories = PASTA_CALORIES;
                    break;
                case "steak":
                    currentMealCalories = STEAK_CALORIES;
                    break;
            }

            return currentMealCalories;
        }

        static void PrintResults(int mealsCounter, Queue<string> meals, Stack<int> dailyIntake)
        {
            if (meals.Count == 0)
            {
                Console.WriteLine($"John had {mealsCounter} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", dailyIntake)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {mealsCounter} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
            }
        }
    }
}
