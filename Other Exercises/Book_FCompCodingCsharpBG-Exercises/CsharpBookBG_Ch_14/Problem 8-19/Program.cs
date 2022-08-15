using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_8_19  //unfinished
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();

            int choice = int.Parse(Console.ReadLine());
            while (choice != 6)
            {
                if (choice == 6)
                {
                    break;
                }

                List<Phone> phones = new List<Phone>();
                List<Battery> batteries = new List<Battery>();
                List<Screen> screens = new List<Screen>();
                List<Call> calls = new List<Call>();
                Dictionary<Phone, Call> phoneDict = new Dictionary<Phone, Call>();

                switch (choice)
                {
                    case 1:
                        AddPhones(phones, batteries, screens);
                        break;
                    case 2:
                        PrintPhone(phones, batteries, screens);
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("Error... unknown command!");
                        break;
                }
                Menu();
                choice = int.Parse(Console.ReadLine());
            }
        }



        private static void Menu()
        {
            Console.WriteLine("--- Menu ---");
            Console.WriteLine("1 - Add Phones");
            Console.WriteLine("2 - Print Phones");
            Console.WriteLine("3 - Add Calls");
            Console.WriteLine("4 - Print Calls");
            Console.WriteLine("5 - Remove Calls");
            Console.WriteLine("6 - Exit");

            Console.Write("Enter the number of your choice: ");
            Console.WriteLine();
        }

        private static void AddPhones(List<Phone> phones, List<Battery> batteries, List<Screen> screens)
        {           
            Console.Write("How many Phones do you want to add?: ");
            int numberOfInputLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfInputLines; i++)
            {
                Console.WriteLine($"Enter Phone Info #{i + 1}");
                Console.Write("Enter Manufacturer: ");
                string manufacturer = Console.ReadLine();
                Console.Write("Enter Model: ");
                string model = Console.ReadLine();
                Console.Write("Enter Price: ");
                decimal price = decimal.Parse(Console.ReadLine());
                Console.Write("Enter Owner: ");
                string owner = Console.ReadLine();

                Phone phone = new Phone(manufacturer, model, price, owner)
                {
                    Manufacturer = manufacturer,
                    Model = model,
                    Price = price,
                    Owner = owner
                };
                phones.Add(phone);

                Console.Write("Enter Battery Type (LiIon,LiPo,NiMh,NiCd): ");
                string batteryType = Console.ReadLine();
                Console.Write("Enter Battery Idle Time(hours): ");
                double batteryIdleTime = double.Parse(Console.ReadLine());
                Console.Write("Enter Battery Hours of Talk(hours): ");
                double batteryHoursTalk = double.Parse(Console.ReadLine());

                switch (batteryType)
                {
                    case "LiIon":
                        {
                            Battery battery = new Battery(BatteryType.LiIon, batteryIdleTime, batteryHoursTalk)
                            {
                                bType = BatteryType.LiIon,
                                IdleTime = batteryIdleTime,
                                HoursTalk = batteryHoursTalk
                            };
                            batteries.Add(battery);
                        }
                        break;
                    case "LiPo":
                        {
                            Battery battery = new Battery(BatteryType.LiPo, batteryIdleTime, batteryHoursTalk)
                            {
                                bType = BatteryType.LiPo,
                                IdleTime = batteryIdleTime,
                                HoursTalk = batteryHoursTalk
                            };
                            batteries.Add(battery);
                        }
                        break;
                    case "NiMh":
                        {
                            Battery battery = new Battery(BatteryType.NiMh, batteryIdleTime, batteryHoursTalk)
                            {
                                bType = BatteryType.NiMh,
                                IdleTime = batteryIdleTime,
                                HoursTalk = batteryHoursTalk
                            };
                            batteries.Add(battery);
                        }
                        break;
                    case "NiCd":
                        {
                            Battery battery = new Battery(BatteryType.NiCd, batteryIdleTime, batteryHoursTalk)
                            {
                                bType = BatteryType.NiCd,
                                IdleTime = batteryIdleTime,
                                HoursTalk = batteryHoursTalk
                            };
                            batteries.Add(battery);
                        }
                        break;
                }

                Console.Write("Enter Screen Size(inch): ");
                double screenSize = double.Parse(Console.ReadLine());
                Console.Write("Enter Screen Color: ");
                string screenColor = Console.ReadLine();
                Console.WriteLine();
                Screen screen = new Screen(screenSize, screenColor)
                {
                    Size = screenSize,
                    Color = screenColor
                };
                screens.Add(screen);

            }
        }
        private static void PrintPhone(List<Phone> phones, List<Battery> batteries, List<Screen> screens)
        {
            foreach (var item in phones)
            {
                Console.WriteLine($"Owner: {item.Owner}");
                Console.WriteLine($"Manufacturer: {item.Manufacturer}");
                Console.WriteLine($"Model: {item.Model}");
                Console.WriteLine($"Owner: {item.Price}");               
            }
            foreach (var item in batteries)
            {
                Console.WriteLine($"Battery Type: {item.bType}");
                Console.WriteLine($"Battery Idle Time: {item.IdleTime}");
                Console.WriteLine($"Battery Hours Talk: {item.HoursTalk}");
            }
            foreach (var item in screens)
            {
                Console.WriteLine($"Screen Size(inch): {item.Size}");
                Console.WriteLine($"Screen Color: {item.Color}");
            }
            
        }

    }

    class Phone
    {
        public Phone(string manufacturer, string model, decimal price, string owner)
        {
            Manufacturer = manufacturer;
            Model = model;
            Price = price;
            Owner = owner;
            //  PhoneBattery = phoneBattery;
            //  PhoneScreen = phoneScreen;
        }

        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public string Owner { get; set; }
        //  public Battery PhoneBattery { get; set; }
        //  public Screen PhoneScreen { get; set; }

        public void PhoneInfo()
        {
            List<Phone> phones = new List<Phone>();

            phones.Add(new Phone(Manufacturer, Model, Price, Owner));
        }

    }

    class Battery
    {
        public Battery(BatteryType batteryType, double idleTime, double hoursTalk)
        {
            bType = batteryType;
            IdleTime = idleTime;
            HoursTalk = hoursTalk;
        }

        public BatteryType bType { get; set; }
        public double IdleTime { get; set; }
        public double HoursTalk { get; set; }
    }
    public enum BatteryType
    {
        LiIon,
        LiPo,
        NiMh,
        NiCd
    };

    class Screen
    {
        public Screen(double size, string color)
        {
            Size = size;
            Color = color;
        }

        public double Size { get; set; }
        public string Color { get; set; }
    }

    class Call
    {
        public Call(DateTime callInfo, int duration)
        {
            CallInfo = callInfo;
            Duration = duration;
        }

        public DateTime CallInfo { get; set; }
        public int Duration { get; set; }
        public void CallHistory(DateTime callInfo, int duration)
        {
            List<Call> calls = new List<Call>();

            calls.Add(new Call(CallInfo, duration));
        }
    }
}