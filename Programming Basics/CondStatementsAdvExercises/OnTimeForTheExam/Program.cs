using System;

namespace OnTimeForTheExam
{
    class Program
    {
        static void Main(string[] args)
        {
            //10:00
            int examHour = int.Parse(Console.ReadLine());
            int examMin = int.Parse(Console.ReadLine());


            int arrivalHour = int.Parse(Console.ReadLine());
            int arrivalMin = int.Parse(Console.ReadLine());

            //преобразуваме часовете в минути
            examMin = examMin + examHour * 60;
            arrivalMin = arrivalMin + arrivalHour * 60;

            //намираме разликата във времето на пристигане
            int difference = Math.Abs(arrivalMin - examMin);

            //преобразуваме разликата в мин и часове
            int diffHour = difference / 60;
            int diffMin = difference % 60;

            //Проверявааме дали студентът закъснява
            if (examMin < arrivalMin)
            {
                Console.WriteLine("Late");

                //проверяваме дали закъснява с повече от 1 час
                if (diffHour >= 1)
                {
                    //проверяваме дали минутите са по-малко от 10 => отпечатваме с водеща 0 
                    if (diffMin < 10)
                    {
                        Console.WriteLine($"{diffHour}:0{diffMin} hours after the start");
                    }
                    else
                    {
                        Console.WriteLine($"{diffHour}:{diffMin} hours after the start");
                    }
                }
                else
                {
                    Console.WriteLine($"{diffMin} minutes after the start");
                }
            }

            //Проверявааме дали студентът e на време за изпита 
            else if (examMin - arrivalMin <= 30)
            {
                Console.WriteLine("On time");

                if (examMin != arrivalMin)
                {

                    Console.WriteLine($"{difference} minutes before the start");
                }
            }

            //Проверявааме дали студентът e подранил за изпита 
            else
            {
                Console.WriteLine("Early");

                //проверяваме дали подранява с повече от 1 час
                if (diffHour >= 1)
                {
                    //проверяваме дали минутите са по-малко от 10 => отпечатваме с водеща 0 
                    if (diffMin < 10)
                    {
                        Console.WriteLine($"{diffHour}:0{diffMin} hours before the start");
                    }
                    else
                    {
                        Console.WriteLine($"{diffHour}:{diffMin} hours before the start");
                    }
                }
                else
                {
                    Console.WriteLine($"{diffMin} minutes before the start");
                }
            }
        }
    }
}
