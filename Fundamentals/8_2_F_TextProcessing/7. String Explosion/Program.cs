using System;
using System.Text;

namespace _7._String_Explosion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            StringBuilder output = new StringBuilder();
            int strengthExplosion = 0;

            for (int i = 0; i < input.Length; i++)
            {
                char current = input[i];

                if (current == '>')
                {
                    strengthExplosion += int.Parse(input[i + 1].ToString());
                    output.Append(current);
                }
                else if (strengthExplosion == 0)
                {
                    output.Append(current);
                }
                else
                {
                    strengthExplosion--;
                }
            }

            Console.WriteLine(output);
        }
    }
}
