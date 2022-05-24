using System;

namespace Number100to200
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // чете цяло число .. под 100 = less than 100 ; m/u 100 и 200 = between 100 and 200 ; над 200 = greater than 200
            int number = int.Parse(Console.ReadLine());
            if (number < 100)
            {
                Console.WriteLine("Less than 100");
            }
            else if (number >= 100 && number <= 200)
            {
                Console.WriteLine("Between 100 and 200");
            }
            else
            {
                Console.WriteLine("Greater than 200");
            }
        }
    }
}
