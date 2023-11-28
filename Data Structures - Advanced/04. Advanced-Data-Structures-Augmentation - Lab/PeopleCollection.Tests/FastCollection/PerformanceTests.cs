namespace CollectionOfPeople.FastCollection
{
    using System.Linq;
    using NUnit.Framework;
    using CollectionOfPeople;

    [TestFixture]
    public class PerformanceTests
    {
        private IPeopleCollection peopleCollection;

        [SetUp]
        public void InitializeCollection()
        {
            this.peopleCollection = new PeopleCollection();

            for (int i = 0; i < 5000; i++)
            {
                this.peopleCollection.Add(
                    email: "pesho" + i + "@gmail" + (i % 100) + ".com",
                    name: "Pesho" + (i % 100),
                    age: i % 100,
                    town: "Sofia" + (i % 100));
            }
        }

        [Test]
        [Timeout(150)]
        public void Add_ManyElements()
        {
            Assert.AreEqual(5000, this.peopleCollection.Count);
        }

        [Test]
        [Timeout(200)]
        public void Find_ManyElements()
        {
            for (int i = 0; i < 100000; i++)
            {
                var existingPerson = this.peopleCollection.Find("pesho1@gmail1.com");
                Assert.IsNotNull(existingPerson);
                var nonExistingPerson = this.peopleCollection.Find("non-existing email");
                Assert.IsNull(nonExistingPerson);
            }
        }

        [Test]
        [Timeout(300)]
        public void FindPeople_ByEmailDomain_ManyElements()
        {
            for (int i = 0; i < 10000; i++)
            {
                var existingpeople =
                    this.peopleCollection.FindPeople("gmail1.com").ToList();
                Assert.AreEqual(50, existingpeople.Count);
                var notExistingpeople =
                    this.peopleCollection.FindPeople("non-existing email").ToList();
                Assert.AreEqual(0, notExistingpeople.Count);
            }
        }

        [Test]
        [Timeout(300)]
        public void FindPeople_ByNameAndTown_ManyElements()
        {
            for (int i = 0; i < 10000; i++)
            {
                var existingpeople =
                    this.peopleCollection.FindPeople("Pesho1", "Sofia1").ToList();
                Assert.AreEqual(50, existingpeople.Count);
                var notExistingpeople =
                    this.peopleCollection.FindPeople("Pesho1", "Sofia5").ToList();
                Assert.AreEqual(0, notExistingpeople.Count);
            }
        }

        [Test]
        [Timeout(300)]
        public void FindPeople_ByAgeRange_ManyElements()
        {
            for (int i = 0; i < 2000; i++)
            {
                var existingpeople =
                    this.peopleCollection.FindPeople(20, 21).ToList();
                Assert.AreEqual(100, existingpeople.Count);
                var notExistingpeople =
                    this.peopleCollection.FindPeople(500, 600).ToList();
                Assert.AreEqual(0, notExistingpeople.Count);
            }
        }

        [Test]
        [Timeout(300)]
        public void FindPeople_ByAgeRangeAndTown_ManyElements()
        {
            for (int i = 0; i < 5000; i++)
            {
                var existingpeople =
                    this.peopleCollection.FindPeople(18, 22, "Sofia20").ToList();
                Assert.AreEqual(50, existingpeople.Count);

                var notExistingTownpeople =
                    this.peopleCollection.FindPeople(20, 30, "Missing town").ToList();
                Assert.AreEqual(0, notExistingTownpeople.Count);

                var notExistingAgepeople =
                    this.peopleCollection.FindPeople(200, 300, "Sofia1").ToList();

                Assert.AreEqual(0, notExistingAgepeople.Count);
            }
        }
    }
}