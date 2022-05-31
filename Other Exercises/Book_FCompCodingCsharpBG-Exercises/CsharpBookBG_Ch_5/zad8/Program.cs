using System;

namespace zad8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //8.Напишете програма, която по избор на потребителя прочита от конзолата променлива от тип int, double или string.
            //Ако променливата е int или double, трябва да се увеличи с 1.
            //Ако променливата е string, трябва да се прибави накрая символа "*". Отпечатайте получения резултат на конзолата. Използвайте switch конструкция.
            Console.WriteLine("Menu - Choose variable type");
            Console.WriteLine("string - 0");
            Console.WriteLine("int - 1");
            Console.WriteLine("double - 2");
            int varX = int.Parse(Console.ReadLine());
            switch (varX)
            {
                case 0:
                    {
                        Console.Write("Enter any string you want: ");
                        string varString = Console.ReadLine();
                        Console.WriteLine("You have chosen string and your new variable looks like this: " + varString + "*");
                    }
                    break;
                case 1:
                    {
                        Console.Write("Enter any integer number: ");
                        int varInteger = int.Parse(Console.ReadLine());
                        varInteger += 1;
                        Console.WriteLine("Your variable is integer and its value is increased by 1: " + varInteger);
                    }
                    break;
                case 2:
                    {
                        Console.Write("Enter any real number: ");
                        double varDouble = double.Parse(Console.ReadLine());
                        varDouble += 1.0;
                        Console.WriteLine("Your variable is double and its value is increased by 1: " + varDouble);
                    }
                    break;
            }
        }
    }
}
