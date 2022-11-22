using System;
public class StartUp
{
    static void Main(string[] args)
    {
        Axe axe = new Axe(10, 10);
        Dummy dummy = new Dummy(10, 10);

        while (!dummy.IsDead() || axe.DurabilityPoints == 0)
        {
            axe.Attack(dummy);
        }

        Console.WriteLine(String.Join("", axe.DurabilityPoints));
        Console.WriteLine(String.Join("", dummy.Health));
    }
}
