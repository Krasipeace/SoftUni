using System;
using System.Collections.Generic;

namespace Telephony
{
    public class StartUp
    {
        public const int STATIONARY_PHONE_LENGTH = 7;
        public const int SMARTPHONE_LENGTH = 10;
        static void Main(string[] args)
        {
            List<string> numbers = new List<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));
            List<string> websites = new List<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));

            foreach (var number in numbers)
            {
                try
                {
                    switch (number.Length)
                    {
                        case STATIONARY_PHONE_LENGTH:
                            { 
                            ICalling calling = new StationaryPhone();
                            calling.Calling(number);
                            }
                            break;
                        case SMARTPHONE_LENGTH:
                            { 
                            ICalling calling = new Smartphone();
                            calling.Calling(number);
                            }
                            break;
                    }
                }
                catch (ArgumentException arg)
                {
                    Console.WriteLine(arg.Message);
                }
            }

            foreach (var website in websites)
            {
                try
                {
                    IBrowsing browsing = new Smartphone();
                    browsing.Browsing(website);
                }
                catch (ArgumentException arg)
                {
                    Console.WriteLine(arg.Message);
                }
            }
        }
    }
}
