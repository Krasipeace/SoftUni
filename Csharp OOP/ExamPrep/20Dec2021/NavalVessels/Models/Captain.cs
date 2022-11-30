namespace NavalVessels.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using NavalVessels.Models.Contracts;
    using NavalVessels.Utilities.Messages;

    public class Captain : ICaptain
    {
        private string fullName;
        private List<IVessel> vessels;
        private int CombatExperience;
        public Captain(string fullName)
        {
            FullName = fullName;
            vessels = new List<IVessel>();
            CombatExperience = 0;
        }
        public string FullName
        {
            get
            {
                return fullName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidCaptainName);
                }
                fullName = value;
            }
        }

        public ICollection<IVessel> Vessels => vessels.AsReadOnly();

        int ICaptain.CombatExperience => CombatExperience;

        public void AddVessel(IVessel vessel)
        {
            if (string.IsNullOrWhiteSpace(vessel.Name))
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.InvalidVesselForCaptain));
            }
            vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            CombatExperience += 10;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{FullName} has {CombatExperience} combat experience and commands {vessels.Count} vessels.");

            if (vessels.Count > 0)
            {
                foreach (var item in vessels)
                {
                    sb.AppendLine(item.ToString());                   
                }
            }

            return sb.ToString().Trim();
        }
    }
}
