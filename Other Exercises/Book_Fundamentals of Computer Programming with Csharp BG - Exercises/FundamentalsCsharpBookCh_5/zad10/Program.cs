using System;

namespace zad10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //10.   Напишете програма, която прилага бонус точки към дадени точки в интервала [1..9] чрез прилагане на следните правила:
            //-Ако точките са между 1 и 3, програмата ги умножава по 10.         
            //- Ако точките са между 4 и 6, ги умножава по 100.
            // - Ако точките са между 7 и 9, ги умножава по 1000.
            //- Ако точките са 0 или повече от 9, се отпечатва съобщение за грешка.

            Console.Write("Enter a number (1-9): ");
            byte number = byte.Parse(Console.ReadLine());
            int numberEnd = 0;

            if (number >= 1 && number <= 3)
            {
                numberEnd = number * 10;
            }
            else if (number >= 4 && number <= 6)
            {
                numberEnd = number * 100;
            }
            else if (number >= 7 && number <= 9)
            {
                numberEnd = number * 1000;
            }
            else
            {
                Console.WriteLine("Error! You entered 0 points or number bigger than 9");
                return;
            }
            Console.WriteLine($"Bonus points equals to: {numberEnd}");
        }
    }
}
