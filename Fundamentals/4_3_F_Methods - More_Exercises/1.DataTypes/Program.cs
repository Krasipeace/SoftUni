using System;

namespace _1.DataTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            switch (command)
            {
                case "int":
                    int inputInt = int.Parse(Console.ReadLine());
                    Console.WriteLine(GetType(inputInt));
                    break;
                case "real":
                    double inputReal = double.Parse(Console.ReadLine());
                    Console.WriteLine(GetType($"{inputReal:f2}"));
                    break;
                case "string":
                    string inputString = Console.ReadLine();
                    Console.WriteLine(GetType($"{inputString}"));
                    break;
            }

        }

        static int GetType(int inputInt)
        {
            int result = 0;
            result = inputInt * 2;
            return result;
        }

        static double GetType(double inputReal)
        {
            double result = 0.0;
            result = (double)inputReal * 1.5;
            return result;
        }

        private static string GetType(string inputString) //hm...
        {
            string result = string.Empty;
            result = "$" + inputString + "$";
            return result;
        }
    }
}
