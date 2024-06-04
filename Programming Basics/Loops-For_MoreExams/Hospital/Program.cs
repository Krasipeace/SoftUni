using System;

namespace Hospital
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int period = int.Parse(Console.ReadLine());       
            int doctors = 7;
            int untreated = 0;
            int treated = 0;

            for (int i = 1; i <= period; i++)
            {
                int patients = int.Parse(Console.ReadLine());
                if (i % 3 == 0 && untreated > treated) //fdjklafhlkadshflk
                {
                    doctors += 1;
                }
                if (patients > doctors)
                {
                    treated += doctors;
                    untreated += patients - doctors;
                }
                else
                {                    
                    treated += patients;
                }
            }
            Console.WriteLine($"Treated patients: {treated}.");
            Console.WriteLine($"Untreated patients: {untreated}.");
        }
    }
}
