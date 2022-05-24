using System;

namespace WeatherForecast
{
    class Program
    {
        static void Main(string[] args)
        {
            //подсказка за избор
            //Console.Write("What is the weather outside? (sunny/cloudy/snowy): ");
            string forecast = Console.ReadLine();
            //условие 
            if (forecast == "sunny")
            {
                Console.WriteLine("It's warm outside!");
            }
            //else if ((forecast == "cloudy") || (forecast == "snowy"))
            //{
            //    Console.WriteLine("It's cold outside!");
            //}
            else
            {
                Console.WriteLine("It's cold outside!");
            }
        }
    }
}
