using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        public Computer(string model, int capacity)
        {
            Model = model;
            Capacity = capacity;
            Multiprocessor = new List<CPU>();
        }

        public int Count => Multiprocessor.Count;

        public string Model { get; set; } 

        public int Capacity { get; set; }

        public List<CPU> Multiprocessor { get; set; }

        public void Add(CPU cpu)
        {
            if (Multiprocessor.Count < Capacity)
            {
                Multiprocessor.Add(cpu);
            }
        }

        public bool Remove(string brand)
        {
            foreach (var item in Multiprocessor.Where(item => item.Brand == brand))
            {
                Multiprocessor.Remove(item);

                return true;
            }

            return false;
        }

        public CPU GetCPU(string brand)
        {
            CPU cpu = Multiprocessor
                .FirstOrDefault(x => x.Brand == brand);

            return cpu;
        }

        public CPU MostPowerful()
        {
            CPU cpu = Multiprocessor
                .OrderByDescending(x => x.Cores * x.Frequency)
                .FirstOrDefault();

            return cpu;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"CPUs in the Computer {Model}:");

            foreach (var cpu in Multiprocessor)
            {
                sb.AppendLine(cpu.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
