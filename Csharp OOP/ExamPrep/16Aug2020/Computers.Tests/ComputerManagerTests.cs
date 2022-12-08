using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Computers.Tests
{
    public class Tests
    {
        private Computer computer;
        private Computer computer2;
        private ComputerManager computerManager;
        [SetUp]
        public void Setup()
        {
            computer = new Computer("IBM", "Hell", 666);
            computer2 = new Computer("Dell", "Vostro", 999);
            computerManager = new ComputerManager();
        }

        [Test]
        public void CreateComputerShouldWorkAsExpected()
        {
            Computer computer = new Computer("IBM", "Hell", 666);

            Assert.AreEqual("IBM", computer.Manufacturer);
            Assert.AreEqual("Hell", computer.Model);
            Assert.AreEqual(666, computer.Price);
        }

        [Test]
        public void AddComputer_ShouldIncreaseCount_ShouldWorkAsExpected()
        {
            Assert.AreEqual(0, computerManager.Count);
            computerManager.AddComputer(computer);
            Assert.AreEqual(1, computerManager.Count);
        }

        [Test]
        public void AddComputerWithExistingModelAndManufacturer_ShouldThrowException()
        {
            computerManager.AddComputer(computer);
            Assert.Throws<ArgumentException>(() =>
            {
                computerManager.AddComputer(computer);
            }, "This computer already exists.");
        }

        [Test]
        public void AddComputerWithNullValue_ShouldThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                computerManager.AddComputer(null);
            }, "Can not be null!");
        }

        [Test]
        public void TestRemove_ShouldWorkAsExpected()
        {
            computerManager.AddComputer(computer);
            Assert.IsTrue(computerManager.Computers.Contains(computer));
            Assert.AreEqual(1, computerManager.Count);

            computerManager.RemoveComputer(computer.Manufacturer, computer.Model);

            Assert.AreEqual(0, computerManager.Count);
            Assert.IsFalse(computerManager.Computers.Contains(computer));
        }

        [Test]
        public void GetComputer_ShouldWorkAsExpected()
        {
            computerManager.AddComputer(computer);
            Computer getComputer = computerManager.GetComputer("IBM", "Hell");
            Assert.AreEqual(computer, getComputer);
        }

        [TestCase(null, null)]
        [TestCase("IBM", null)]
        [TestCase(null, "Hell")]
        public void GetComputer_ShouldThrowExceptionWhenValueIsNull(string manufacturer, string model)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                computerManager.GetComputer(manufacturer, model);
            }, "Can not be null!");
        }

        [TestCase("Dell", "Hell")]
        [TestCase("IBM", "Vostro")]
        public void GetComputer_WhichDoesNotExistInTheCollection_ShouldThrowException(string manufacturer, string model)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                computerManager.GetComputer(manufacturer, model);
            }, "There is no computer with this manufacturer and model.");
        }

        [Test]
        public void GetComputers_ShouldWorkAsExpected()
        {
            computerManager.AddComputer(computer);
            computerManager.AddComputer(computer2);

            ICollection<Computer> computers = computerManager.GetComputersByManufacturer("IBM");
            Assert.AreEqual(1, computers.Count);
        }

        [Test]
        public void GetComputers_WithNullValue_ShouldThrowException()
        {
            computerManager.AddComputer(computer);
            Assert.Throws<ArgumentNullException>(() =>
            {
                computerManager.GetComputersByManufacturer(null);
            }, "Can not be null!");
        }
    }
}