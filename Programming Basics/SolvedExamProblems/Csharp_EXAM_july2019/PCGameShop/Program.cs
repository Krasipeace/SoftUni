using System;

namespace PCGameShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int games = int.Parse(Console.ReadLine());
            double counterHstone = 0;
            double counterFort = 0;
            double counterOwatch = 0;
            double counterOthers = 0;

            for (int i = 1; i <= games; i++)
            {
                string title = Console.ReadLine();
                if (title == "Hearthstone")
                {
                    counterHstone++;
                }
                else if (title == "Fornite")
                {
                    counterFort++;
                }
                else if (title == "Overwatch")
                {
                    counterOwatch++;
                }
                else
                {
                    counterOthers++;
                }
            }
            double pHearthstone = counterHstone / games * 100.0;
            double pFornite = counterFort / games * 100.0;
            double pOverwatch = counterOwatch / games * 100.0;
            double pOthers = counterOthers / games * 100.0;

            Console.WriteLine($"Hearthstone - {pHearthstone:f2}%");
            Console.WriteLine($"Fornite - {pFornite:f2}%");
            Console.WriteLine($"Overwatch - {pOverwatch:f2}%");
            Console.WriteLine($"Others - {pOthers:f2}%");
        }
    }
}
