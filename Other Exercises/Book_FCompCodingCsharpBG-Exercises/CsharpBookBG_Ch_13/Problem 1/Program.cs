using System; //reverse a string
using System.Text;

namespace Problem_1 //task 2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter any text: ");
            string input = Console.ReadLine();

            StringBuilder reversedText = new StringBuilder(input.Length);

            for (int i = input.Length - 1; i >= 0; i--)
            {
                reversedText.Append(input[i]);
            }
           
            Console.WriteLine($"Reversed text: {reversedText}");

        }
    }
}
