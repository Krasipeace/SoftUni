using System;

namespace zad7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //7.Силата на гравитационното поле на Луната е приблизително 17% от това на Земята.
            //Напишете програма, която да изчислява тежестта на човек на Луната, по дадената тежест на Земята.

            Console.WriteLine("Check your Weight on Moon, by writing your weight on Earth");
            Console.Write("Enter your weight: ");
            double weightEarth = double.Parse(Console.ReadLine());

            double weightMoon = weightEarth * 0.17;
            Console.WriteLine("Your Weight on Moon is: " + weightMoon);
        }
    }
}
