using System; //BIn to HEX

namespace Problem_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a Binary number: ");
            string binary = Console.ReadLine();

            int result = Convert.ToUInt16(binary, 2);

            Console.WriteLine($"Hexadecimal number: {result}");
        }
    }
}
