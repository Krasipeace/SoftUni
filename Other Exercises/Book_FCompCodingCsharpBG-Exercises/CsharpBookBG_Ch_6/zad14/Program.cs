using System;

namespace zad14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //14.Програма, която преобразува дадено число от десетична в шестнайсетична бройна система.
            
            int decimalNumber, quotient;
            int i = 1;
            int j = 0;
            int temp = 0;
            char[] hexadecimalNumber = new char[100];
            char temp1;

            Console.Write("Enter number :");
            decimalNumber = int.Parse(Console.ReadLine());

            quotient = decimalNumber;
            while (quotient != 0)
            {
                temp = quotient % 16;
                
                if (temp < 10)                             //numbers 0 to 9
                    {
                    temp = temp + 48;
                }
                else
                {
                    temp = temp + 55;
                }

                temp1 = Convert.ToChar(temp);
                hexadecimalNumber[i++] = temp1;
                quotient = quotient / 16;
            }

            Console.Write("Hex: ");
            for (j = i - 1; j > 0; j--)
            {
                Console.Write(hexadecimalNumber[j]);
            }
            
        }
    }
}
