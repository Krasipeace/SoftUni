namespace DetailPrinter
{
    using System.Collections.Generic;

    public class DetailsPrinter
    {
        private readonly IPrinting printer;
        private IList<Employee> employees;
        public DetailsPrinter(IList<Employee> employees, IPrinting targetPrinter)
        {
            this.printer = targetPrinter;
            this.employees = employees;
        }

        public void PrintDetails()
        {
            foreach (Employee employee in employees)
            {
                printer.Printing(employee.ToString());
            }
        }
    }
}
