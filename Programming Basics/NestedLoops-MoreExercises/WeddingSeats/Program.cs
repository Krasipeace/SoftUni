using System;

namespace WeddingSeats
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char sector = char.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            int seats = int.Parse(Console.ReadLine());
            int factor = 0;
            int counter = 0;
            for (char i = 'A'; i <= sector; i++, rows++)
            {
                for (int j = 1; j <= rows; j++)
                {
                    factor = (j % 2 == 0) ? 2 : 0;
                    for (char k = 'a'; k < 'a' + seats + factor; k++)
                    {
                        Console.WriteLine($"{i}{j}{k}");
                        counter++;
                        
                    }
 
                }
            }
            Console.WriteLine(counter);
        }
    }
}
