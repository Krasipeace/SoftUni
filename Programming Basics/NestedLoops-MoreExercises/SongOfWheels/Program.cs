using System;

namespace SongOfWheels
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int controlNumberM = int.Parse(Console.ReadLine());
            int magicNumber = 0;
            int counter = 0;
            int passwordFirstNumber = 0;
            int passwordSecondNumber = 0;
            int passwordThirdNumber = 0;
            int passwordFourthNumber = 0;
            bool flag = false;
            for (int a = 1; a <= 9; a++)
            {
                for (int b = 1; b <= 9; b++)
                {
                    for (int c = 1; c <= 9; c++)
                    {
                        for (int d = 1; d <= 9; d++)
                        {
                            magicNumber = (a * b) + (c * d);
                            if (b > a && c > d && magicNumber == controlNumberM)
                            {
                                counter++;
                                Console.Write($"{a}{b}{c}{d} ");
                                if (counter == 4)
                                {
                                    passwordFirstNumber = a;
                                    passwordSecondNumber = b;
                                    passwordThirdNumber = c;
                                    passwordFourthNumber = d;

                                    flag = true;
                                }
                                else if (counter == 0)
                                {
                                    Console.WriteLine($"No!");
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            if (counter < 4)
            {
                Console.WriteLine();
                Console.WriteLine($"No!");
                return;
            }
            if (flag)
            {
                Console.WriteLine();
                Console.WriteLine($"Password: {passwordFirstNumber}{passwordSecondNumber}{passwordThirdNumber}{passwordFourthNumber}");
            }
        }
    }
}
