namespace CollectionOfPeople.SlowCollection
{
    using System.Linq;
    using NUnit.Framework;
    using CollectionOfPeople;

    [TestFixture]
    public class CorrectnessTests
    {
        private IPeopleCollection people;

        [SetUp]
        public void InitializeCollection()
        {
            this.people = new PeopleCollectionSlow();
        }

        [Test]
        public void Add_ShouldWorkCorrectly()
        {
            var isAdded = people.Add("pesho@gmail.com", "Peter", 18, "Sofia");

            // Assert
            Assert.IsTrue(isAdded);
            Assert.AreEqual(1, people.Count);
        }

        [Test]
        public void Add_DuplicatedEmail_ShouldWorkCorrectly()
        {
            var isAddedFirst = people.Add("pesho@gmail.com", "Peter", 18, "Sofia");
            var isAddedSecond = people.Add("pesho@gmail.com", "Maria", 24, "Plovdiv");

            // Assert
            Assert.IsTrue(isAddedFirst);
            Assert.IsFalse(isAddedSecond);
            Assert.AreEqual(1, people.Count);
        }

        [Test]
        public void Find_ExistingPerson_ShouldReturnPerson()
        {
            people.Add("pesho@gmail.com", "Peter", 28, "Plovdiv");

            // Act
            var person = people.Find("pesho@gmail.com");

            // Assert
            Assert.IsNotNull(person);
        }

        [Test]
        public void Find_NonExistingPerson_ShouldReturnNothing()
        {
            // Act
            var person = people.Find("pesho@gmail.com");

            // Assert
            Assert.IsNull(person);
        }

        [Test]
        public void Delete_ShouldWorkCorrectly()
        {
            people.Add("pesho@gmail.com", "Peter", 28, "Plovdiv");

            // Act
            var isDeletedExisting = people.Delete("pesho@gmail.com");
            var isDeletedNonExisting = people.Delete("pesho@gmail.com");

            // Assert
            Assert.IsTrue(isDeletedExisting);
            Assert.IsFalse(isDeletedNonExisting);
            Assert.AreEqual(0, people.Count);
        }

        [Test]
        public void FindPeople_ByEmailDomain_ShouldReturnMatchingPeople()
        {
            people.Add("pesho@gmail.com", "Pesho", 28, "Plovdiv");
            people.Add("kiro@yahoo.co.uk", "Kiril", 22, "Sofia");
            people.Add("mary@gmail.com", "Maria", 21, "Plovdiv");
            people.Add("ani@gmail.com", "Anna", 19, "Bourgas");

            // Act
            var peopleGmail = people.FindPeople("gmail.com");
            var peopleYahoo = people.FindPeople("yahoo.co.uk");
            var peopleHoo = people.FindPeople("hoo.co.uk");

            // Assert
            CollectionAssert.AreEqual(
                new string[] { "ani@gmail.com", "mary@gmail.com", "pesho@gmail.com" },
                peopleGmail.Select(p => p.Email).ToList());

            CollectionAssert.AreEqual(
                new string[] { "kiro@yahoo.co.uk" },
                peopleYahoo.Select(p => p.Email).ToList());

            CollectionAssert.AreEqual(
                new string[] { },
                peopleHoo.Select(p => p.Email).ToList());
        }

        [Test]
        public void FindPeople_ByNameAndTown_ShouldReturnMatchingPeople()
        {
            people.Add("pesho@gmail.com", "Pesho", 28, "Plovdiv");
            people.Add("kiro@yahoo.co.uk", "Kiril", 22, "Sofia");
            people.Add("pepi@gmail.com", "Pesho", 21, "Plovdiv");
            people.Add("ani@gmail.com", "Anna", 19, "Bourgas");
            people.Add("pepi2@yahoo.fr", "Pesho", 21, "Plovdiv");

            // Act
            var peoplePeshoPlovdiv = people.FindPeople("Pesho", "Plovdiv");
            var peopleLowercase = people.FindPeople("pesho", "plovdiv");
            var peoplePeshoNoTown = people.FindPeople("Pesho", null);
            var peopleAnnaBourgas = people.FindPeople("Anna", "Bourgas");

            // Assert
            CollectionAssert.AreEqual(
                new string[] { "pepi@gmail.com", "pepi2@yahoo.fr", "pesho@gmail.com" },
                peoplePeshoPlovdiv.Select(p => p.Email).ToList());

            CollectionAssert.AreEqual(
                new string[] { },
                peopleLowercase.Select(p => p.Email).ToList());

            CollectionAssert.AreEqual(
                new string[] { },
                peoplePeshoNoTown.Select(p => p.Email).ToList());

            CollectionAssert.AreEqual(
                new string[] { "ani@gmail.com" },
                peopleAnnaBourgas.Select(p => p.Email).ToList());
        }

