using System;

namespace DecryptingMessages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte key = byte.Parse(Console.ReadLine());
            byte inputLines = byte.Parse(Console.ReadLine());            
            string word = string.Empty;
            string decryptedWord = string.Empty;

            for (int i = 1; i <= inputLines; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                for (int j = 1; j <= inputLines; j++)
                {

                }
                word += letter;
            }
            //Console.Write(word);

            //unfinished
        }
    }
}
