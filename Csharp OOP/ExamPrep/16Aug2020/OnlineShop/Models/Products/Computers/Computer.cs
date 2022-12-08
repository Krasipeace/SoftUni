namespace OnlineShop.Models.Products.Computers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using OnlineShop.Common.Constants;
    using OnlineShop.Common.Enums;
    using OnlineShop.Models.Products.Components;
    using OnlineShop.Models.Products.Peripherals;

    public abstract class Computer : Product, IComputer
    {
        private List<IComponent> components;
        private List<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) : base(id, manufacturer, model, price, overallPerformance)
        {
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => components.AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => peripherals.AsReadOnly();

        public override double OverallPerformance
        {
            get
            {
                if (components.Count == 0)
                {
                    return base.OverallPerformance;
                }

                return base.OverallPerformance + components.Sum(x => x.OverallPerformance);
            }
        }

        public override decimal Price
            => base.Price + components.Sum(x => x.Price) + peripherals.Sum(x => x.Price);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine(base.ToString())
                .AppendLine($" Components ({components.Count}):");
            if (components.Count > 0)
            {
                sb.AppendLine(string.Join(Environment.NewLine, components.Select(x => $"  {x}")));
            }

            if (peripherals.Count > 0)
            {
                sb.AppendLine($" Peripherals ({peripherals.Count}); Average Overall Performance ({components.Average(x => x.OverallPerformance)}):");
            }
            else
            {
                sb.AppendLine($" Peripherals ({peripherals.Count}); Average Overall Performance (0):");
            }

            if (peripherals.Count <= 0)
            {
                return sb.ToString().TrimEnd();
            }
            sb.Append(string.Join(Environment.NewLine, peripherals.Select(x => $"  {x}")));

            return sb.ToString().TrimEnd();
        }

        public void AddComponent(IComponent component)
        {
            var toAdd = components.FirstOrDefault(x => x.GetType().Name == component.GetType().Name);
            if (toAdd != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent, component.GetType().Name, components.GetType().Name, Id));
            }
            components.Add(component);
        }
        public IComponent RemoveComponent(string componentType)
        {
            var toRemove = components.FirstOrDefault(x => x.GetType().Name == componentType);
            if (toRemove == null)
            {
                throw new ArgumentException($"Component {componentType} does not exist in {components.GetType().Name} with {Id}.");
            }
            components.Remove(toRemove);

            return toRemove;
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            var toAdd = peripherals.FirstOrDefault(x => x.GetType().Name == peripheral.GetType().Name);
            if (toAdd != null)
            {
                peripherals.Add(toAdd);
            }
            throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name, GetType().Name, Id));
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            var toRemove = peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            if (toRemove == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, GetType().Name, Id));
            }
            peripherals.Remove(toRemove);

            return toRemove;
        }
    }
}
