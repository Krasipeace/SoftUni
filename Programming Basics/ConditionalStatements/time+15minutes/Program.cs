using System;

namespace time_15minutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int timeInMin = minutes + hours * 60;
            timeInMin = timeInMin + 15;
            hours = timeInMin / 60; //105/60 = 1 (45)
            minutes = timeInMin % 60; // 105%60 = 45
            if (hours == 24)
            {
                hours = 0;
            }
            //24:05 >> 0:05
            if (minutes < 10)
            {
                Console.WriteLine($"{hours}:0{minutes}");
            }
            else
            {
                Console.WriteLine($"{hours}:{minutes}");
            }
        }
    }
}
