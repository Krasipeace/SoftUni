using System; // area of a triangle by 3 options

namespace Problem_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string action = Menu();

            switch (action)
            {
                case "1":
                    ThreeSides();
                    break;
                case "2":
                    OneSideAndHeight();
                    break;
                case "3":
                    TwoSidesAndAngle();
                    break;
                case "4":
                    return;
                default:
                    Menu();
                    break;
            }

        }

        private static string Menu()
        {
            Console.WriteLine("Find area of triangle by chosen option:");
            Console.WriteLine("1) By the lengths of its three sides ---------------------------------- Enter: 1");
            Console.WriteLine("2) By the length of one side and the height to it --------------------- Enter: 2");
            Console.WriteLine("3) By the lengths of two sides and the angle between them in degrees. - Enter: 3");
            Console.WriteLine();
            Console.WriteLine("Exit the program: ----------------------------------------------------- Enter: 4");
            Console.WriteLine();

            Console.Write("Find area of triangle (choose path): ");
            string action = Console.ReadLine();
            return action;
        }
        private static void ThreeSides()
        {
            Console.Write("Enter side A: ");
            double sideA = double.Parse(Console.ReadLine());
            Console.Write("Enter side B: ");
            double sideB = double.Parse(Console.ReadLine());
            Console.Write("Enter side C: ");
            double sideC = double.Parse(Console.ReadLine());

            double triangleP = (sideA + sideB + sideC) / 2;
            double triangleArea = Math.Sqrt(triangleP * (triangleP - sideA) * (triangleP - sideB) * (triangleP - sideC));

            Console.WriteLine($"Result: {triangleArea:f2}");
        }

        private static void OneSideAndHeight()
        {
            Console.Write("Enter side: ");
            double sideH = double.Parse(Console.ReadLine());
            Console.Write("Enter side's Height: ");
            double height = double.Parse(Console.ReadLine());

            double triangleArea = (0.5 * sideH) * height;

            Console.WriteLine($"Result: {triangleArea:f2}");
        }

        private static void TwoSidesAndAngle()
        {
            Console.Write("Enter side A: ");
            double sideA = double.Parse(Console.ReadLine());
            Console.Write("Enter side B: ");
            double sideB = double.Parse(Console.ReadLine());
            Console.Write("Enter angle (degrees): ");
            double angle = double.Parse(Console.ReadLine());
            
            double radians = angle * Math.PI / 180;
            double triangleArea = (sideA * sideB * Math.Sin(radians)) / 2;

            Console.WriteLine($"Result: {triangleArea:f2}");
        }

    }
}
