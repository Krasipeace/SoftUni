using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe axe;
        private int attackPoints;
        private int durabilityPoints;

        private Dummy dummy;
        private int health;
        private int experience;

        [SetUp]
        public void Setup()
        {
            attackPoints = 10;
            durabilityPoints = 15;
            health = 100;
            experience = 100;
            axe = new Axe(attackPoints, durabilityPoints);
            dummy = new Dummy(health, experience);
        }

        [Test]
        public void Test_AxeConstructorShouldSetDataProperly()
        {
            Assert.AreEqual(attackPoints, axe.AttackPoints);
            Assert.AreEqual(durabilityPoints, axe.DurabilityPoints);
        }

        [Test]
        public void Test_AxeShouldLoseDurabilityPoints()
        {
            for (int i = 0; i < 5; i++)
            {
                axe.Attack(dummy);
            }
            Assert.AreEqual(durabilityPoints - 5, axe.DurabilityPoints);
        }

        [Test]
        public void Test_AxeAttackShouldThrowException_WhenDurabilityIsZero()
        {
            axe = new Axe(10, 0);
            Assert.Throws<InvalidOperationException>((() =>
            {
                axe.Attack(dummy);
            }));
        }

        [Test]
        public void Test_AxeAttackShouldThrowException_WhenDurabilityIsNegative()
        {
            axe = new Axe(10, -5);
            Assert.Throws<InvalidOperationException>((() =>
            {
                axe.Attack(dummy);
            }));         
        }
    }
}