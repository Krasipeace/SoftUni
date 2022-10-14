using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> employees;
        private string name;
        private int capacity;
        public Bakery(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.employees = new List<Employee>(Capacity);
        }
        public string Name { get { return name; } set { name = value; } }
        public int Capacity { get { return capacity; } set { capacity = value; } }
        public int Count { get { return employees.Count; } }

        public void Add(Employee employee)
        {
            if (employees.Count < Capacity)
            {
                employees.Add(employee);
            }
        }

        public bool Remove(string name)
        {
            Employee employee = employees.Find(e => e.Name == name);

            if (employee != null)
            {
                employees.Remove(employee);

                return true;
            }

            return false;
        }

        public Employee GetOldestEmployee()
        {
            Employee employee = employees.OrderByDescending(e => e.Age).First();

            return employee;
        }

        public Employee GetEmployee(string name)
        {
            Employee employee = employees.Find(e => e.Name == name);

            return employee;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {this.Name}:");
            foreach (var item in employees)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
