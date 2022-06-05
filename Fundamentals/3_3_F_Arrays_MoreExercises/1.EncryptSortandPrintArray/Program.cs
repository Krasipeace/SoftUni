using System;

namespace _1.EncryptSortandPrintArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lengthArray = int.Parse(Console.ReadLine());

            char[] vowel = new char[] {'A','E','I','O','U','a','e','i','o','u'};
            int[] result = new int[lengthArray];

            for (int i = 0; (i < lengthArray); i++)
            {
                int sum = 0;
                string input = Console.ReadLine();
                int inputLength = input.Length;

                for (int j = 0; j < inputLength; j++)
                {
                    bool isVowel = false;
                    for (int k = 0; k < 10; k++)
                    {
                        if (input[j] == vowel[k])
                        {
                            isVowel = true;
                        }
                    }

                    if (isVowel)
                    {
                        sum = sum + (int)input[j] * inputLength;
                    }
                    else
                    {
                        sum = sum + (int)input[j] / inputLength;
                    }
                }
                result[i] = sum;
            }
            Array.Sort(result);
            foreach (int name in result)
            {
                Console.WriteLine(name);
            }
        }
    }
}
