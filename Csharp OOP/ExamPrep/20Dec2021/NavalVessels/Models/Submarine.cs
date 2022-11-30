namespace NavalVessels.Models
{
    using System;
    using System.Text;

    using NavalVessels.Models.Contracts;

    public class Submarine : Vessel, ISubmarine
    {
        private const double SUBMARINE_ARMOR_THICKNESS = 200;
        private bool submergeMode;
        public Submarine(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, SUBMARINE_ARMOR_THICKNESS)
        {
            SubmergeMode = false;
        }
        public bool SubmergeMode
        {
            get
            {
                return submergeMode;
            }
            private set
            {
                submergeMode = value;
            }
        }

        public void ToggleSubmergeMode()
        {
            SubmergeMode = !SubmergeMode;
            if (SubmergeMode)
            {
                MainWeaponCaliber += 40;
                Speed -= 4;
            }
            else
            {
                MainWeaponCaliber -= 40;
                Speed += 4;
            }
        }

        public override void RepairVessel()
        {
            if (ArmorThickness < SUBMARINE_ARMOR_THICKNESS)
            {
                ArmorThickness = SUBMARINE_ARMOR_THICKNESS;
            }
        }

        public override string ToString()
        {
            string submergeStatus = string.Empty;
            if (SubmergeMode)
            {
                submergeStatus = "ON";
            }
            else
            {
                submergeStatus = "OFF";
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($" *Submerge mode: {submergeStatus}");

            return base.ToString() + sb.ToString().Trim();
        }
    }
}
