using System;

namespace _04_EasterEggsBattle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pOneEggs = int.Parse(Console.ReadLine());
            int pTwoEggs = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            while (input != "End of battle")
            {

                if (input == "one")
                {                    
                    pTwoEggs--;
                }
                else if (input == "two")
                {                    
                    pOneEggs--;
                }

                if (pOneEggs == 0)
                {
                    Console.WriteLine($"Player one is out of eggs. Player two has {pTwoEggs} eggs left.");
                    break;
                }
                else if (pTwoEggs == 0)
                {
                    Console.WriteLine($"Player two is out of eggs. Player one has {pOneEggs} eggs left.");
                    break;
                }
                input = Console.ReadLine();
            }
            if (input == "End of battle")
            {
                Console.WriteLine($"Player one has {pOneEggs} eggs left.");
                Console.WriteLine($"Player two has {pTwoEggs} eggs left.");
            }
        }
    }
}
