using System;

namespace VacationBooksList
{
    class Program
    {
        static void Main(string[] args)
        {
            //брой страници - цяло число
            //прочетени страници за 1 час - цяло число
            //броят дни за книга
            int pages = int.Parse(Console.ReadLine());
            int readpages = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            //изчисление общо време за четене на книга
            int hoursPerBook = pages / readpages;
            //изчисление на необходими часове на ден
            int hoursPerDay = hoursPerBook / days;
            //отпечатване на НЧнД
            Console.WriteLine(hoursPerDay);
        }
    }
}