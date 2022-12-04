namespace Robots.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Xml.Linq;

    public class RobotsTests
    {
        private Robot defaultRobot;
        private RobotManager defaultRobotManager;    

        [SetUp]
        public void Setup()
        {
            defaultRobot = new Robot("R2D2", 100);
            defaultRobotManager = new RobotManager(10);
        }

        [Test]
        public void CreateRobotWorkAsExpected()
        {
            Assert.AreEqual("R2D2", defaultRobot.Name);
            Assert.AreEqual(100, defaultRobot.MaximumBattery);
        }

        [Test]
        public void RobotManagerWithNegativeCapacity_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                RobotManager robotManager = new RobotManager(-11);
            }, "Invalid capacity!"); 
        }

        [Test]
        public void AddRobotWithDuplicateName_ShouldThrowException()
        {
            defaultRobotManager.Add(defaultRobot);
            
            Assert.Throws<InvalidOperationException>(() =>
            {
                defaultRobotManager.Add(new Robot("R2D2", 77));
            }, $"There is already a robot with name {defaultRobot.Name}!");
        }


        [Test]
        public void AddRobotAfterCapacityIsReached_ShouldThrowExceptiion()
        {
            RobotManager robotManager = new RobotManager(2);
            robotManager.Add(new Robot("Excalibur", 250));
            robotManager.Add(new Robot("Limbo", 350));
            Assert.Throws<InvalidOperationException>(() =>
            {
                 robotManager.Add(defaultRobot);
            }, "Not enough capacity!");
        }

        [Test]
        public void CountingRobotsWorkAsExpected()
        {
            defaultRobotManager.Add(defaultRobot);
            Assert.AreEqual(1, defaultRobotManager.Count);
        }

        [Test]
        public void RemoveRobotWorkAsExpected()
        {
            defaultRobotManager.Add(defaultRobot);
            defaultRobotManager.Remove("R2D2");
            Assert.AreEqual(0, defaultRobotManager.Count);
        }

        [Test]
        public void RemoveInexistentRobotFromTheList_ShouldThrowException()
        {
            defaultRobotManager.Add(defaultRobot);
            Assert.Throws<InvalidOperationException>(() =>
            {
                defaultRobotManager.Remove("B9");
            }, $"Robot with the name B9 doesn't exist!");
        }

        [Test]
        public void RobotWorkShouldWorkAsExpected()
        {
            defaultRobotManager.Add(defaultRobot);
            defaultRobotManager.Work(defaultRobot.Name, "Opening Doors", 10);
            Assert.AreEqual(90, defaultRobot.Battery); //100-10=90
        }

        [Test]
        public void RobotWorkTaskWhenNotEnoughBattery_ShouldThrowException()
        {
            defaultRobotManager.Add(defaultRobot);
            Assert.Throws<InvalidOperationException>(() =>
            {
                defaultRobotManager.Work(defaultRobot.Name, "Kill Darth Vader", 666);
            }, $"{defaultRobot.Name} doesn't have enough battery!");
        }

        [Test]
        public void RobotCharge_ShouldWorkAsExpected()
        {
            defaultRobotManager.Add(defaultRobot);
            defaultRobotManager.Work(defaultRobot.Name, "Buzzing Tripio", 50);
            defaultRobotManager.Charge(defaultRobot.Name);
            Assert.AreEqual(100, defaultRobot.Battery);           
        }
            
        [Test]
        public void RobotChargeWhenRobotIsNotExisting_ShouldThrowException()
        {
            defaultRobotManager.Add(defaultRobot);
            Assert.Throws<InvalidOperationException>(() =>
            {
                defaultRobotManager.Charge("B8");
            }, $"Robot with the name B8 doesn't exist!");
        }
    }
}
