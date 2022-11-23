namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private Database defaultDB;
        [SetUp]
        public void SetUp()
        {
            this.defaultDB = new Database();
        }

        [TestCase(new int[] { })]
        [TestCase(new[] { 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Test_ConstructorShouldInitializeData(int[] data)
        {
            Database database = new Database(data);

            int expected = data.Length;
            int actual = database.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21 })]
        public void Test_ConstructorShouldThrowException_WhenInputDataIsAbove16Count(int[] data)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Database database = new Database(data);
            }, "Array capacity must be exactly 16 integers!");

        }
        [TestCase(new int[] { })]
        [TestCase(new[] { 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Test_ConstructorShouldAddElementsIntoDataField(int[] data)
        {
            Database database = new Database(data);

            int[] expectedData = data;
            int[] actualData = database.Fetch();

            CollectionAssert.AreEqual(expectedData, actualData);
        }

        [TestCase(new int[] { })]
        [TestCase(new[] { 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Test_CountShouldReturnCorrectCount(int[] data)
        {
            Database database = new Database(data);

            int expectedCount = data.Length;
            int actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Test_AddingElementsShouldIncreaseCount()
        {
            int expectedCount = 5;
            for (int i = 1; i <= 5; i++)
            {
                this.defaultDB.Add(i);
            }

            int actualCount = this.defaultDB.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Test_AddingElementsShouldAddThemToTheDataCollection()
        {
            int[] expectedData = new int[5];
            for (int i = 1; i <= 5; i++)
            {
                this.defaultDB.Add(i);
                expectedData[i - 1] = i;
            }

            int[] actualData = this.defaultDB.Fetch();

            CollectionAssert.AreEqual(expectedData, actualData);
        }

        [Test]
        public void Test_AddingMoreThan16ElementsShouldThrowException()
        {
            for (int i = 1; i <= 16; i++)
            {
                this.defaultDB.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.defaultDB.Add(17);
            }, "Array capacity must be exactly 16 integers!");
        }

        [Test]
        public void Test_RemovingElementShouldDecreaseCount()
        {
            int initialCount = 5;
            for (int i = 1; i <= initialCount; i++)
            {
                this.defaultDB.Add(i);
            }

            int removeCount = 2;
            for (int i = 1; i <= removeCount; i++)
            {
                this.defaultDB.Remove();
            }

            int expectedCount = initialCount - removeCount;
            int actualCount = this.defaultDB.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Test_RemovingElementsShouldRemoveItFromTheDataCollection()
        {
            int initialCount = 5;
            for (int i = 1; i <= initialCount; i++)
            {
                this.defaultDB.Add(i);
            }

            int removeCount = 2;
            for (int i = 1; i <= removeCount; i++)
            {
                this.defaultDB.Remove();
            }

            int[] expectedData = new int[] { 1, 2, 3 };
            int[] actualData = this.defaultDB.Fetch();

            CollectionAssert.AreEqual(expectedData, actualData);
        }

        [Test]
        public void Test_RemoveShouldThrowException_WhenTthereAreNoElementsInDataBase()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.defaultDB.Remove();
            }, "The collection is empty!");
        }

        [TestCase(new int[] { })]
        [TestCase(new[] { 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Test_FetchShouldReturnCollectionWithElementsInDatabase(int[] data)
        {
            Database database = new Database(data);

            int[] expectedData = data;
            int[] actualData = database.Fetch();

            CollectionAssert.AreEqual(expectedData, actualData);
        }



    }
}
