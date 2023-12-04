using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Exam.Discord.Tests
{
    public class DiscordTests
    {
        private IDiscord discord;

        private Message GetRandomMessage()
        {
            Random random = new Random();

            return new Message(
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                random.Next(1, 1_000_000_000),
                Guid.NewGuid().ToString());
        }

        [SetUp]
        public void Setup()
        {
            this.discord = new Discord();
        }

        // Correctness Tests

        [Test]
        [Category("Correctness")]
        public void TestSendMessage_ShouldSuccessfullySendMessage()
        {
            this.discord.SendMessage(this.GetRandomMessage());
            this.discord.SendMessage(this.GetRandomMessage());

            Assert.AreEqual(2, this.discord.Count);
        }

        [Test]
        [Category("Correctness")]
        public void TestContains_WithExistentMessage_ShouldReturnTrue()
        {
            Message randomMessage = this.GetRandomMessage();

            this.discord.SendMessage(randomMessage);

            Assert.IsTrue(this.discord.Contains(randomMessage));
        }

        [Test]
        [Category("Correctness")]
        public void TestCount_With5Messages_ShouldReturn5()
        {
            this.discord.SendMessage(this.GetRandomMessage());
            this.discord.SendMessage(this.GetRandomMessage());
            this.discord.SendMessage(this.GetRandomMessage());
            this.discord.SendMessage(this.GetRandomMessage());
            this.discord.SendMessage(this.GetRandomMessage());

            Assert.AreEqual(5, this.discord.Count);
        }

        [Test]
        [Category("Correctness")]
        public void TestCount_WithEmpty_ShouldReturnZero()
        {
            Assert.AreEqual(0, this.discord.Count);
        }

        [Test]
        [Category("Correctness")]
        public void TestGetMessage_WithCorrectMessage_ShouldReturnMessage()
        {
            Message message = this.GetRandomMessage();

            this.discord.SendMessage(message);

            Message received = this.discord.GetMessage(message.Id);

            Assert.AreEqual(message, received);
        }

        [Test]
        [Category("Correctness")]
        public void TestGetMessage_WithNonexistentMessage_ShouldThrowException()
        {
            Message message = this.GetRandomMessage();

            this.discord.SendMessage(message);

            Assert.Throws<ArgumentException>(() => this.discord.GetMessage(this.GetRandomMessage().Id));
        }

        [Test]
        [Category("Correctness")]
        public void TestGetMessagesOrderedByMultiCriteria_WithCorrectData_ShouldReturnCorrectResults()
        {
            Message Message = new Message("asd", "bsd", 4000, "test");
            Message Message2 = new Message("dsd", "esd", 5000, "test");
            Message Message3 = new Message("hsd", "isd", 6000, "test2");
            Message Message4 = new Message("ksd", "test", 4000, "test2");
            Message Message5 = new Message("nsd", "osd", 8000, "test2");

            this.discord.SendMessage(Message);
            this.discord.SendMessage(Message2);
            this.discord.SendMessage(Message3);
            this.discord.SendMessage(Message4);
            this.discord.SendMessage(Message5);

            this.discord.ReactToMessage(Message.Id, "laugh");
            this.discord.ReactToMessage(Message.Id, "laugh");

            this.discord.ReactToMessage(Message2.Id, "thumbsup");
            this.discord.ReactToMessage(Message2.Id, "lol");
            this.discord.ReactToMessage(Message2.Id, "lol");

            this.discord.ReactToMessage(Message3.Id, "lol");
            this.discord.ReactToMessage(Message3.Id, "lol");
            this.discord.ReactToMessage(Message3.Id, "lol");

            this.discord.ReactToMessage(Message4.Id, "laugh");
            this.discord.ReactToMessage(Message4.Id, "laugh");

            List<Message> list = this.discord.GetAllMessagesOrderedByCountOfReactionsThenByTimestampThenByLengthOfContent().ToList();

            Assert.AreEqual(5, list.Count);
            Assert.AreEqual(Message2, list[0]);
            Assert.AreEqual(Message3, list[1]);
            Assert.AreEqual(Message, list[2]);
            Assert.AreEqual(Message4, list[3]);
            Assert.AreEqual(Message5, list[4]);
        }

        // Performance Tests

        [Test]
        [Category("Performance")]
        public void TestSendMessage_With100000Results_ShouldPassQuickly()
        {
            int count = 100000;

            Stopwatch stopwatch = new Stopwatch(); stopwatch.Start();

            for (int i = 0; i < count; i++)
            {
                this.discord.SendMessage(new Message(i + "", "Title" + i, i * 100, "Channel" + i));
            }

            stopwatch.Stop();

            Assert.IsTrue(stopwatch.ElapsedMilliseconds < 150);
        }
    }
}