namespace NavalVessels.Models
{
    using System.Text;

    using NavalVessels.Models.Contracts;

    public class Submarine : Vessel, ISubmarine
    {
        private const double SUBMARINE_ARMOR_THICKNESS = 200;
        private const double MAIN_CALIBER_MODIFIER = 40;
        private const double SPEED_MODIFIER = 4;

        public Submarine(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, SUBMARINE_ARMOR_THICKNESS)
        {
            SubmergeMode = false;
        }
        public bool SubmergeMode
        {
            get; private set;
        }

        public void ToggleSubmergeMode()
        {
            if (!SubmergeMode)
            {
                MainWeaponCaliber += MAIN_CALIBER_MODIFIER;
                Speed -= SPEED_MODIFIER;
            }
            else
            {
                MainWeaponCaliber -= MAIN_CALIBER_MODIFIER;
                Speed += SPEED_MODIFIER;
            }

            SubmergeMode = !SubmergeMode;
        }

        public override void RepairVessel()
        {
            ArmorThickness = SUBMARINE_ARMOR_THICKNESS;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string submergeModeOnOff = SubmergeMode ? "ON" : "OFF";

            sb
                .AppendLine(base.ToString())
                .AppendLine($" *Submerge mode: {submergeModeOnOff}");
            return sb.ToString().TrimEnd();
        }
    }
}
