using System;

namespace DecryptingMessages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // key = +[x] ascii symbols; example if key = 4 and letter = A > decrypt letter = F

            int key = int.Parse(Console.ReadLine());
            byte inputLetters = byte.Parse(Console.ReadLine());            
            char decryptedLetter = '0';
            string decryptedWord = string.Empty;

            for (int i = 1; i <= inputLetters; i++)
            {
                char letter = char.Parse(Console.ReadLine());

                if (letter >= 65 && letter <= 90)
                {
                    decryptedLetter = (char)(letter + key);
                }
                else if (letter >= 97 && letter <= 122)
                {
                    decryptedLetter = (char)(letter + key);
                }
                decryptedWord += decryptedLetter.ToString();
            }

            Console.Write(decryptedWord);

        }
    }
}
