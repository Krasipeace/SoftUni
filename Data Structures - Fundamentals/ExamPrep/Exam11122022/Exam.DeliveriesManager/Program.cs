using System;

namespace Exam.DeliveriesManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello Deliverers");
            var deliverer = new Deliverer("1", "deli");
            var package = new Package("1", "2", "address", "+3591000", 10);

            var deliveriesManager = new DeliveriesManager();
            deliveriesManager.AddDeliverer(deliverer);
            deliveriesManager.AddPackage(package);
            deliveriesManager.AssignPackage(deliverer, package);
        }
    }
}
