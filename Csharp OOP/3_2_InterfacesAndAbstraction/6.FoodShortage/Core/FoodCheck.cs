namespace BorderControl.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BorderControl.Models.Interfaces;
    using BorderControl.Core.Interfaces;
    using BorderControl.Models;

    public class FoodCheck : IEngine
    {
        public List<IBuyer> buyers;

        public void RunEngine()
        {
            buyers = new List<IBuyer>();

            int inputs = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputs; i++)
            {
                string[] dataInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = dataInfo[0];
                int age = int.Parse(dataInfo[1]);

                if (dataInfo.Length > 3)
                {
                    buyers.Add(new Citizen(name, age, dataInfo[2], dataInfo[3]));
                }
                else
                {
                    buyers.Add(new Rebel(name, age, dataInfo[2]));
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string buyerName = input;

                IBuyer buyer = buyers.FirstOrDefault(b => b.Name == buyerName);

                if (buyer == null)
                {
                    continue;
                }

                buyer.BuyFood();
            }

            Console.WriteLine(buyers.Sum(x => x.Food));
        }
    }
}
