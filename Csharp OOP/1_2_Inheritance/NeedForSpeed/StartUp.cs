namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Car car = new Car (70, 50);
            car.Drive(10);

            RaceMotorcycle raceMotorcycle = new RaceMotorcycle(500, 60);
            raceMotorcycle.Drive(10);

            SportCar sportCar = new SportCar(300, 70);
            sportCar.Drive(10);
           
        }
    }
}
