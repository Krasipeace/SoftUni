namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AquariumsTests
    {
        private Fish defaultFish;
        private Aquarium defaultAquarium;

        [SetUp]
        public void Setup()
        {
            defaultFish = new Fish("Tuna");    
            defaultAquarium = new Aquarium("FishPool", 2);
        }

        [Test]
        public void CreateFishShouldWorkAsExpected()
        {
            Assert.AreEqual("Tuna", defaultFish.Name);
        }

        [TestCase("")]
        [TestCase(null)]
        public void CreateAquariumWithNullOrEmptyName_ShouldThrowException(string input)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Aquarium newAquarium = new Aquarium(input, 2);
            }, $"{input}, Invalid aquarium name!");
        }

        [Test]
        public void AquariumWithNegativeCapacity_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Aquarium aquaPool = new Aquarium("Aqua", -11);
            }, "Invalid aquarium capacity!"); 
        }

        [Test]
        public void CountingFishWorkAsExpected()
        {
            defaultAquarium.Add(defaultFish);
            Assert.AreEqual(1, defaultAquarium.Count);
        }

        [Test]
        public void AddFishAfterCapacityIsReached_ShouldThrowExceptiion()
        {
            Aquarium aquarium = new Aquarium("Aqua", 2);
            aquarium.Add(new Fish("Cod"));
            aquarium.Add(new Fish("Thelodonti"));
            Assert.Throws<InvalidOperationException>(() =>
            {
                 aquarium.Add(defaultFish);
            }, "Aquarium is full!");
        }

        [Test]
        public void RemoveFishShouldWorkAsExpected()
        {
            defaultAquarium.Add(defaultFish);
            defaultAquarium.RemoveFish("Tuna");
            Assert.AreEqual(0, defaultAquarium.Count);
        }

        [Test]
        public void RemoveInexistentFishFromTheList_ShouldThrowException()
        {
            defaultAquarium.Add(defaultFish);
            Assert.Throws<InvalidOperationException>(() =>
            {
                defaultAquarium.RemoveFish("Mackerel");
            }, $"Fish with the name Mackerel doesn't exist!");
        }

        [Test]
        public void SellFishShouldWorkAsExpected()
        {
            defaultAquarium.Add(defaultFish);
            Fish soldFish = defaultAquarium.SellFish(defaultFish.Name); 

            Assert.AreEqual(defaultFish, soldFish);
            Assert.IsFalse(soldFish.Available);
        }

        [Test]
        public void SellingInexistantFish_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                defaultAquarium.SellFish("Mackerel");
            }, $"Fish with the name Mackerel doesn't exist!");
        }

        [Test]
        public void ReportShouldWorkAsExpected()
        {           
            defaultAquarium.Add(defaultFish);
            defaultAquarium.Add(new Fish("Mackerel"));

            string expected = "Fish available at FishPool: Tuna, Mackerel";
            string actual = defaultAquarium.Report();

            Assert.AreEqual(expected, actual);
        }       
    }
}
