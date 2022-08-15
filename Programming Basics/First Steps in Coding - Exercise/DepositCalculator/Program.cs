using System;

namespace DepositCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //четем от конзолата 3 променливи
            //1.Депозирана сума – реално число в интервала[100.00 … 10000.00]
            //2.Срок на депозита(в месеци) – цяло число в интервала[1…12]
            //3.Годишен лихвен процент (ГЛП) – реално число в интервала[0.00 …100.00]
            double deposit = double.Parse(Console.ReadLine());
            int monthDeposit = int.Parse(Console.ReadLine());
            double interest = double.Parse(Console.ReadLine());
            //изчисление натрупаната лихва - депозирана сума * ГЛП  
            double allInterest = deposit * interest;
            //изчисляваме лихвата за 1 месец - НЛ / 12
            double monthInterest = allInterest / 12 /100;
            // изчисление на общата сума
            double allSum = deposit + monthDeposit * monthInterest;
            //отпечатваме общата сума - ДС + СнД * (лихва_за_месец)
            Console.WriteLine(allSum);        
        }
    }
}