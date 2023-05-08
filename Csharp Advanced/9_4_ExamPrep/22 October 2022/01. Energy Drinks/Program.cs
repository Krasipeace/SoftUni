namespace _01._Energy_Drinks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> caffeine = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Queue<int> drinks = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            int dailyLimit = 300;
            int currentCaffeine = 0;

            while (true)
            {
                if (caffeine.Any() && drinks.Any())
                {
                    int mgs = caffeine.Pop();
                    int currEnergy = drinks.Dequeue();
                    int sum = mgs * currEnergy;

                    if (sum + currentCaffeine <= dailyLimit)
                    {
                        currentCaffeine += sum;
                    }
                    else
                    {
                        if (currentCaffeine >= 30)
                        {
                            currentCaffeine -= 30;
                        }
                        drinks.Enqueue(currEnergy);
                    }
                }
                else
                {
                    break;
                }
            }

            if (drinks.Count > 0)
            {
                Console.WriteLine($"Drinks left: {string.Join(", ", drinks)}");
            }
            else
            {
                Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
            }
            Console.WriteLine($"Stamat is going to sleep with {currentCaffeine} mg caffeine.");
        }
    }
}