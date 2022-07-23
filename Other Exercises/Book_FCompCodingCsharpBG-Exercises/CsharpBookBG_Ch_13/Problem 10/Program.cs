using System;
using System.Text;

namespace Problem_10 //task 12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number: ");
            string number = Console.ReadLine();

            string hex = Convert.ToString(int.Parse(number), 16).ToUpper();

            StringBuilder stringOutput = new StringBuilder();
            stringOutput.AppendLine($"Integer: {number}".PadLeft(15));
            stringOutput.AppendLine($"Hex: {hex}".PadLeft(15));
            stringOutput.AppendLine($"%: {number}%".PadLeft(15));
            stringOutput.AppendLine($"USD: {number}$".PadLeft(15));          

            Console.WriteLine(stringOutput.ToString());
        }
    }
}
