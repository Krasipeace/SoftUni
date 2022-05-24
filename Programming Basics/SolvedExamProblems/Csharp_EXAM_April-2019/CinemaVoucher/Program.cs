using System;

namespace CinemaVoucher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int voucher = int.Parse(Console.ReadLine());
            int tickets = 0;
            int products = 0;
            int price = 0;
            string input = Console.ReadLine();

            while (input != "End")
            {
                if (input.Length > 8)
                {
                    price = input[0] + input[1];

                    if (voucher >= price)
                    {
                        voucher -= price;
                    }
                    else
                    {
                        break;
                    }
                    tickets++;
                }
                else
                {
                    price = input[0];

                    if (voucher >= price)
                    {
                        voucher -= price;
                    }
                    else
                    {
                        break;
                    }
                    products++;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(tickets);
            Console.WriteLine(products);
        }
    }
}
