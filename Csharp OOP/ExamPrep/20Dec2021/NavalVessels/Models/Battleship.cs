namespace NavalVessels.Models
{
    using System.Text;

    using NavalVessels.Models.Contracts;

    public class Battleship : Vessel, IBattleship
    {
        private const double BATTLESHIP_ARMOR_THICKNESS = 300;
        private const double MAIN_CALIBER_MODIFIER = 40;
        private const double SPEED_MODIFIER = 5;

        public Battleship(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, BATTLESHIP_ARMOR_THICKNESS)
        {
            SonarMode = false;
        }
        public bool SonarMode
        {
            get; private set;
        }

        public void ToggleSonarMode()
        {
            if (!SonarMode)
            {
                MainWeaponCaliber += MAIN_CALIBER_MODIFIER;
                Speed -= SPEED_MODIFIER;
            }
            else
            {
                MainWeaponCaliber -= MAIN_CALIBER_MODIFIER;
                Speed += SPEED_MODIFIER;
            }

            SonarMode = !SonarMode;
        }

        public override void RepairVessel()
        {
            if (ArmorThickness < BATTLESHIP_ARMOR_THICKNESS)
            {
                ArmorThickness = BATTLESHIP_ARMOR_THICKNESS;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string sonarModeOnOff = SonarMode ? "ON" : "OFF";

            sb.AppendLine(base.ToString())
              .AppendLine($" *Sonar mode: {sonarModeOnOff}");

            return sb.ToString().TrimEnd();
        }
    }
}
