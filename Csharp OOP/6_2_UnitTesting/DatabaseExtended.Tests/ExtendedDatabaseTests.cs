namespace Tests
{
    using System;
    using NUnit.Framework;
    using ExtendedDatabase;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Person[] testPerson;
        private Database defaultDB;
        private Database simulatedDB;

        [SetUp]
        public void SetUp()
        {
            this.testPerson = new Person[3] { new Person(1, "Dimitrichko"), new Person(2, "Ventsi"), new Person(3, "Krasi") };
            this.defaultDB = new Database(testPerson);
        }
        public void CreateSimulatedDatabase(int count)
        {
            this.simulatedDB = new Database();

            for (int i = 0; i < count; i++)
            {
                simulatedDB.Add(new Person(i, $"Goshko + {i}"));
            }
        }


        [Test]
        public void Test_ConstructorSetDataCorrectly()
        {
            Assert.AreEqual(testPerson.Length, defaultDB.Count, "Test input length is different from the database count!");
        }

        [Test]
        public void Test_AddMethodShouldWorkCorrectly()
        {
            this.defaultDB.Add(new Person(4, "Robbie"));

            Assert.That(this.defaultDB.Count, Is.EqualTo(4));

            Assert.That(() =>
            {
                this.defaultDB.Add(new Person(4, "Tobjorn"));
            }, Throws.InvalidOperationException.With.Message.EqualTo("There is already user with this Id!"));

            Assert.That(() =>
            {
                this.defaultDB.Add(new Person(5, "Krasi"));
            }, Throws.InvalidOperationException.With.Message.EqualTo("There is already user with this username!"));

            Assert.That(() =>
            {
                this.CreateSimulatedDatabase(17);
            }, Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void Test_FindByIdShouldWorkCorrectly()
        {
            Person person = this.defaultDB.FindById(1);

            Assert.That(person.Id, Is.EqualTo(1));

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                this.defaultDB.FindById(-1);
            }, "Id should be a positive number!");

            Assert.That(() =>
            {
                this.defaultDB.FindById(55);
            }, Throws.InvalidOperationException.With.Message.EqualTo("No user is present by this ID!"));
        }

        [Test]
        public void Test_FindByUsernameShouldWorkCorrectly()
        {
            Person person = this.defaultDB.FindByUsername("Dimitrichko");

            Assert.That(person.UserName, Is.EqualTo("Dimitrichko"));

            Assert.That(() =>
            {
                this.defaultDB.FindByUsername("xxxxx");
            }, Throws.InvalidOperationException.With.Message.EqualTo("No user is present by this username!"));
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.defaultDB.FindByUsername(null);
            });
        }



        [Test]
        public void Test_RemoveMethodWorksCorrectly()
        {
            this.defaultDB.Remove();

            Assert.That(this.defaultDB.Count, Is.EqualTo(2));
            Assert.That(() =>
            {
                for (int i = 0; i < 3; i++)
                {
                    this.defaultDB.Remove();
                }
            }, Throws.InvalidOperationException);
        }
    }
}