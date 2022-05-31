using System;

namespace zad5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Напишете програма, която за дадена цифра (0-9), зададена като вход, извежда името на цифрата на български език.

            Console.WriteLine("Enter number 0 to 9, and find out the name in bulgarian.");
            Console.Write("Enter number 0 - 9: ");
            int numberX = int.Parse(Console.ReadLine());

            switch (numberX)
            {                
                case 0: Console.WriteLine("Нула");
                    break;
                case 1: Console.WriteLine("Едно");
                    break;
                case 2: Console.WriteLine("Две");
                    break;
                case 3: Console.WriteLine("Три");
                    break;
                case 4: Console.WriteLine("Четири");
                    break;
                case 5: Console.WriteLine("Пет");
                    break;
                case 6: Console.WriteLine("Шест");
                    break;
                case 7: Console.WriteLine("Седем");
                    break;
                case 8: Console.WriteLine("Осем");
                    break;
                case 9: Console.WriteLine("Девет");
                    break;
                default: Console.WriteLine("Error! The number is not in range [0-9].");
                    break;
            }        
        }
    }
}
