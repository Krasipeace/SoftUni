using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_8_19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Phone> phones = new List<Phone>();

            //Console.WriteLine("Enter Phones Information: ");
            //int numberOfInputLines = int.Parse(Console.ReadLine());
            //for (int i = 0; i < numberOfInputLines; i++)
            //{
            //    Console.Write($"Enter Phone Info #{i + 1}");
            //    Console.Write("Enter Manufacturer: ");
            //    string manufacturer = Console.ReadLine();
            //    Console.Write("Enter Model: ");
            //    string model = Console.ReadLine();
            //    Console.Write("Enter Price: ");
            //    decimal price = decimal.Parse(Console.ReadLine());
            //    Console.Write("Enter Owner: ");
            //    string owner = Console.ReadLine();
            //    Console.Write("Enter Battery Type (LiIon,LiPo,NiMh,NiCd): ");
            //    string batteryType = Console.ReadLine();
            //    Console.Write("Enter Battery Idle Time(hours): ");
            //    double batteryIdleTime = double.Parse(Console.ReadLine());
            //    Console.Write("Enter Battery Hours of Talk(hours): ");
            //    double batteryHoursTalk = double.Parse(Console.ReadLine());
            //    Console.Write("Enter Screen Size(inch): ");
            //    double screenSize = double.Parse(Console.ReadLine());
            //    Console.Write("Enter Screen Color: ");
            //    string screenColor = Console.ReadLine();
            //}
        }
    }

    class Phone
    {
        public Phone(string manufacturer, string model, decimal price, string owner, Battery phoneBattery, Screen phoneScreen)
        {
            Manufacturer = manufacturer;
            Model = model;
            Price = price;
            Owner = owner;
            PhoneBattery = phoneBattery;
            PhoneScreen = phoneScreen;
        }

        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public string Owner { get; set; }
        public Battery PhoneBattery { get; set; }
        public Screen PhoneScreen { get; set; }

        public void PhoneInfo()
        {
            List<Phone> phones = new List<Phone>();

            phones.Add(new Phone(Manufacturer, Model, Price, Owner, PhoneBattery, PhoneScreen));
        }

        public string PrintPhone(string manufacturer, string model, decimal price, string owner, Battery phoneBattery, Screen phoneScreen)
        {
            return $"\nPhone: {manufacturer}\nModel: {model}\nPrice: {price.ToString()}\nOwner: {owner}" +
                   $"\nBattery Type: {phoneBattery.Model}\nBattery Idle Time: {phoneBattery.IdleTime.ToString()}\nBattery Hours Talk: {phoneBattery.HoursTalk.ToString()}" +
                   $"\nScreen Size: {phoneScreen.Size.ToString()}\nScreen Color {phoneScreen.Color}";
        }

    }

    class Battery
    {
        public Battery(BatteryType model, double idleTime, double hoursTalk)
        {
            Model = model;
            IdleTime = idleTime;
            HoursTalk = hoursTalk;
        }

        public BatteryType Model { get; set; }
        public double IdleTime { get; set; }
        public double HoursTalk { get; set; }
    }
    enum BatteryType
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