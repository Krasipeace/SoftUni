using System; //DEC to HEX

namespace Problem_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            string number = Console.ReadLine();

            if (number == "0")
            {
                Console.WriteLine("Hexadecimal number: 0x0");

                return;
            }
            string hex = Convert.ToString(int.Parse(number), 16).ToUpper();

            Console.WriteLine($"Hexadecimal number: {hex}");
        }
    }
}
