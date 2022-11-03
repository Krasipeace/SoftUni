using System;
using System.Linq;

namespace Telephony
{
    public class Smartphone : ICalling, IBrowsing
    {
        public void Calling(string number)
        {
            if (!number.Any(l => char.IsLetter(l)))
            {
                Console.WriteLine($"Calling... {number}");
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.INVALID_NUMBER);
            }
        }

        public void Browsing(string website)
        {
            if (!website.Any(l => char.IsNumber(l)))
            {
                Console.WriteLine($"Browsing: {website}!");
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.INVALID_URL);
            }
        }
    }
}
