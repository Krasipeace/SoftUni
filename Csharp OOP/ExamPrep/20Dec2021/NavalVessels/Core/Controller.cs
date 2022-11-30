namespace NavalVessels.Core
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Contracts;
    using NavalVessels.Models;
    using NavalVessels.Utilities.Messages;
    using Repositories;

    public class Controller : IController
    {
        private VesselRepository vessels;
        private List<ICaptain> captains;
        public Controller()
        {
            vessels = new VesselRepository();
            captains = new List<ICaptain>();
        }
        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            ICaptain captain = captains.Find(x => x.FullName == selectedCaptainName);
            IVessel vessel = vessels.FindByName(selectedVesselName);

            if (captain == null)
            {
                return string.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            }
            if (vessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, selectedVesselName);
            }
            if (vessel.Captain != null)
            {
                return string.Format(OutputMessages.VesselOccupied, selectedVesselName);
            }
            captain.AddVessel(vessel);
            vessel.Captain = captain;

            return string.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel vesselAttacking = vessels.FindByName(attackingVesselName);
            IVessel vesselDefending = vessels.FindByName(defendingVesselName);

            if (vesselAttacking == null)
            {
                return string.Format(OutputMessages.VesselNotFound, attackingVesselName);
            }
            if (vesselDefending == null)
            {
                return string.Format(OutputMessages.VesselNotFound, defendingVesselName);
            }
            if (vesselAttacking.ArmorThickness == 0)
            {
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);
            }
            if (vesselDefending.ArmorThickness == 0)
            {
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);
            }

            vesselAttacking.Attack(vesselDefending);
            vesselAttacking.Captain.IncreaseCombatExperience();
            vesselDefending.Captain.IncreaseCombatExperience();

            return string.Format(OutputMessages.SuccessfullyAttackVessel, defendingVesselName, attackingVesselName, vesselDefending.ArmorThickness);
        }

        public string CaptainReport(string captainFullName)
        {
            ICaptain captain = captains.First(x => x.FullName == captainFullName);

            return captain.Report();
        }

        public string HireCaptain(string fullName)
        {
            ICaptain captain = new Captain(fullName);
            if (captains.Any(x => x.FullName == fullName))
            {
                return string.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            }
            captains.Add(captain);

            return string.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            if (vessels.FindByName(name) != null)
            {
                return string.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType, name);
            }

            IVessel vessel;
            switch (vesselType)
            {
                case "Battleship":
                    vessel = new Battleship(name, mainWeaponCaliber, speed);
                    break;
                case "Submarine":
                    vessel = new Submarine(name, mainWeaponCaliber, speed);
                    break;
                default:
                    return OutputMessages.InvalidVesselType;
            }
            vessels.Add(vessel);

            return string.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
        }

        public string ServiceVessel(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);
            if (vessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, vesselName);
            }

            return string.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
        }

        public string ToggleSpecialMode(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);
            string output;
            switch (vessel.GetType().Name)
            {
                case "Battleship":
                    (vessel as Battleship).ToggleSonarMode();
                    output = string.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
                    break;
                case "Submarine":
                    (vessel as Submarine).ToggleSubmergeMode();
                    output = string.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
                    break;
                default:
                    output = string.Format(OutputMessages.VesselNotFound, vesselName);
                    break;
            }

            return output;
        }

        public string VesselReport(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);

            return vessel.ToString().Trim();
        }
    }
}
