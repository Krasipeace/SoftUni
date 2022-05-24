using System;

namespace While1
{
    class Program
    {
        static void Main(string[] args)
        {
            string alphaString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
                "abcdefghijklmnopqrstuvwxyz";
            string input = Console.ReadLine();
            string word = string.Empty;
            string wordOutput = string.Empty;
            int countN = 0;
            int countO = 0;
            int countC = 0;

            while (input != "End")
            {
                bool isLetter = char.TryParse(input, out char letter);

                if (isLetter && alphaString.Contains(input))
                {
                    if (letter == 'n' && countN == 0)
                    {
                        countN++;
                    }
                    else if (letter == 'o' && countO == 0)
                    {
                        countO++;
                    }
                    else if (letter == 'c' && countC == 0)
                    {
                        countC++;
                    }
                    else
                    {
                        word += letter;
                    }

                    if (countN == 1 && countO == 1 && countC == 1)
                    {
                        word += " ";
                        wordOutput = word;
                        countN = 0;
                        countO = 0;
                        countC = 0;
                    }
                }
                else
                {
                    input = Console.ReadLine();
                    continue;
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"{wordOutput}");
        }
    }
}
