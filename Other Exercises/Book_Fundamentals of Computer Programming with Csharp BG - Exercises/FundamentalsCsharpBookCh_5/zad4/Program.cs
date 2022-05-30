using System;

namespace zad4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //4.Сортирайте 3 реални числа в намаляващ ред. Използвайте вложени if оператори.
            Console.WriteLine("Sort 3 real numbers from the smaller one to bigger one.");
            Console.Write("Enter number one: ");
            double numberOne = double.Parse(Console.ReadLine());
            Console.Write("Enter number two: ");
            double numberTwo = double.Parse(Console.ReadLine());
            Console.Write("Enter number three: ");
            double numberThree = double.Parse(Console.ReadLine());

            double numberBig = 0.0;
            double numberMid = 0.0;
            double numberEnd = 0.0;

            if (numberOne > numberTwo)                
            {
                if (numberTwo < numberThree)          //132         
                {
                    numberBig = numberOne;
                    numberMid = numberThree;
                    numberEnd = numberTwo;
                }
                else if (numberTwo > numberThree)     //123
                {
                    numberBig = numberOne;
                    numberMid = numberTwo;
                    numberEnd = numberThree;
                }
            }
            else if (numberTwo > numberOne)
            {
                if (numberOne < numberThree)          //231
                {
                    numberBig = numberTwo;
                    numberMid = numberThree;
                    numberEnd = numberOne;
                }
                else if (numberOne > numberThree)     //213
                {
                    numberMid = numberOne;
                    numberEnd = numberThree;
                    numberBig = numberTwo;
                }
            }
            else if (numberThree > numberTwo)         
            {
                if (numberTwo < numberOne)           //312
                {
                    numberBig = numberThree;
                    numberMid = numberOne;
                    numberEnd = numberTwo;
                }    
                else if (numberTwo > numberOne)      //321
                {
                    numberBig = numberThree;
                    numberMid = numberTwo;
                    numberEnd = numberOne;
                }
            }
            Console.WriteLine(numberBig);
            Console.WriteLine(numberMid);
            Console.WriteLine(numberEnd);
           
        }
    }
}
