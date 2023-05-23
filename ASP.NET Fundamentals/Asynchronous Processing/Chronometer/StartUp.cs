namespace Chronometer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var chronometer = new Chronometer();

            string line;

            while ((line = Console.ReadLine()) != "exit")
            {
                switch (line)
                {
                    case "start":
                        Task.Run(() => chronometer.Start());
                        break;
                    case "stop":
                        chronometer.Stop();
                        break;
                    case "lap":
                        Console.WriteLine(chronometer.Lap());
                        break;
                    case "laps":
                        {
                            Console.WriteLine("Laps:");
                            if (chronometer.Laps.Count == 0)
                            {
                                Console.WriteLine("No laps.");
                            }
                            else
                            {
                                for (int i = 0; i < chronometer.Laps.Count; i++)
                                {
                                    Console.WriteLine($"{i}. {chronometer.Laps[i]}");
                                }
                            }
                            break;
                        }
                    case "time":
                        Console.WriteLine(chronometer.GetTime);
                        break;
                    case "reset":
                        chronometer.Reset();
                        break;
                    case "exit":
                        return;
                    default:
                        Console.WriteLine("Invalid command!");
                        break;
                }

                chronometer.Stop();
            }
        }
    }
}