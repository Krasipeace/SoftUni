namespace Sum_Evens_in_Background
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long sum = 0;

            var task = Task.Run(() =>
            {
                for (long i = 0; i < 10000000000; i++)
                {
                    if (i % 2 == 0)
                    {
                        sum += i;
                    }
                }
            });

            while (true)
            {
                var command = Console.ReadLine();
                if (command == "exit")
                {
                    return;
                }
                else if (command == "show")
                {
                    Console.WriteLine(sum);
                }
            }
        }
    }
}