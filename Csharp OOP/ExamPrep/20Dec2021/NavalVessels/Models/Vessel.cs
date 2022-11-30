namespace NavalVessels.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using NavalVessels.Models.Contracts;
    using NavalVessels.Utilities.Messages;

    public abstract class Vessel : IVessel
    {
        private const int BELOW_ZERO_SET = 0;

        private string name;
        private double mainWeponCaliber;
        private double speed;
        private double armorThickness;
        private List<string> targets;
        private ICaptain captain;
        public Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            Name = name;
            MainWeaponCaliber = mainWeaponCaliber;
            Speed = speed;
            ArmorThickness = armorThickness;
            targets = new List<string>();
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(string.Format(ExceptionMessages.InvalidVesselName));
                }
                name = value;
            }
        }
        public double MainWeaponCaliber
        {
            get
            {
                return mainWeponCaliber;
            }
            protected set
            {
                mainWeponCaliber = value;
            }
        }
        public double Speed
        {
            get
            {
                return speed;
            }
            protected set
            {
                speed = value;
            }
        }
        public double ArmorThickness
        {
            get
            {
                return armorThickness;
            }
            set
            {
                if (value < 0)
                {
                    value = BELOW_ZERO_SET;
                }
                armorThickness = value;
            }
        }


        public ICaptain Captain
        {
            get
            {
                return captain;
            }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException(string.Format(ExceptionMessages.InvalidCaptainToVessel));
                }
                captain = value;
            }
        }

        public ICollection<string> Targets => targets.AsReadOnly();

        public void Attack(IVessel target)
        {
            if (target == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidTarget);
            }
            target.ArmorThickness -= mainWeponCaliber;
            targets.Add(target.Name);
        }

        public virtual void RepairVessel()
        {
        }

        public override string ToString()
        {
            string targetsList = string.Empty;
            if (targets.Count == 0)
            {
                targetsList = "None";
            }
            else
            {
                targetsList = string.Join(", ", targets);
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- {Name}");
            sb.AppendLine($"*Type: {this.GetType().Name}");
            sb.AppendLine($"*Armor thickness: {ArmorThickness}");
            sb.AppendLine($"*Main weapon caliber: {MainWeaponCaliber}");
            sb.AppendLine($"*Speed: {Speed}");
            sb.AppendLine($"*Targets: {targetsList}");

            return sb.ToString().Trim();
        }
    }
}
