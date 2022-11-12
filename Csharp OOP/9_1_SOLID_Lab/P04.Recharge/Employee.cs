namespace P04.Recharge
{
    public class Employee : Worker, ISleeper
    {
        public Employee(string id) : base(id)
        {
        }

        public void Sleep()
        {
            System.Console.WriteLine("ZZzzzz...");
        }

        //public override void Recharge()
        //{
        //    throw new InvalidOperationException("Employees cannot recharge");
        //}
    }
}
