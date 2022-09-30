using System;

namespace _5._Date_Modifier
{
    public class Program
    {
        static void Main(string[] args)
        {
            string firstDateAsString = Console.ReadLine();
            string secondDateAsString = Console.ReadLine();

            Console.WriteLine(DateModifier.GetDaysBetweenTwoDates(firstDateAsString, secondDateAsString));
        }
    }
}
