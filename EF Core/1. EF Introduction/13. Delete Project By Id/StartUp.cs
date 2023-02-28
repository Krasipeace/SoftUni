using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext dbContext = new SoftUniContext();

            string result = DeleteProjectById(dbContext);

            Console.WriteLine(result);
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            IQueryable<EmployeeProject> epToDelete = context.EmployeesProjects
                .Where(ep => ep.ProjectId == 2);

            if (epToDelete != null)
            {
                context.EmployeesProjects.RemoveRange(epToDelete);
            }

            Project projectToDelete = context.Projects.Find(2)!;
            context.Projects.Remove(projectToDelete);
            context.SaveChanges();

            string[] projectNames = context.Projects
                .Take(10)
                .Select(p => p.Name)
                .ToArray();

            return string.Join(Environment.NewLine, projectNames);
        }
    }
}