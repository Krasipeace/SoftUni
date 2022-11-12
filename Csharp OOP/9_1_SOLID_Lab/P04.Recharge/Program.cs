namespace P04.Recharge
{
    class Program
    {
        static void Main()
        {
            Employee employee = new Employee("worker");
            Robot robot = new Robot("R2D2", 666);

            ISleeper sleeper = employee;
            IRechargeable rechargeable = robot;

            employee.Sleep();
            robot.Work(10);

            rechargeable.Recharge();
        }
    }
}
