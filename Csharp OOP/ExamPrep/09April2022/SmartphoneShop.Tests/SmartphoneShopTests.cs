using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [Test]
        public void Test_ShopCanBeCreatedCorrectly()
        {
            Shop shop = new Shop(100);

            Assert.AreEqual(100, shop.Capacity);
        }

        [Test]
        public void Test_ShopNegativeCapacity_ShouldThrowExceptionMessage()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Shop shop = new Shop(-100);
            }, "Invalid capacity.");

        }

        [Test]
        public void Test_SmartphoneCanBeCreatedCorrectly()
        {
            Smartphone smartphone = new Smartphone("Asus", 350);
            Assert.AreEqual("Asus", smartphone.ModelName);
            Assert.AreEqual(350, smartphone.MaximumBatteryCharge);
        }

        [Test]
        public void Test_CountWorkCorrectly()
        {
            Shop testedShop = new Shop(100);
            Smartphone smartphone = new Smartphone("Asus", 350);
            testedShop.Add(smartphone);

            Assert.AreEqual(testedShop.Count, 1);
        }

        [Test]
        public void Test_SmartphoneModelAlreadyExist_ShouldThrowExceptionMessage()
        {
            Shop testedShop = new Shop(100);
            Smartphone expected = new Smartphone("Asus", 350);
            testedShop.Add(expected);
            Smartphone actual = new Smartphone("Asus", 100);

            Assert.Throws<InvalidOperationException>(() =>
            {
                testedShop.Add(actual);
            }, $"The phone model {actual.ModelName} already exist.");
        }

        [Test]
        public void Test_AddSmartphoneIntoShopWithFullCapacity_ShouldThrowExceptionMessage()
        {
            Shop testedShop = new Shop(0);
            Smartphone smartphone = new Smartphone("Asus", 350);
            Assert.Throws<InvalidOperationException>(() =>
            {
                testedShop.Add(smartphone);
            }, "The shop is full.");
        }

        [Test]
        public void Test_RemoveSmartphoneWorksCorrectly()
        {
            Shop testedShop = new Shop(100);
            Smartphone smartphone = new Smartphone("Asus", 350);
            testedShop.Add(smartphone);
            testedShop.Remove(smartphone.ModelName);

            Assert.AreEqual(testedShop.Count, 0);
        }

        [Test]
        public void Test_RemoveSmartphoneWhichDoesNotExistInTheShop_ShouldThrowExceptionMessage()
        {
            Shop testedShop = new Shop(100);
            Smartphone smartphone = new Smartphone("Asus", 350);
            testedShop.Add(smartphone);
            Smartphone smartphone2 = new Smartphone("Nokia", 100);

            Assert.Throws<InvalidOperationException>(() =>
            {
                testedShop.Remove(smartphone2.ModelName);
            }, $"The phone model {smartphone2.ModelName} doesn't exist.");
        }

        [Test]
        public void Test_TestPhoneShouldSpendBatteryOnUsage()
        {
            Shop testedShop = new Shop(100);
            Smartphone smartphone = new Smartphone("Asus", 350);
            testedShop.Add(smartphone);
            smartphone.CurrentBateryCharge = 350;
            testedShop.TestPhone(smartphone.ModelName, 50);

            Assert.AreEqual(smartphone.CurrentBateryCharge, 300); //350-50=300
        }

        [Test]
        public void Test_TestPhoneWhichPhoneModelDoesNotExist_ShouldThrowExceptionMessage()
        {
            Shop testedShop = new Shop(100);
            Smartphone smartphone = new Smartphone("Asus", 350);
            testedShop.Add(smartphone);
            Smartphone smartphone2 = new Smartphone("Nokia", 100);

            Assert.Throws<InvalidOperationException>(() =>
            {
                testedShop.TestPhone(smartphone2.ModelName, 50);
            }, $"The phone model {smartphone2.ModelName} doesn't exist.");
        }

        [Test]
        public void Test_TestPhoneLowBattery_ShouldThrowExceptionMessage()
        {
            Shop testedShop = new Shop(100);
            Smartphone smartphone = new Smartphone("Asus", 350);
            testedShop.Add(smartphone);
            smartphone.CurrentBateryCharge = 100;
            Assert.Throws<InvalidOperationException>(() =>
            {
                testedShop.TestPhone(smartphone.ModelName, 150);
            }, $"The phone model {smartphone.ModelName} is low on batery.");
        }

        [Test]
        public void Test_ChargePhoneBatteryShouldWorkCorrectly()
        {
            Shop testedShop = new Shop(100);
            Smartphone smartphone = new Smartphone("Asus", 350);
            testedShop.Add(smartphone);
            smartphone.CurrentBateryCharge = 100;
            testedShop.ChargePhone(smartphone.ModelName);

            Assert.AreEqual(smartphone.CurrentBateryCharge, smartphone.MaximumBatteryCharge);
        }

        [Test]
        public void Test_ChargePhoneBatteryWhichPhoneModelDoesNotExist_ShouldThrowExceptionMessage()
        {
            Shop testedShop = new Shop(100);
            Smartphone smartphone = new Smartphone("Asus", 350);
            testedShop.Add(smartphone);
            Smartphone smartphone2 = new Smartphone("Nokia", 100);

            Assert.Throws<InvalidOperationException>(() =>
            {
                testedShop.ChargePhone(smartphone2.ModelName);
            }, $"The phone model {smartphone2.ModelName} doesn't exist.");
        }

    }
}