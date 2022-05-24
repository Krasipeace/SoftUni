using System;

namespace RageExpenses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());
            double priceHeadset = double.Parse(Console.ReadLine());
            double priceMouse = double.Parse(Console.ReadLine());
            double priceKeyboard = double.Parse(Console.ReadLine());
            double priceDisplay = double.Parse(Console.ReadLine());

            int countHeadset = 0;
            int countMouse = 0;
            int countKeyboard = 0;
            int countDisplay = 0;

            for (int i = 1; i <= lostGames; i++)
            {
                if (i % 2 == 0)
                {
                    countHeadset++;
                }
                if (i % 3 == 0)
                {
                    countMouse++;
                }
                if (i % 6 == 0)
                {
                    countKeyboard++; 
                }
                if (i % 12 == 0)
                {
                    countDisplay++;
                }
            }
            double costHeadset = countHeadset * priceHeadset;
            double costMouse = countMouse * priceMouse;
            double costKeyboard = countKeyboard * priceKeyboard;
            double costDisplay = countDisplay * priceDisplay;
            double expenses = costHeadset + costMouse + costKeyboard + costDisplay;
            Console.WriteLine($"Rage expenses: {expenses:f2} lv.");
        }
    }
}
