using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> guests = new HashSet<string>();

            string input = Console.ReadLine();
            bool isPartyOn = false;

            while (input != "END")
            {
                if (input.Length >= 8 && isPartyOn == false)
                {
                    guests.Add(input);
                }

                if (input == "PARTY")
                {
                    isPartyOn = true;
                }

                if (isPartyOn)
                {
                    guests.Remove(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(guests.Count);

            foreach (var item in guests)
            {
                char[] symbol = item.ToCharArray();

                if (char.IsDigit(symbol[0]))
                {
                    Console.WriteLine(item);
                }
            }
            foreach (var item in guests)
            {
                char[] symbol = item.ToCharArray();

                if (char.IsLetter(symbol[0]))
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}