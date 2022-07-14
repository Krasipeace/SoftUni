using System;
using System.Collections.Generic;

namespace _1._Valid_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            List<string> output = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                string currentName = input[i];
                bool isNameLengthValid = false;

                isNameLengthValid = CheckForLengthAndValidCharacters(output, currentName, isNameLengthValid);
            }

            PrintResult(output);
        }

        private static bool CheckForLengthAndValidCharacters(List<string> output, string currentName, bool isNameLengthValid)
        {
            if (currentName.Length >= 3 && currentName.Length <= 16)
            {
                isNameLengthValid = true;
                bool isNameCharactersValid = false;

                CheckValidationOfCurrentCharacter(currentName, ref isNameLengthValid, ref isNameCharactersValid);

                CheckValidationOfCurrentName(output, currentName, isNameLengthValid, isNameCharactersValid);
            }

            return isNameLengthValid;
        }

        private static void CheckValidationOfCurrentCharacter(string currentName, ref bool isNameLengthValid, ref bool isNameCharactersValid)
        {
            foreach (var character in currentName)
            {
                if (char.IsLetterOrDigit(character) || character == '_' || character == '-')
                {
                    isNameCharactersValid = true;
                }
                else
                {
                    isNameLengthValid = false;
                    break;
                }
            }
        }

        private static void CheckValidationOfCurrentName(List<string> output, string currentName, bool isNameLengthValid, bool isNameCharactersValid)
        {
            if (isNameCharactersValid && isNameLengthValid)
            {
                output.Add(currentName);
            }
        }

        private static void PrintResult(List<string> output)
        {
            foreach (var item in output)
            {
                Console.WriteLine($"{item}");
            }
        }
    }
}
