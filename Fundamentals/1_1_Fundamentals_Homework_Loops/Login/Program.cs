using System;
using System.Linq;

namespace Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            var password = username.ToCharArray().Reverse();
            //Console.WriteLine(new string(password.ToArray()));
            for (int i = 1; i <= 4; i++)
            {
                string input = Console.ReadLine();
                if (input == (new string(password.ToArray())))
                {
                    Console.WriteLine($"User {username} logged in.");
                    break;
                }
                else
                {
                    if (i == 4)
                    {
                        Console.WriteLine($"User {username} blocked!");
                        break;
                    }
                    Console.WriteLine("Incorrect password. Try again.");
                }
            }

        }
    }
}
