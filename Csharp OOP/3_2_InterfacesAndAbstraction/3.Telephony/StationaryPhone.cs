using System;
using System.Linq;

namespace Telephony
{
    public class StationaryPhone : ICalling
    {
        public void Calling(string number)
        {
            if (number.Any(ch => char.IsLetter(ch)))
            {
                throw new ArgumentException(ExceptionMessages.INVALID_NUMBER);
            }

            Console.WriteLine($"Dialing... {number}");
        }
    }
}
