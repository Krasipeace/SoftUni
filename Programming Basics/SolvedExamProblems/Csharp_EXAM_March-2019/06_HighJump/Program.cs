using System;

namespace _06_HighJump
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int aim = int.Parse(Console.ReadLine());
            int training = aim - 30;
            int counterJ = 0;
            bool jIsFail = false;

            while (training <= aim)
            {
                for (int i = 1; i <= 3; i++)
                {
                    int currentTry = int.Parse(Console.ReadLine());
                    counterJ++;

                    if (currentTry > training)
                    {
                        training += 5;
                        break;
                    }
                    if (i == 3)
                    {
                        Console.WriteLine($"Tihomir failed at {training}cm after {counterJ} jumps.");
                        jIsFail = true;
                    }
                }
                if (jIsFail)
                {
                    break;
                }
            }
            if (!jIsFail)
            {
                Console.WriteLine($"Tihomir succeeded, he jumped over {aim}cm after {counterJ} jumps.");
            }
        }
    }
}
