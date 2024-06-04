using System;

namespace _06_TheMostPowerfulWord
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string end = "End of words";
            decimal result = 0;
            decimal maxResult = decimal.MinValue;
            decimal charletter = 0;
            string mostPowerfulWord = "";

            while (word != end)
            {
                decimal charSum = 0;

                for (int i = 1; i <= word.Length; i++)
                {
                    charletter = word[0]; // тук взимаме само първата буква, която ще използваме в иф проверката после
                    charSum = charSum + word[i - 1]; // i-1 за да хванем всички букви на стринга, да стартираме от нулев индекс
                }

                if (charletter == 'a' || charletter == 'A' || charletter == 'e' || charletter == 'E' || charletter == 'i' || charletter == 'I' || charletter == 'o' || charletter == 'O' || charletter == 'u' || charletter == 'U' || charletter == 'y' || charletter == 'Y')
                {
                    result = charSum * word.Length;
                }
                else
                {
                    result = Math.Floor(charSum / word.Length);
                }


                if (result > maxResult)
                {
                    maxResult = result;
                    mostPowerfulWord = word;
                }

                result = 0;
                word = Console.ReadLine();
            }

            if (word == "End of words")
            {
                Console.WriteLine($"The most powerful word is {mostPowerfulWord}-{maxResult}");
            }
        }
    }
}