        [Test]
        public void FindPeople_ByAgeRange_ShouldReturnMatchingPeople()
        {
            people.Add("pesho@gmail.com", "Pesho", 28, "Plovdiv");
            people.Add("kiro@yahoo.co.uk", "Kiril", 22, "Sofia");
            people.Add("pepi@gmail.com", "Pesho", 21, "Plovdiv");
            people.Add("ani@gmail.com", "Anna", 19, "Bourgas");
            people.Add("pepi2@yahoo.fr", "Pesho", 21, "Plovdiv");
            people.Add("asen@gmail.com", "Asen", 21, "Rousse");

            // Act
            var peopleAgedFrom21to22 = people.FindPeople(21, 22);
            var peopleAgedFrom10to11 = people.FindPeople(10, 11);
            var peopleAged21 = people.FindPeople(21, 21);
            var peopleAged19 = people.FindPeople(19, 19);
            var peopleAgedFrom0to1000 = people.FindPeople(0, 1000);

            // Assert
            CollectionAssert.AreEqual(
                new string[] { "asen@gmail.com", "pepi@gmail.com", "pepi2@yahoo.fr", "kiro@yahoo.co.uk" },
                peopleAgedFrom21to22.Select(p => p.Email).ToList());

            CollectionAssert.AreEqual(
                new string[] { },
                peopleAgedFrom10to11.Select(p => p.Email).ToList());

            CollectionAssert.AreEqual(
                new string[] { "asen@gmail.com", "pepi@gmail.com", "pepi2@yahoo.fr" },
                peopleAged21.Select(p => p.Email).ToList());

            CollectionAssert.AreEqual(
                new string[] { "ani@gmail.com" },
                peopleAged19.Select(p => p.Email).ToList());

            CollectionAssert.AreEqual(
                new string[] { "ani@gmail.com", "asen@gmail.com", "pepi@gmail.com", "pepi2@yahoo.fr", "kiro@yahoo.co.uk", "pesho@gmail.com" },
                peopleAgedFrom0to1000.Select(p => p.Email).ToList());
        }

        [Test]
        public void FindPeople_ByAgeRangeAndTown_ShouldReturnMatchingPeople()
        {
            people.Add("pesho@gmail.com", "Pesho", 28, "Plovdiv");
            people.Add("kirosofia@yahoo.co.uk", "Kiril", 22, "Sofia");
            people.Add("kiro@yahoo.co.uk", "Kiril", 22, "Plovdiv");
            people.Add("pepi@gmail.com", "Pesho", 21, "Plovdiv");
            people.Add("ani@gmail.com", "Anna", 19, "Bourgas");
            people.Add("ani17@gmail.com", "Anna", 17, "Bourgas");
            people.Add("pepi2@yahoo.fr", "Pesho", 21, "Plovdiv");
            people.Add("asen.rousse@gmail.com", "Asen", 21, "Rousse");
            people.Add("asen@gmail.com", "Asen", 21, "Plovdiv");

            // Act
            var peopleAgedFrom21to22Plovdiv = people.FindPeople(21, 22, "Plovdiv");
            var peopleAgedFrom10to11Sofia = people.FindPeople(10, 11, "Sofia");
            var peopleAged21Plovdiv = people.FindPeople(21, 21, "Plovdiv");
            var peopleAged19Bourgas = people.FindPeople(19, 19, "Bourgas");
            var peopleAgedFrom0to1000Plovdiv = people.FindPeople(0, 1000, "Plovdiv");
            var peopleAgedFrom0to1000NewYork = people.FindPeople(0, 1000, "New York");

            // Assert
            CollectionAssert.AreEqual(
                new string[] { "asen@gmail.com", "pepi@gmail.com", "pepi2@yahoo.fr", "kiro@yahoo.co.uk" },
                peopleAgedFrom21to22Plovdiv.Select(p => p.Email).ToList());

            CollectionAssert.AreEqual(
                new string[] { },
                peopleAgedFrom10to11Sofia.Select(p => p.Email).ToList());

            CollectionAssert.AreEqual(
                new string[] { "asen@gmail.com", "pepi@gmail.com", "pepi2@yahoo.fr" },
                peopleAged21Plovdiv.Select(p => p.Email).ToList());

            CollectionAssert.AreEqual(
                new string[] { "ani@gmail.com" },
                peopleAged19Bourgas.Select(p => p.Email).ToList());

            CollectionAssert.AreEqual(
                new string[] { "asen@gmail.com", "pepi@gmail.com", "pepi2@yahoo.fr", "kiro@yahoo.co.uk", "pesho@gmail.com" },
                peopleAgedFrom0to1000Plovdiv.Select(p => p.Email).ToList());

            CollectionAssert.AreEqual(
                new string[] { },
                peopleAgedFrom0to1000NewYork.Select(p => p.Email).ToList());
        }

