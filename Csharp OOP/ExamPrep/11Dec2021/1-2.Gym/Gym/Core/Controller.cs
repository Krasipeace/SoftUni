using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Repositories.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository equipment;
        private List<IGym> gyms;
        public Controller()
        {
            equipment = new EquipmentRepository();
            gyms = new List<IGym>();
        }


        public string AddGym(string gymType, string gymName)
        {
            if (gymType != "BoxingGym" && gymType != "WeightliftingGym")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }

            IGym gym;
            if (gymType == "BoxingGym")
            {
                gym = new BoxingGym(gymName);
            }
            else 
            {
                gym = new WeightliftingGym(gymName);
            }
            gyms.Add(gym);

            return string.Format(OutputMessages.SuccessfullyAdded, gymName);
        }


        public string AddEquipment(string equipmentType)
        {
            if (equipmentType != "BoxingGloves" && equipmentType != "Kettlebell")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }

            IEquipment item;
            if (equipmentType == "BoxingGloves")
            {
                item = new BoxingGloves();
            }
            else
            {
                item = new Kettlebell();
            }
            equipment.Add(item);

            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IEquipment item = equipment.FindByType(equipmentType);
            if (item == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }
            IGym gym = gyms.First(x => x.Name == gymName);
            gym.AddEquipment(item);
            equipment.Remove(item);

            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }


        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            if (athleteType != "Boxer" && athleteType != "Weightlifter")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);               
            }

            IGym gym = gyms.First(x => x.Name == gymName);
            IAthlete athlete;

            if (athleteType == "Boxer")
            {
                athlete = new Boxer(athleteName, motivation, numberOfMedals);
                if (gym.GetType().Name != "BoxingGym")
                {
                    return OutputMessages.InappropriateGym;
                }
            }
            else
            {
                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
                if (gym.GetType().Name != "WeightliftingGym")
                {
                    return OutputMessages.InappropriateGym;
                }
            }
            gym.AddAthlete(athlete);

            return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
        }


        public string TrainAthletes(string gymName)
        {
            IGym gym = gyms.Find(x => x.Name == gymName);
            gym.Exercise();

            return string.Format(OutputMessages.AthleteExercise, gym.Athletes.Count);
        }


        public string EquipmentWeight(string gymName)
        {
            IGym gym = gyms.First(x => x.Name == gymName);

            return string.Format(OutputMessages.EquipmentTotalWeight, gymName, gym.EquipmentWeight);
        }


        public string Report()
        {
            return string.Join(Environment.NewLine, gyms.Select(x => x.GymInfo())).TrimEnd();
        }
    }
}
