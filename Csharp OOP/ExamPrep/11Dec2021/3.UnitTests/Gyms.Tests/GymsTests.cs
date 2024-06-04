namespace Gyms.Tests
{
    using NUnit.Framework;
    using System.Linq;
    using System;

    public class GymsTests
    {
               private Gym gym;
        private Athlete athlete;

        [SetUp]
        public void SetUp()
        {
            gym = new Gym("Gym", 100);
            athlete = new Athlete("Dimitrichko");
        }

        [Test]
        public void Test_ConstructorStructure_ShouldWorkAsExpected()
        {
            Assert.AreNotEqual(null, gym);
            Assert.AreEqual("Gym", gym.Name);
            Assert.AreEqual(100, gym.Capacity);
            Assert.AreEqual(0, gym.Count);
            Assert.That(gym.GetType().GetProperties().Count() == 3);
        }

        [TestCase(null)]
        [TestCase("")]
        public void Test_NameNullValueShouldThrowException(string name)
        {
            Assert.Throws<ArgumentNullException>(() 
                => new Gym(name, 100));
        }

        [Test]
        public void Test_CapacityShouldWorkAsExpected()
        {
            gym.AddAthlete(athlete);
            Assert.AreEqual(1, gym.Count);
        }

        [Test]
        public void Test_NegativeCapacity_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() 
                => new Gym("Gym", -10));
        }

        [Test]
        public void Test_AddNewAthelete_ShouldWorkAsExpected()
        {
            Gym expected = new Gym("Gym", 1);
            Athlete athlete = new Athlete("Gosho");
            expected.AddAthlete(athlete);
            Assert.Throws<InvalidOperationException>(() => expected.AddAthlete(athlete));
        }

        [Test]
        public void Test_Remove_ShouldWorkAsExpected()
        {
            gym.AddAthlete(athlete);
            gym.RemoveAthlete("Dimitrichko");

            Assert.AreEqual(0, gym.Count);
        }

        [Test]
        public void Test_Remove_ShouldThrowException_WhenTryToRemoveNotExistingMember()
        {
            gym.AddAthlete(athlete);

            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("Hristo"));
        }

        [Test]
        public void Test_InjureAthlete_ShouldWorkAsExpected()
        {
            Assert.IsFalse(athlete.IsInjured);

            gym.AddAthlete(athlete);
            gym.InjureAthlete("Dimitrichko");

            Assert.IsTrue(athlete.IsInjured);
            Assert.AreEqual(athlete, gym.InjureAthlete("Dimitrichko"));
        }

        [Test]
        public void Test_InjureAthlete_ShouldThrowException_WhenMemberDoesNotExist()
        {
            Assert.IsFalse(athlete.IsInjured);

            gym.AddAthlete(athlete);

            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete("Itso"));
        }

        [Test]
        public void Test_Report_ShouldWorkAsExpected()
        {
            Athlete newAthlete = new Athlete("Itzo");
            gym.AddAthlete(newAthlete);
            gym.AddAthlete(athlete);
            gym.InjureAthlete("Dimitrichko");

            Assert.AreEqual($"Active athletes at {gym.Name}: {newAthlete.FullName}", gym.Report());
        }
    }
}