        [Test]
        public void MultipleOperations_ShouldWorkCorrectly()
        {
            var isAdded = people.Add("pesho@gmail.com", "Pesho", 28, "Plovdiv");
            Assert.IsTrue(isAdded);
            Assert.AreEqual(1, people.Count);

            isAdded = people.Add("pesho@gmail.com", "Pesho2", 222, "Plovdiv222");
            Assert.IsFalse(isAdded);
            Assert.AreEqual(1, people.Count);

            people.Add("kiro@yahoo.co.uk", "Kiril", 22, "Plovdiv");
            Assert.AreEqual(2, people.Count);

            people.Add("asen@gmail.com", "Asen", 22, "Sofia");
            Assert.AreEqual(3, people.Count);

            Person person = people.Find("non-existing person");
            Assert.IsNull(person);

            person = people.Find("pesho@gmail.com");
            Assert.IsNotNull(person);
            Assert.AreEqual("pesho@gmail.com", person.Email);
            Assert.AreEqual("Pesho", person.Name);
            Assert.AreEqual(28, person.Age);
            Assert.AreEqual("Plovdiv", person.Town);

            var peopleGmail = people.FindPeople("gmail.com");
            CollectionAssert.AreEqual(
                new string[] { "asen@gmail.com", "pesho@gmail.com" },
                peopleGmail.Select(p => p.Email).ToList());

            var peoplePeshoPlovdiv = people.FindPeople("Pesho", "Plovdiv");
            CollectionAssert.AreEqual(
                new string[] { "pesho@gmail.com" },
                peoplePeshoPlovdiv.Select(p => p.Email).ToList());

            var peoplePeshoSofia = people.FindPeople("Pesho", "Sofia");
            Assert.AreEqual(0, peoplePeshoSofia.Count());

            var peopleKiroPlovdiv = people.FindPeople("Kiro", "Plovdiv");
            Assert.AreEqual(0, peopleKiroPlovdiv.Count());

            var peopleAge22To28 = people.FindPeople(22, 28);
            CollectionAssert.AreEqual(
                new string[] { "asen@gmail.com", "kiro@yahoo.co.uk", "pesho@gmail.com" },
                peopleAge22To28.Select(p => p.Email).ToList());

            var peopleAge22To28Plovdiv = people.FindPeople(22, 28, "Plovdiv");
            CollectionAssert.AreEqual(
                new string[] { "kiro@yahoo.co.uk", "pesho@gmail.com" },
                peopleAge22To28Plovdiv.Select(p => p.Email).ToList());

            var isDeleted = people.Delete("pesho@gmail.com");
            Assert.IsTrue(isDeleted);

            isDeleted = people.Delete("pesho@gmail.com");
            Assert.IsFalse(isDeleted);

            person = people.Find("pesho@gmail.com");
            Assert.IsNull(person);

            peopleGmail = people.FindPeople("gmail.com");
            CollectionAssert.AreEqual(
                new string[] { "asen@gmail.com" },
                peopleGmail.Select(p => p.Email).ToList());

            peoplePeshoPlovdiv = people.FindPeople("Pesho", "Plovdiv");
            CollectionAssert.AreEqual(
                new string[] { },
                peoplePeshoPlovdiv.Select(p => p.Email).ToList());

            peoplePeshoSofia = people.FindPeople("Pesho", "Sofia");
            Assert.AreEqual(0, peoplePeshoSofia.Count());

            peopleKiroPlovdiv = people.FindPeople("Kiro", "Plovdiv");
            Assert.AreEqual(0, peopleKiroPlovdiv.Count());

            peopleAge22To28 = people.FindPeople(22, 28);
            CollectionAssert.AreEqual(
                new string[] { "asen@gmail.com", "kiro@yahoo.co.uk" },
                peopleAge22To28.Select(p => p.Email).ToList());

            peopleAge22To28Plovdiv = people.FindPeople(22, 28, "Plovdiv");
            CollectionAssert.AreEqual(
                new string[] { "kiro@yahoo.co.uk" },
                peopleAge22To28Plovdiv.Select(p => p.Email).ToList());
        }
    }
}