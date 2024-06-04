using System;

namespace LowerorUpper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char input = char.Parse(Console.ReadLine());
            
            if (input >= 65 && input <= 90)
            {
                Console.WriteLine($"upper-case");
            }
            else if (input >= 97 && input <= 122)
            {
                Console.WriteLine($"lower-case");
            }
        }
    }
}
