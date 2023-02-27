using SoftUni.Data;
using SoftUni.Models;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext dbContext = new SoftUniContext();
            string result = GetAddressesByTown(dbContext);

            Console.WriteLine(result);
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addressesByTown = context.Addresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town.Name)
                .ThenBy(a => a.AddressText)
                .Select(a => new
                {
                    a.AddressText,
                    TownName = a.Town!.Name,
                    EmployeesCount = a.Employees.Count
                })
                .Take(10)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var a in addressesByTown)
            {
                sb.AppendLine($"{a.AddressText}, {a.TownName} - {a.EmployeesCount} employees");
            }

            return sb.ToString().TrimEnd();
        }
    }
}