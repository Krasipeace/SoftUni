using System;

namespace StreamofLetters_CharSolution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = "";
            string word = "";
            string sumSicretCommand = "";
            char currentLetter = '+';
            string newWord = "";


            while (command != "End")
            {
                command = Console.ReadLine();
                if (command != "End")
                {
                    currentLetter = char.Parse(command);
                    if ((currentLetter >= 65 && currentLetter <= 90) || (currentLetter >= 97 && currentLetter <= 122))
                    {
                        if (currentLetter == 'c' && !(sumSicretCommand.Contains("c")))
                        {
                            sumSicretCommand += char.ToString(currentLetter);
                        }
                        else if (currentLetter == 'o' && !(sumSicretCommand.Contains("o")))
                        {
                            sumSicretCommand += char.ToString(currentLetter);
                        }
                        else if (currentLetter == 'n' && !(sumSicretCommand.Contains("n")))
                        {
                            sumSicretCommand += char.ToString(currentLetter);
                        }
                        else
                        {
                            word += char.ToString(currentLetter);
                        }
                        if (sumSicretCommand.Contains("c") && sumSicretCommand.Contains("o") && sumSicretCommand.Contains("n"))
                        {
                            word += " ";
                            newWord = word;
                            sumSicretCommand = "";
                        }
                    }
                }
                else
                {
                    break;
                }
            }
            if (command == "End")
            {
                Console.WriteLine(newWord);
            }
        }
    }
}
