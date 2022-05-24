using System;

namespace PasswordGuess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string definedPass = "s3cr3t!P@ssw0rd";
            string userPass = Console.ReadLine();
            if (definedPass == userPass)
            {
                Console.WriteLine("Welcome");
            }
            else
            {
                Console.WriteLine("Wrong password!");
            }
        }
    }
}
