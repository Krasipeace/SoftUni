namespace FightingArena.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class WarriorTests
    {

        [Test]
        public void Test_ConstructorShouldInitializeWarriorName()
        {
            string expectedName = "Dimitrichko";
            Warrior warrior = new Warrior(expectedName, 100, 100);

            string actualname = warrior.Name;
            Assert.AreEqual(expectedName, actualname);
        }

        [Test]
        public void Test_ConstructorShouldInitializeWarriorDamage()
        {
            int expectedDamage = 100;
            Warrior warrior = new Warrior("Dimitrichko", expectedDamage, 100);

            int actualDamage = warrior.Damage;
            Assert.AreEqual(expectedDamage, actualDamage);
        }

        [Test]
        public void Test_ConstructorShouldInitializeWarriorHP()
        {
            int expectedHp = 100;
            Warrior warrior = new Warrior("Dimitrichko", 100, expectedHp);

            int actualHp = warrior.HP;
            Assert.AreEqual(expectedHp, actualHp);
        }

        [TestCase("Dimitrichko")]
        [TestCase("W")]
        [TestCase("Rhoshandiatellyneshiaunneveshenk Koyaanisquatsiuth Williams")]
        public void Test_NameSetterShouldSetValue_WithValidName(string name)
        {
            Warrior warrior = new Warrior(name, 50, 100);

            string expectedName = name;
            string actualName = warrior.Name;

            Assert.AreEqual(expectedName, actualName);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("    ")]
        public void Test_NameSetterShouldThrowException_WithEmptyOrWhiteSpaceName(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, 50, 100);
            }, "Name should not be empty, null or whitespace!");
        }

        [TestCase(69)]
        [TestCase(123456789)]
        [TestCase(1)]
        public void Test_DamageSetterShouldSetValue_WithValidDamage(int damage)
        {
            Warrior warrior = new Warrior("Dimitrchko", damage, 100);

            int expectedDamage = damage;
            int actualDamage = warrior.Damage;

            Assert.AreEqual(expectedDamage, actualDamage);
        }

        [TestCase(-69)]
        [TestCase(-1)]
        [TestCase(0)]
        public void Test_DamageSetterShouldThrowException_WithZeroOrNegativeDamage(int damage)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Dimitrichko", damage, 100);
            }, "Damage value should be positive value!");
        }

        [TestCase(100)]
        [TestCase(69)]
        [TestCase(1)]
        [TestCase(0)]
        public void Test_HealthSetterSetValue_WithValidHealthPoints(int health)
        {
            Warrior warrior = new Warrior("Dimitrchiko", 17, health);
            int expectedHealth = health;
            int actualHealth = warrior.HP;

            Assert.AreEqual(expectedHealth, actualHealth);
        }

        [TestCase(-69)]
        [TestCase(-1)]
        public void Test_HPSetterShouldThrowExceptionWithNegativeHP(int hp)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Dimitrchiko", 50, hp);
            }, "HP should not be negative!");
        }

        [Test]
        public void Test_SuccessAttackingWarriorNoKill()
        {
            int attackerDamage = 33;
            int attackerHp = 100;
            int defenderDamage = 13;
            int defenderHp = 100;

            Warrior attacker = new Warrior("Kaiser", attackerDamage, attackerHp);
            Warrior defender = new Warrior("Mokgul", defenderDamage, defenderHp);

            attacker.Attack(defender);

            int atkerExpectedHp = attackerHp - defenderDamage;
            int defenderExpectedHp = defenderHp - attackerDamage;

            int attkerActualHp = attacker.HP;
            int defenderActualHp = defender.HP;

            Assert.AreEqual(atkerExpectedHp, attkerActualHp);
            Assert.AreEqual(defenderExpectedHp, defenderActualHp);
        }

        [TestCase(33)]
        [TestCase(66)]
        public void Test_SuccessAttackingWarriorWithKill(int defenderHp)
        {
            int attackerDamage = 66;
            int attackerHealth = 100;
            int defenderDamage = 33;

            Warrior attacker = new Warrior("Kaiser", attackerDamage, attackerHealth);
            Warrior defender = new Warrior("Mokgul", defenderDamage, defenderHp);

            attacker.Attack(defender);

            int attkerExpectedHp = attackerHealth - defenderDamage;
            int defenderExpectedHp = 0;

            int attkerActualHp = attacker.HP;
            int defenderActualHp = defender.HP;

            Assert.AreEqual(attkerExpectedHp, attkerActualHp);
            Assert.AreEqual(defenderExpectedHp, defenderActualHp);
        }

        [TestCase(0)]
        [TestCase(15)]
        [TestCase(30)]
        public void Test_AttackingShouldThrowException_WhenAttackerHPIsBelowMin(int attackerHp)
        {
            int attackerDamage = 50;
            int defenderDamage = 30;
            int defenderHp = 100;

            Warrior attacker = new Warrior("Kaiser", attackerDamage, attackerHp);
            Warrior defender = new Warrior("Mokgul", defenderDamage, defenderHp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            }, "Your HP is too low in order to attack other warriors!");
        }

        [TestCase(0)]
        [TestCase(15)]
        [TestCase(30)]
        public void Test_AttackingShouldThrowExceptionWhenDefenderHPIsBelowMin(int defenderHp)
        {
            int attackerDamage = 50;
            int attackerHp = 100;
            int defenderDamage = 30;

            Warrior attacker = new Warrior("Kaiser", attackerDamage, attackerHp);
            Warrior defender = new Warrior("Mokgul", defenderDamage, defenderHp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            }, "Enemy HP must be greater than 30 in order to attack him!");
        }

        [TestCase(50, 77)]
        [TestCase(44, 45)]
        public void Test_AttackingShouldThrowException_WhenAttackerHPIsBelowDefenderDamage(int attackerHp, int defenderDamage)
        {
            int attackerDamage = 50;
            int defenderHp = 100;

            Warrior attacker = new Warrior("Kaiser", attackerDamage, attackerHp);
            Warrior defender = new Warrior("Mokgul", defenderDamage, defenderHp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            }, "You are trying to attack too strong enemy");
        }

    }
}