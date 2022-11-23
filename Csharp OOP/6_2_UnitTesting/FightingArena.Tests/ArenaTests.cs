namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
        }

        [Test]
        public void Test_ConstructorShouldInitializeWarriorCollection()
        {
            Arena arena = new Arena();

            Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void Test_EnrollNonExistingWarriorShouldSuccess()
        {
            Warrior warrior = new Warrior("Snow", 50, 100);

            this.arena.Enroll(warrior);

            bool isEnrolled = this.arena.Warriors.Contains(warrior);

            Assert.IsTrue(isEnrolled);
        }

        [Test]
        public void Test_EnrollSameWarriorShouldThrowException()
        {
            Warrior warrior = new Warrior("Snow", 99, 666);
            this.arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Enroll(warrior);
            }, "Warrior is already enrolled for fights in the arena!");
        }

        [Test]
        public void Test_EnrollWarrior_WithSameName_ShouldThrowException()
        {
            Warrior attacker = new Warrior("Snow", 50, 100);
            Warrior defender = new Warrior("Snow", 44, 100);

            this.arena.Enroll(attacker);
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Enroll(defender);
            }, "Warrior is already Enrolled for the fights in the arena!");
        }

        [Test]
        public void Test_CountShouldReturnEnrolledWarriorsCount()
        {
            Warrior attacker = new Warrior("Snow", 50, 100);
            Warrior defender = new Warrior("Littlefinger", 44, 66);

            this.arena.Enroll(attacker);
            this.arena.Enroll(defender);

            int expectedCount = 2;
            int actualCount = this.arena.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Test_CountShouldReturnZero_WhenNoWarriorIsEnrolled()
        {
            int expectedCount = 0;
            int actualCount = this.arena.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Test_FightShouldThrowException_withNonExistingAttacker()
        {
            Warrior attacker = new Warrior("Snow", 66, 666);
            Warrior defender = new Warrior("Littlefinger", 33, 100);

            this.arena.Enroll(defender);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight(attacker.Name, defender.Name);
            }, $"There is no attacker with name {attacker.Name} enrolled for the fights!");
        }

        [Test]
        public void Test_FightShouldThrowException_WithNonExistingDefender()
        {
            Warrior attacker = new Warrior("Snow", 66, 666);
            Warrior defender = new Warrior("Littlefinger", 33, 100);

            this.arena.Enroll(attacker);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight(attacker.Name, defender.Name);
            }, $"There is no defender with name {defender.Name} enrolled for the fights!");
        }

        [Test]
        public void Test_FightShouldSucceed_WhenWarriorsExist()
        {
            Warrior attacker = new Warrior("Snow", 66, 666);
            Warrior defender = new Warrior("Littlefinger", 33, 100);

            int attackerExpectedHp = attacker.HP - defender.Damage;
            int defenderExpectedHp = defender.HP - attacker.Damage;

            this.arena.Enroll(attacker);
            this.arena.Enroll(defender);

            this.arena.Fight(attacker.Name, defender.Name);

            int attackerActualHp = this.arena.Warriors.First(x => x.Name == attacker.Name).HP;
            int defenderActualHp = this.arena.Warriors.First(x => x.Name == defender.Name).HP;

            Assert.AreEqual(attackerExpectedHp, attackerActualHp);
            Assert.AreEqual(defenderExpectedHp, defenderActualHp);
        }

    }
}
