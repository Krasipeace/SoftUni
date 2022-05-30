using System;

namespace zad6
{
    class Program
    {
        static void Main(string[] args)
        {
            //6.Декларирайте променлива isMale от тип bool и присвоете стойност на последната в зависимост от вашия пол.

            Console.Write("Gender (M/F): ");
            char gender = char.Parse(Console.ReadLine());
            bool isMale = false;
            if (gender == 'M')
            {
                isMale = true;
            }
            else
            {
                isMale = false;
            }
            if (isMale)
            {
                Console.WriteLine("You are male!");
            }    
            else
            {
                Console.WriteLine("You are not male");
            }

        }
    }
}