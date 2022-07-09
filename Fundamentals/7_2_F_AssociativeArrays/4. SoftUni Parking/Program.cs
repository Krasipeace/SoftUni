using System;
using System.Collections.Generic;

namespace _4._SoftUni_Parking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> users = new Dictionary<string, string>();
            int commands = int.Parse(Console.ReadLine());

            for (int i = 0; i < commands; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string action = tokens[0];
                string userName = tokens[1];                

                switch (action)
                {
                    case "register":
                        string userPlate = tokens[2];
                        Register(userName, userPlate, users);
                        break;
                    case "unregister":
                        Unregister(userName, users);
                        break;
                }
            }

            PrintResult(users);
        }

        private static void Register(string userName, string userPlate, Dictionary<string, string> users)
        {
            if (!users.ContainsKey(userName))
            {
                users.Add(userName, userPlate);
                Console.WriteLine($"{userName} registered {userPlate} successfully");
            }
            else if (users.ContainsKey(userName))
            {
                Console.WriteLine($"ERROR: already registered with plate number {userPlate}");
            }
        }

        private static void Unregister(string userName, Dictionary<string, string> users)
        {
            if (users.ContainsKey(userName))
            {
                Console.WriteLine($"{userName} unregistered successfully");
                users.Remove(userName);
            }
            else if (!users.ContainsKey(userName))
            {
                Console.WriteLine($"ERROR: user {userName} not found");
            }
        }
        private static void PrintResult(Dictionary<string, string> users)
        {
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }
        }
    }
}
