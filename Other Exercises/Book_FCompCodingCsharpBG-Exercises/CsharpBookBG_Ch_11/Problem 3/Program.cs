using System; //which day is today

namespace Problem_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Today is: ");

            DateTime dateTime = DateTime.Today;

            Console.Write(dateTime.DayOfWeek);
        }
    }
}
