using System;

namespace Salary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int tabs = int.Parse(Console.ReadLine());
            int wage = int.Parse(Console.ReadLine());

            for (int i = 1; i <= tabs; i++)
            {
                string tabValue = Console.ReadLine();
                if (tabValue == "Facebook")
                {
                    wage -= 150;
                }
                else if (tabValue == "Instagram")
                {
                    wage -= 100;
                }
                else if (tabValue == "Reddit")
                {
                    wage -= 50;
                }
                if (wage <= 0)
                {
                    Console.WriteLine("You have lost your salary.");
                    break;
                }
            }
            if (wage > 0)
            {
                Console.WriteLine(wage);
            }           
        }
    }
}
