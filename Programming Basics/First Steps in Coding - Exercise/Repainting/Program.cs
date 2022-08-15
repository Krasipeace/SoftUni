using System;

namespace Repainting
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.Необходимо количество найлон(в кв.м.) -цяло число в интервала[1... 100] ---  1.50 лв.за кв. метър
            //2.Необходимо количество боя(в литри) -цяло число в интервала[1…100]       ---  14.50 лв.за литър
            //3.Количество разредител(в литри) - цяло число в интервала[1…30]           ---  5.00 лв.за литър
            //4.Часовете, за които майсторите ще свършат работата -цяло число в интервала[1…9]
            //5.Торбички = 0.40
            int nylon = int.Parse(Console.ReadLine());
            int paint = int.Parse(Console.ReadLine());
            int thinner = int.Parse(Console.ReadLine());
            int painterHours = int.Parse(Console.ReadLine());            
            //изчисление на разходи за материали
            double sumNylon = (nylon + 2) * 1.50;
            double addPaint = paint / 10.0;                                  
            double sumPaint = (paint + addPaint) * 14.50;
            double sumThinner = thinner * 5.00;          
            double bags = 0.40;
            //изчисление на обща сума за материали
            double materials = sumNylon + sumPaint + sumThinner + bags;
            //изчисление на заплащане на майсторите
            double painterPayment = painterHours * (materials * 30 / 100);
            //изчисление на всички разходи
            double costs = materials + painterPayment;
            //отпечатване на всички разходи
            Console.WriteLine(costs);
        }
    }
}