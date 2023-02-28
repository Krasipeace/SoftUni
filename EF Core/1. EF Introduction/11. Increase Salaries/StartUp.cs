using SoftUni.Data;
using SoftUni.Models;
using System.Text;

namespace SoftUni
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext dbContext = new SoftUniContext();

            string result = IncreaseSalaries(dbContext);

            Console.WriteLine(result);
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            const decimal SALARY_UPDATE = 1.12m;


            var promotedEmployees = context.Employees
                .Where(e =>
                    e.Department.Name == "Engineering"
                    || e.Department.Name == "Tool Design"
                    || e.Department.Name == "Marketing"
                    || e.Department.Name == "Information Services")
                .ToArray();

            foreach (var e in promotedEmployees)
            {
                e.Salary *= SALARY_UPDATE;
            }

            context.SaveChanges();

            string[] salariesUpdated = context.Employees
                .Where(e =>
                    e.Department.Name == "Engineering"
                    || e.Department.Name == "Tool Design"
                    || e.Department.Name == "Marketing"
                    || e.Department.Name == "Information Services")
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Select(e => $"{e.FirstName} {e.LastName} (${e.Salary:f2})")
                .ToArray();

            return string.Join(Environment.NewLine, salariesUpdated);
        }
    }
}