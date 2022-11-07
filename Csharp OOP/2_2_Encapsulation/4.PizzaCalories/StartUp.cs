using System; //92/100

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaData = Console.ReadLine().Split(" ");

                string pizzaName = pizzaData[1];

                Pizza pizza = new Pizza(pizzaName);

                string[] doughData = Console.ReadLine().Split(" ");

                string doughFlour = doughData[1];
                string bakingTechnique = doughData[2];
                double weight = double.Parse(doughData[3]);

                pizza.Dough = new Dough(doughFlour, bakingTechnique, weight);

                string command = Console.ReadLine();

                while (command != "END")
                {
                    string[] toppingData = command.Split(" ");

                    string toppingName = toppingData[1];
                    double toppingWeight = double.Parse(toppingData[2]);

                    Topping newTopping = new Topping(toppingName, toppingWeight);

                    pizza.AddTopping(newTopping);

                    command = Console.ReadLine();
                }

                double pizzaCalories = pizza.GetCalories();
                
                Console.WriteLine($"{pizza.Name} - {pizzaCalories:f2} Calories.");
            }
            catch (ArgumentException ex)
            {              
                Console.WriteLine(ex.Message);
            }
        }
    }
}
