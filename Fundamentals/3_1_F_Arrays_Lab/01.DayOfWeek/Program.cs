﻿using System;

namespace _01.DayOfWeek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] dayOfWeek = {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"};
            int day = int.Parse(Console.ReadLine());

            switch (day)
            {
                case 1: Console.WriteLine(dayOfWeek[0]); break;
                case 2: Console.WriteLine(dayOfWeek[1]); break;
                case 3: Console.WriteLine(dayOfWeek[2]); break;
                case 4: Console.WriteLine(dayOfWeek[3]); break;
                case 5: Console.WriteLine(dayOfWeek[4]); break;
                case 6: Console.WriteLine(dayOfWeek[5]); break;
                case 7: Console.WriteLine(dayOfWeek[6]); break;
                default: Console.WriteLine("Invalid day!"); break;
            } 
            
        }
    }
}
