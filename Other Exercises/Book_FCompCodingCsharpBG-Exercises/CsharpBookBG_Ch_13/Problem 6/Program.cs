using System;

namespace Problem_6 //task 8 example: Test >>>> "\u0054\u0065\u0073\u0074"
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter text: ");
            string text = Console.ReadLine();

            char[] chars = text.ToCharArray();
            string unicode = String.Empty;

            for (int i = 0; i < chars.Length; i++)
            {
                unicode += string.Format("\\u{0:x4}", (int)chars[i]);
            }

            Console.WriteLine($"Unicode output: {unicode}");
        }
    }
}
