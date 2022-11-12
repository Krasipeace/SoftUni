namespace DetailPrinter
{
    class Program
    {
        static void Main()
        {
            Printer printer = new Printer();
            string[] documents = new[] { "doc1", "doc2" };

            Employee[] employees = new Employee[] { new Employee("Stamat"), new Manager("Dimitrichko", documents), };
            DetailsPrinter detailsPrinter = new DetailsPrinter(employees, printer);

            detailsPrinter.PrintDetails();
        }
    }
}
