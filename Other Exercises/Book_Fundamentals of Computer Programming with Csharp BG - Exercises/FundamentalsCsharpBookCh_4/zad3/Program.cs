using System;

namespace zad3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name and Company data.");
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Surname: ");
            string surname = Console.ReadLine();

            Console.Write("Phone: ");
            string phone = Console.ReadLine();

            Console.Write("Company name: ");
            string company = Console.ReadLine();

            Console.Write("Company Address: ");
            string companyAddress = Console.ReadLine();

            Console.Write("Company Phone: ");
            string companyPhone = Console.ReadLine();
                
            Console.Write("Company Fax: ");
            string companyFax = Console.ReadLine();

            Console.Write("Company Web-site: ");
            string companyWeb = Console.ReadLine();

            Console.WriteLine("***** _________ _-_ _________ *****");
            Console.WriteLine("Manager name: " + name);
            Console.WriteLine("Manager surname: " + surname);
            Console.WriteLine("Manager phone: " + phone);
            Console.WriteLine("Company: " + company);
            Console.WriteLine("Company Address: " + companyAddress);
            Console.WriteLine("Company Phone: " + companyPhone);
            Console.WriteLine("Company Fax: " + companyFax);
            Console.WriteLine("Company Web-site: " + companyWeb);
        }
    }
}
