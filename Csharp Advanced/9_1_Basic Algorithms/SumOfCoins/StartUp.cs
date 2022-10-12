namespace SumOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp //greedy algorithm
    {
        public static void Main(string[] args)
        {
            int[] availableCoins = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            int targetSum = int.Parse(Console.ReadLine());

            var selectedCoins = ChooseCoins(availableCoins, targetSum);

            Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
            foreach (var item in selectedCoins)
            {
                Console.WriteLine($"{item.Value} coin(s) with value {item.Key}");
            }
        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            Dictionary<int, int> usedCoins = new Dictionary<int, int>();
            int currentSum = 0;
            int index = 0;

            coins = coins.OrderByDescending(x => x).ToList();

            while (currentSum < targetSum && index < coins.Count)
            {
                int lastCoin = coins[index++];
                if (currentSum + lastCoin <= targetSum)
                {
                    int coinsCount = (targetSum - currentSum) / lastCoin;
                    usedCoins.Add(lastCoin, coinsCount);
                    currentSum += lastCoin * coinsCount;
                }
            }
            if (currentSum == targetSum)
            {
                return usedCoins;
            }
            else
            {
                Console.WriteLine("Error");

                return null;
            }
        }
    }
}