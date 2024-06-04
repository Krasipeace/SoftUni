using System;
using System.Numerics;
using NUnit.Framework;

namespace FootballTeam.Tests
{
    public class Tests
    {
        private string playerName;
        private int playerNumber;
        private string playerPosition;
        private int scoredGoals;

        private FootballPlayer forwarder;
        private FootballPlayer midfielder;
        private FootballPlayer goalkeeper;

        [SetUp]
        public void Setup()
        {
            playerName = "Stoichkov";
            playerNumber = 8;
            playerPosition = "Forward";

            forwarder = new FootballPlayer(playerName, playerNumber, playerPosition);
            midfielder = new FootballPlayer("Balakov", 10, "Midfielder");
            goalkeeper = new FootballPlayer("Mihaylov", 1, "Goalkeeper");
        }

        [Test]
        public void TestConstructor_WorksCorrectly()
        {
            scoredGoals = 0;
            FootballPlayer player = new FootballPlayer(playerName, playerNumber, playerPosition);

            Assert.AreEqual(playerName, player.Name);
            Assert.AreEqual(playerPosition, player.Position);
            Assert.AreEqual(playerPosition, player.Position);
            Assert.AreEqual(scoredGoals, player.ScoredGoals);
        }

        [Test]
        public void TestPlayerName_ThrowsException_WhenNameIsNullOrEmpty()
        {
            playerName = null;
            Assert.Throws<ArgumentException>(() => new FootballPlayer(playerName, playerNumber, playerPosition));

            playerName = string.Empty;
            Assert.Throws<ArgumentException>(() => new FootballPlayer(playerName, playerNumber, playerPosition));
        }

        [Test]
        public void TestPlayerNumber_ThrowsException_WhenIsOutOfRange()
        {
            playerNumber = 42;
            Assert.Throws<ArgumentException>(() => new FootballPlayer(playerName, playerNumber, playerPosition));
        }

        [Test]
        public void TestPlayerPosition_ThrowsException_WhenIsInvalid()
        {
            playerPosition = "Napadatel";
            Assert.Throws<ArgumentException>(() =>
                new FootballPlayer(playerName, playerNumber, playerPosition));
        }

        [Test]
        public void TestPlayerScoringGoalsCorrectly()
        {
            var player = new FootballPlayer(playerName, playerNumber, playerPosition);

            player.Score();
            player.Score();
            player.Score();

            Assert.AreEqual(3, player.ScoredGoals);
        }

        [Test]
        public void TestPlayerNumberSetsCorrectly()
        {
            playerNumber = 8;
            var player = new FootballPlayer(playerName, playerNumber, playerPosition);
            Assert.AreEqual(8, player.PlayerNumber);
        }

        [Test]
        public void TestFootballTeam_WorksCorrectly()
        {
            string name = "Bulgaria";
            int capacity = 22;

            var team = new FootballTeam(name, capacity);

            Assert.AreEqual(name, team.Name);
            Assert.AreEqual(capacity, team.Capacity);
        }

        [Test]
        public void TestFootballTeam_ThrowsException_WhenNameIsNullOrEmpty()
        {
            string name = null;
            Assert.Throws<ArgumentException>(() => new FootballTeam(name, 22));

            name = string.Empty;
            Assert.Throws<ArgumentException>(() => new FootballTeam(name, 22));
        }

        [Test]
        public void TestFootballTeam_ThrowsException_WhenCapacityIsInvalidValue()
        {
            int capacity = 14;
            Assert.Throws<ArgumentException>(() => new FootballTeam("Bulgaria", capacity));
        }

        [Test]
        public void TestFootballTeam_AddPlayerToTeam_WorksCorrectly()
        {
            var team = new FootballTeam("Bulgaria", 22);
            string newPlayer = team.AddNewPlayer(midfielder);
            Assert.AreEqual(1, team.Players.Count);
            Assert.AreEqual($"Added player {midfielder.Name} in position {midfielder.Position} with number {midfielder.PlayerNumber}", newPlayer);
        }

        [Test]
        public void TestFootballTeam_AddPlayerToTeam_ThrowsException_WhenCapacityIsFull()
        {
            var team = new FootballTeam("Manchester United", 15);
            team.AddNewPlayer(forwarder);
            team.AddNewPlayer(midfielder);
            team.AddNewPlayer(forwarder);
            team.AddNewPlayer(midfielder);
            team.AddNewPlayer(forwarder);
            team.AddNewPlayer(midfielder);
            team.AddNewPlayer(forwarder);
            team.AddNewPlayer(midfielder);
            team.AddNewPlayer(forwarder);
            team.AddNewPlayer(midfielder);
            team.AddNewPlayer(forwarder);
            team.AddNewPlayer(midfielder);
            team.AddNewPlayer(forwarder);
            team.AddNewPlayer(midfielder);
            team.AddNewPlayer(midfielder);

            string result = team.AddNewPlayer(goalkeeper);

            Assert.AreEqual(15, team.Players.Count);
            Assert.AreEqual("No more positions available!", result);
        }

        [Test]
        public void TestPickPlayer_WorksCorrectly()
        {
            var team = new FootballTeam("Bulgaria", 22);
            team.AddNewPlayer(forwarder);
            team.AddNewPlayer(midfielder);

            var pickedPlayer = team.PickPlayer(forwarder.Name);

            Assert.AreEqual(forwarder, pickedPlayer);
        }

        [Test]
        public void TestPlayerScore_WorksCorrectly()
        {
            var team = new FootballTeam("Bulgaria", 22);
            team.AddNewPlayer(forwarder);
            team.AddNewPlayer(midfielder);

            string result = team.PlayerScore(forwarder.PlayerNumber);

            Assert.AreEqual(1, forwarder.ScoredGoals);
            Assert.AreEqual($"{forwarder.Name} scored and now has {forwarder.ScoredGoals} for this season!", result);
        }
    }
}