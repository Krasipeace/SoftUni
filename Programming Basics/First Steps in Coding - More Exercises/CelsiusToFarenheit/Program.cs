using System;

namespace CelsiusToFarenheit
{
    class Program
    {
        static void Main(string[] args)
        {
            //въвеждане на градуси в Целзий
            double celsius = double.Parse(Console.ReadLine());
            //конвертиране във фаренхайт
            double farenheit = (celsius * 1.8) + 32;
            Console.WriteLine("{0:f2}", farenheit);
        }
    }
}