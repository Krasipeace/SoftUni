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

            string result = GetEmployee147(dbContext);

            Console.WriteLine(result);
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var employee147 = context.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects
                        .Select(ep => new
                        {
                            ProjectName = ep.Project.Name
                        })
                        .OrderBy(ep => ep.ProjectName)
                        .ToArray()
                })
                .FirstOrDefault();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");

            sb.Append(string.Join(Environment.NewLine, employee147.Projects.Select(p => p.ProjectName)));

            return sb.ToString().TrimEnd();
        }
    }
}