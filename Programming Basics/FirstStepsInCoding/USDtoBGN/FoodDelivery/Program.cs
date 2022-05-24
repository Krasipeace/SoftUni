using System;

namespace FoodDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            //Пилешко меню – 10.35 лв. --- Меню с риба – 12.40 лв. --- Вегетарианско меню – 8.15 лв. Доставка - 2.50 лв. 
            //Брой пилешки менюта – цяло число в интервала[0 … 99]
            //Брой менюта с риба – цяло число в интервала[0 … 99]
            //Брой вегетариански менюта – цяло число в интервала[0 … 99]
            int menuChicken = int.Parse(Console.ReadLine());
            int menuFish = int.Parse(Console.ReadLine());
            int menuVegetarian = int.Parse(Console.ReadLine());
            //изчисление на цените на менютата
            double priceChicken = menuChicken * 10.35;
            double priceFish = menuFish * 12.40;
            double priceVegetarian = menuVegetarian * 8.15;
            double menuPrice = priceChicken + priceFish + priceVegetarian;
            //изчисление цена на десерт 
            double dessert = menuPrice * 0.20;
            //изчисление и отпечатване - Общата цена на поръчката
            double orderPrice = menuPrice + dessert + 2.50;
            Console.WriteLine(orderPrice);
        }
    }
}