using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Dummy dummy;
        private int health;
        private int experience;

        [SetUp]
        public void Setup()
        {
            health = 10;
            experience = 15;
            dummy = new Dummy(health, experience);
        }

        [Test]
        public void Test_DummyConstructor_ShouldSetDataCorrectly()
        {
            Assert.AreEqual(health, dummy.Health);
        }

        [Test]
        public void Test_DummyLosesHealth_WhenAttacked()
        {
            dummy.TakeAttack(5);
            Assert.AreEqual(health - 5, dummy.Health);
        }

        [Test]
        public void Test_DummyShouldThrowException_WhenAttackedAndHealthIsZero()
        {
            dummy.TakeAttack(health);
            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.TakeAttack(1);
            });
        }

        [Test]
        public void Test_DummyShouldThrowException_WhenAttackedAndHealthIsNegative()
        {
            dummy.TakeAttack(health + 10);
            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.TakeAttack(1);
            });
        }

        [Test]
        public void Test_DummyShouldGiveExperienceWhenIsDead()
        {
            dummy.TakeAttack(health + 10);
            int dummyExperience = dummy.GiveExperience();
            Assert.AreEqual(experience, dummyExperience);
        }

        [Test]
        public void Test_DummyGiveExperienceShouldThrowException_WhenDummyIsAlive()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.GiveExperience();
            });
        }
    }
}