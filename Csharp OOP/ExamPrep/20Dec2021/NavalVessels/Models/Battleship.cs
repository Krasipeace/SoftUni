namespace NavalVessels.Models
{
    using System.Text;

    using NavalVessels.Models.Contracts;

    public class Battleship : Vessel, IBattleship
    {
        private const double BATTLESHIP_ARMOR_THICKNESS = 300;
        private bool sonarMode;
        public Battleship(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, BATTLESHIP_ARMOR_THICKNESS)
        {
            SonarMode = false;
        }
        public bool SonarMode
        {
            get
            {
                return sonarMode;
            }
            private set
            {
                sonarMode = value;
            }
        }

        public void ToggleSonarMode()
        {
            SonarMode = !SonarMode;
            if (SonarMode)
            {
                MainWeaponCaliber += 40;
                Speed -= 5;
            }
            else
            {
                MainWeaponCaliber -= 40;
                Speed += 5;
            }
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
            string sonarStatus = string.Empty;
            if (SonarMode)
            {
                sonarStatus = "ON";
            }
            else
            {
                sonarStatus = "OFF";
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($" *Sonar mode: {sonarStatus}");

            return base.ToString() + sb.ToString().Trim();
        }
    }
}
