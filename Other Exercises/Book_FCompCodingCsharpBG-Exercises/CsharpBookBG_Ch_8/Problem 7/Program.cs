using System; //BIN to DEC using Horner

namespace Problem_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a binary number: ");
            string binary = Console.ReadLine();

            int horner = binary.Length - 1;
            int result = 0;

            for (int i = 0; i < binary.Length; i++)
            {
                result += (int)(int.Parse(binary[i].ToString()) * Math.Pow(2, horner));
                horner--;
            }

            Console.WriteLine($"Decimal number: {result}");

        }
    }
}
