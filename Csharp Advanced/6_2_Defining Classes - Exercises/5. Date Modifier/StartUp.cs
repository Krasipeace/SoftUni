using System;
using System.Globalization;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            Console.WriteLine(DateModifier.GetDateDifference(firstDate, secondDate));
        }
    }
}
