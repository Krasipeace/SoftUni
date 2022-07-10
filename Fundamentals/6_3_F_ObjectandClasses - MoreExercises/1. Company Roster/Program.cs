using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Company_Roster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Department> departments = new List<Department>();

            int numberOfEmployees = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfEmployees; i++)
            {
                string[] info = Console.ReadLine().Split();
                string name = info[0];
                double salary = double.Parse(info[1]);
                string department = info[2];

                if (!departments.Any(eachDep => eachDep.DepartmentName == department))
                {
                    departments.Add(new Department(department));
                }

                departments.Find(d => d.DepartmentName == department).AddNewEmployee(name, salary);
            }

            Department bestDepartment = departments.OrderByDescending(bestDep => bestDep.TotalSalaries / bestDep.Employees.Count()).First();

            Console.WriteLine($"Highest Average Salary: {bestDepartment.DepartmentName}");

            foreach (Employee employee in bestDepartment.Employees.OrderByDescending(emp => emp.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:F2}");
            }
        }
    }

    class Employee
    {
        public Employee(string name, double salary)
        {
            Name = name;
            Salary = salary;
        }

        public string Name { get; private set; }
        public double Salary { get; private set; }
    }
    class Department
    {
        public Department(string department)
        {
            DepartmentName = department;
        }

        public string DepartmentName { get; set; }

        public List<Employee> Employees = new List<Employee>();
        public double TotalSalaries { get; private set; }

        public void AddNewEmployee(string eName, double eSalary)
        {
            TotalSalaries += eSalary;
            Employees.Add(new Employee(eName, eSalary));
        }

    }
}
