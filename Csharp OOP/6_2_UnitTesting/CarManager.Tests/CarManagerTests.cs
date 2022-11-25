namespace CarManager.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class CarManagerTests
    {
        private Car simulatedCar;

        [SetUp]
        public void SetUp()
        {
            this.simulatedCar = new Car("Opel", "Astra", 6.6, 75);
        }


        //  BEST CASE SCENARIO
        [Test]
        public void Test_CarMake_ShouldWorkCorrectly()
        {
            string expectedMake = "Opel";
            Car car = new Car(expectedMake, "Astra", 6.6, 75);

            string actualMake = simulatedCar.Make;
            Assert.AreEqual(expectedMake, actualMake);
        }

        [Test]
        public void Test_CarModel_ShouldWorkCorrectly()
        {
            string expectedModel = "Astra";
            Car car = new Car("Opel", expectedModel, 6.6, 75);

            string actualModel = simulatedCar.Model;
            Assert.AreEqual(expectedModel, actualModel);
        }

        [Test]
        public void Test_CarFuelConsumption_ShouldWorkCorrectly()
        {
            double expectedFuelConsumption = 6.6;
            Car car = new Car("Opel", "Astra", expectedFuelConsumption, 75);

            double actualFuelConsumption = simulatedCar.FuelConsumption;
            Assert.AreEqual(expectedFuelConsumption, actualFuelConsumption);
        }

        [Test]
        public void Test_CarFuelCapacity_ShouldWorkCorrectly()
        {
            double expectedFuelCapacity = 75;
            Car car = new Car("Opel", "Astra", 6.6, expectedFuelCapacity);
            double actualFuelCapacity = simulatedCar.FuelCapacity;
            Assert.AreEqual(expectedFuelCapacity, actualFuelCapacity);
        }

        [Test]
        public void Test_RefuelShouldWorkCorrectly()
        {
            double fuelToRefuel = 10;
            double expectedFuelToRefuel = 10;

            simulatedCar.Refuel(fuelToRefuel);
            Assert.AreEqual(expectedFuelToRefuel, simulatedCar.FuelAmount, "Refuel does not add in the fuel properly");
        }

        [TestCase(10)]
        [TestCase(50)]
        [TestCase(150)]
        public void Test_Drive_ShouldWorkCorrectly(double distance)
        {
            simulatedCar.Refuel(70);
            double expectedSpentFuel = simulatedCar.FuelAmount - (distance / 100) * simulatedCar.FuelConsumption;
            simulatedCar.Drive(distance);

            Assert.AreEqual(expectedSpentFuel, simulatedCar.FuelAmount, "Drive does not decrease Fuel Amount properly");
        }


        // WORST CASE SCENARIO

        [Test]
        public void Test_Drive_ShouldThrowException_WhenNotEnoughFuelToDriveDistance()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                simulatedCar.Drive(666);
            }, "Drive should throw exception when not enough fuel for the desired distance!");
        }

        [TestCase(0)]
        [TestCase(-10)]
        public void Test_Refuel_ShouldThrowException_WhenTryToRefuel_WithNegativeOrZeroAmountOfFuel(double fuelToRefuel)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                simulatedCar.Refuel(fuelToRefuel);
            }, "Fuel amount cannot be zero or negative!");
        }

        [Test]
        public void Test_Refuel_FuelAmountCannotBeFilledInTankCapacity()
        {
            double fuelToRefuel = 100;
            double expectedFuelAmount = simulatedCar.FuelCapacity;

            simulatedCar.Refuel(fuelToRefuel);
            Assert.AreEqual(expectedFuelAmount, simulatedCar.FuelAmount, "Fuel Cannot Fit in the car Fuel Tank");
        }

        [TestCase(null)]
        [TestCase("")]
        public void Test_CarMake_ShouldThrowException_WhenIsNullOrEmpty(string make)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, "Astra", 6.6, 75);
            }, "Make cannot be null or empty!");
        }

        [TestCase(null)]
        [TestCase("")]
        public void Test_CarModel_ShouldThrowException_WhenIsNullOrEmpty(string model)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Opel", model, 6.6, 75);
            }, "Model cannot be null or empty!");
        }

        [TestCase(0)]
        [TestCase(-10)]
        public void Test_CarFuelConsumption_ShouldThrowException_WhenIsZeroOrNegative(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Opel", "Astra", fuelConsumption, 75);
            }, "Fuel consumption cannot be zero or negative!");
        }

        [TestCase(0)]
        [TestCase(-10)]
        public void Test_CarFuelCapacity_ShouldThrowException_WhenIsZeroOrNegative(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Opel", "Astra", 6.6, fuelCapacity);
            }, "Fuel capacity cannot be zero or negative!");
        }
    }
}