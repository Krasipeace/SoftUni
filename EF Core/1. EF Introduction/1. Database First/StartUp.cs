using SoftUni.Data;
using SoftUni.Models;
using System.Globalization;
using System.Text;

namespace SoftUni;

public class StartUp
{
    static void Main(string[] args)
    {
        Console.WriteLine("Connection established...");

        //SoftUniContext dbContext = new SoftUniContext();

        //string result = GetEmployeesFullInformation(dbContext);

        //string result = GetEmployeesWithSalaryOver50000(dbContext);

        //string result = GetEmployeesFromResearchAndDevelopment(dbContext);

        //string result = AddNewAddressToEmployee(dbContext);

        //string result = GetEmployeesInPeriod(dbContext);

        //string result = GetAddressesByTown(dbContext);

        //string result = GetEmployee147(dbContext);

        //string result = GetDepartmentsWithMoreThan5Employees(dbContext);

        //string result = GetLatestProjects(dbContext);

        //string result = IncreaseSalaries(dbContext);

        //string result = GetEmployeesByFirstNameStartingWithSa(dbContext);

        //string result = DeleteProjectById(dbContext);

        //string result = RemoveTown(dbContext);

        //Console.WriteLine(result);
    }


    // Employees Full Information
    public static string GetEmployeesFullInformation(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();
        var employees = context.Employees
            .OrderBy(e => e.EmployeeId)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.MiddleName,
                e.JobTitle,
                e.Salary
            })                   //Query optimization
            .ToArray();

        foreach (var employee in employees)
        {
            sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
        }

        return sb.ToString().TrimEnd();
    }


    // Employees with Salary Over 50 000
    public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();
        var employees = context.Employees
            .OrderBy(e => e.FirstName)
            .Select(e => new
            {
                e.FirstName,
                e.Salary
            })
            .Where(e => e.Salary > 50000)
            .ToArray();

        foreach (var employee in employees)
        {
            sb.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
        }

        return sb.ToString().TrimEnd();
    }


    //  Employees from Research and Development
    public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
    {
        var employeesRnD = context.Employees
            .Where(e => e.Department.Name == "Research and Development")
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                DepartmentName = e.Department.Name,
                e.Salary
            })
            .OrderBy(e => e.Salary)
            .ThenByDescending(e => e.FirstName)
            .ToArray();


        StringBuilder sb = new StringBuilder();

        foreach (var e in employeesRnD)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:f2}");
        }

        return sb.ToString().TrimEnd();
    }


    // Adding a New Address and Updating Employee 
    public static string AddNewAddressToEmployee(SoftUniContext context)
    {
        Address newAddress = new Address()
        {
            AddressText = "Vitoshka 15",
            TownId = 4
        };
        //context.Addresses.Add(newAddress); //Flag to Add the new address to DB

        Employee? employee = context.Employees
            .FirstOrDefault(e => e.LastName == "Nakov");
        employee.Address = newAddress;

        context.SaveChanges(); //adding the new address to DB

        string[] employeeAddresses = context.Employees
            .OrderByDescending(e => e.AddressId)
            .Take(10)
            .Select(e => e.Address!.AddressText)
            .ToArray();

        return string.Join(Environment.NewLine, employeeAddresses);
    }


    // employees and projects
    public static string GetEmployeesInPeriod(SoftUniContext context)
    {
        var employeesWithProjects = context.Employees
            //.Where(e => e.EmployeesProjects
            //    .Any(ep => ep.Project.StartDate.Year >= 2001 &&
            //    ep.Project.StartDate.Year <= 2003))
            .Take(10)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                ManagerFirstName = e.Manager!.FirstName,
                ManagerLastName = e.Manager!.LastName,
                Projects = e.EmployeesProjects
                    .Where(ep => ep.Project.StartDate.Year >= 2001 &&
                                 ep.Project.StartDate.Year <= 2003)
                    .Select(ep => new
                    {
                        ProjectName = ep.Project.Name,
                        StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                        EndDate = ep.Project.EndDate.HasValue
                        ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                        : "not finished"
                    })
                    .ToArray()
            })
            .ToArray();

        StringBuilder sb = new StringBuilder();

        foreach (var e in employeesWithProjects)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");

            foreach (var p in e.Projects)
            {
                sb.AppendLine($"--{p.ProjectName} - {p.StartDate} - {p.EndDate}");
            }
        }

        return sb.ToString().TrimEnd();
    }


    // address by town
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


    //    Employee 147 
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


    //  Departments with More Than 5 Employees
    public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
    {
        var departments = context.Departments
            .Where(d => d.Employees.Count > 5)
            .OrderBy(d => d.Employees.Count)
            .ThenBy(d => d.Name)
            .Select(d => new
            {
                DepartmentName = d.Name,
                ManagerFirstName = d.Manager.FirstName,
                ManagerLastName = d.Manager.LastName,
                Employees = d.Employees
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.JobTitle
                    })
                    .ToArray()
            })
            .ToArray();

        StringBuilder sb = new StringBuilder();

        foreach (var d in departments)
        {
            sb.AppendLine($"{d.DepartmentName} - {d.ManagerFirstName} {d.ManagerLastName}");
            foreach (var e in d.Employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
            }
        }

        return sb.ToString().TrimEnd();
    }


    // 	Find Latest 10 Projects 
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


    // increase salaries
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


    //  Find Employees by First Name Starting With Sa
    public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
    {
        string[] employeesStartingwithSA = context.Employees
            .Where(e => e.FirstName.Substring(0, 2).ToLower() == "sa")
            .OrderBy(e => e.FirstName)
            .ThenBy(e => e.LastName)
            .Select(e => $"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})")
            .ToArray();

        return string.Join(Environment.NewLine, employeesStartingwithSA);
    }


    //  Delete project by Id
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


    // Remove Town
    public static string RemoveTown(SoftUniContext context)
    {
        Town townToDelete = context.Towns
            .Where(t => t.Name == "Seattle")
            .FirstOrDefault()!;

        Address[] addressToDelete = context.Addresses
            .Where(a => a.TownId == townToDelete.TownId)
            .ToArray();

        Employee[] employeesToRemove = context.Employees
            .Where(e => addressToDelete
                .Contains(e.Address))
            .ToArray();

        foreach (var e in employeesToRemove)
        {
            e.AddressId = null;
        }

        context.Addresses.RemoveRange(addressToDelete);
        context.Towns.Remove(townToDelete);
        context.SaveChanges();

        return $"{addressToDelete.Count()} addresses in Seattle were deleted";
    }
}