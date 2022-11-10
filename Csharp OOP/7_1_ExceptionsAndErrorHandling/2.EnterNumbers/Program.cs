using System;

class EnterNumbers
{
    static void Main()
    {
        int currentStart = 1;
        int end = 100;
        int[] output = new int[10];

        for (int i = 0; i < 10; i++)
        {
            try
            {
                output[i] = ReadNumber(currentStart, end);
                currentStart = output[i];
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine($"Your number is not in range {currentStart} - {end}!");
                i--;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Number!");
                i--;
            }
        }

        Console.WriteLine(string.Join(", ", output));
    }

    static int ReadNumber(int start, int end)
    {
        int currentInput = int.Parse(Console.ReadLine());

        if (currentInput <= start || currentInput >= end)
        {
            throw new ArgumentOutOfRangeException();
        }

        return currentInput;
    }
}

