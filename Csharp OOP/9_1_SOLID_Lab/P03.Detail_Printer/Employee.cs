namespace DetailPrinter
{
    public class Employee
    {
        public Employee(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        public override string ToString() => Name;
    }
}
