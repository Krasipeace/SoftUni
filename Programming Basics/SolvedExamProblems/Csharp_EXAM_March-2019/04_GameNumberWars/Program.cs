using System;

namespace _04_GameNumberWars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string playerOne = Console.ReadLine();
            string playerTwo = Console.ReadLine();
            int pOnePoints = 0;
            int pTwoPoints = 0;
            string cardPlayerOne = Console.ReadLine();

            while (cardPlayerOne != "End of game")
            {
                string cardPlayerTwo = Console.ReadLine();
                int pOneGamePoints = int.Parse(cardPlayerOne);
                int pTwoGamePoints = int.Parse(cardPlayerTwo);
                if (pOneGamePoints > pTwoGamePoints)
                {
                    pOnePoints += pOneGamePoints - pTwoGamePoints;
                }
                else if (pOneGamePoints < pTwoGamePoints)
                {
                    pTwoPoints += pTwoGamePoints - pOneGamePoints;
                }
                else
                {
                    Console.WriteLine("Number wars!");
                    int pOneWarCard = int.Parse(Console.ReadLine());
                    int pTwoWarCard = int.Parse(Console.ReadLine());
                    if (pOneWarCard > pTwoWarCard)
                    {
                        Console.WriteLine($"{playerOne} is winner with {pOnePoints} points");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"{playerTwo} is winner with {pTwoPoints} points");
                        break;
                    }

                }
                cardPlayerOne = Console.ReadLine();
            }
            if (cardPlayerOne == "End of game")
            {
                Console.WriteLine($"{playerOne} has {pOnePoints} points");
                Console.WriteLine($"{playerTwo} has {pTwoPoints} points");
            }

        }
    }
}
