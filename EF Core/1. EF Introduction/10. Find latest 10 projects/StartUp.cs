using System.Globalization;
using System.Text;

using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext dbContext = new SoftUniContext();

            string result = GetLatestProjects(dbContext);

            Console.WriteLine(result);
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var latestProjects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    p.StartDate
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var p in latestProjects)
            {
                sb.AppendLine(p.Name);
                sb.AppendLine(p.Description);
                sb.AppendLine(p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture));
            }

            return sb.ToString().TrimEnd();
        }
    }
}