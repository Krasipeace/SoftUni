using System;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double weight;
        public Dough()
        {
        }
        public Dough(string flourType, string bakingTechnique, double weight) : this()
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }
        private string FlourType
        {
            get
            {
                return flourType;
            }
            set
            {
                if (value != "White" && value != "Wholegrain")
                {
                    throw new ArgumentException(ExceptionMessages.INVALID_DOUGH_TYPE);
                }

                flourType = value;
            }
        }
        private string BakingTechnique
        {
            get
            {
                return bakingTechnique;
            }
            set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException(ExceptionMessages.INVALID_DOUGH_TYPE);
                }

                bakingTechnique = value;
            }
        }
        private double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if (value < 1 || value > Constants.MAX_GRAMS_DOUGH)
                {
                    throw new ArgumentException(ExceptionMessages.INVALID_DOUGH_WEIGHT);
                }

                weight = value;
            }
        }

        public double GetDoughCalories()
        {
            double flourModifier = GetFlourTypeModifier(FlourType);
            double bakingModifier = GetBakingTechniqueModifier(BakingTechnique);

            double doughCalories = ((Constants.DEFAULT_CALORIES_DOUGH * Weight) * flourModifier * bakingModifier);

            return doughCalories;
        }

        private double GetFlourTypeModifier(string flourType)
        {
            double flourModifier = 0;

            switch (flourType.ToLower())
            {
                case "white":
                    flourModifier = Constants.DOUGH_WHITE;
                    break;
                case "wholegrain":
                    flourModifier = Constants.DOUGH_WHOLEGRAIN;
                    break;
            }

            return flourModifier;
        }

        private double GetBakingTechniqueModifier(string bakingTechnique)
        {
            double bakingTechniqueModifier = 0;

            switch (bakingTechnique.ToLower())
            {
                case "crispy":
                    bakingTechniqueModifier = Constants.DOUGH_CRISPY;
                    break;
                case "chewy":
                    bakingTechniqueModifier = Constants.DOUGH_CHEWY;
                    break;
                case "homemade":
                    bakingTechniqueModifier = Constants.DOUGH_HOMEMADE;
                    break;
            }

            return bakingTechniqueModifier;
        }

    }
}