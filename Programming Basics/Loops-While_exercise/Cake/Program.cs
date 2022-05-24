using System;

namespace Cake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cakeHeight = int.Parse(Console.ReadLine());
            int cakeWidth = int.Parse(Console.ReadLine());
            int cake = cakeWidth * cakeHeight;

            string input = Console.ReadLine();
            int takeCake = 0;
            
            while (input != "STOP")
            {
                int pieceCake = int.Parse(input);
                takeCake += pieceCake;
                if (takeCake > cake)
                {
                    Console.WriteLine($"No more cake left! You need {Math.Abs(takeCake - cake)} pieces more.");
                    break;
                }
                input = Console.ReadLine();
            }
            if (input == "STOP")
            {
                Console.WriteLine($"{cake - takeCake} pieces are left.");                
            }
        }
    }
}
