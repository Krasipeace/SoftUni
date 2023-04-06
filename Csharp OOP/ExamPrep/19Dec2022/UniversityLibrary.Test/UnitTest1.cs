namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class Tests
    {
        private TextBook textBook;
        private UniversityLibrary universityLibrary;

        [SetUp]
        public void Setup()
        {
            textBook = new TextBook("Dune", "Frank Herbert", "Sci-Fi");
            universityLibrary = new UniversityLibrary();
        }

        [Test]
        public void TitleSetAndGetCorrectly()
        {
            textBook.Title = "Dune";

            Assert.That(textBook.Title, Is.EqualTo("Dune"));
        }

        [Test]
        public void AuthorSetAndGetCorrectly()
        {
            textBook.Author = "Fredrick Backman";

            Assert.That(textBook.Author, Is.EqualTo("Fredrick Backman"));
        }

        [Test]
        public void InventoryNumberSetAndGetCorrectly()
        {
            textBook.InventoryNumber = 42;

            Assert.That(textBook.InventoryNumber, Is.EqualTo(42));
        }

        [Test]
        public void CategorySetAndGetCorrectly()
        {
            textBook.Category = "Contemporary";

            Assert.That(textBook.Category, Is.EqualTo("Contemporary"));
        }

        [Test]
        public void HolderSetAndGetCorrectly()
        {
            textBook.Holder = "Krasimir Dramaliev";

            Assert.That(textBook.Holder, Is.EqualTo("Krasimir Dramaliev"));
        }

        [Test]
        public void AddTextBookToLibrary_IncreasesCount()
        {
            var initialCount = universityLibrary.Catalogue.Count;
            var textBook = new TextBook("Dune", "Frank Herbert", "Sci-Fi");

            universityLibrary.AddTextBookToLibrary(textBook);

            Assert.That(universityLibrary.Catalogue.Count, Is.EqualTo(initialCount + 1));
        }

        [Test]
        public void AddTextBookToLibrary_SetsInventoryNumber()
        {
            var textBook = new TextBook("Dune", "Frank Herbert", "Sci-Fi");

            universityLibrary.AddTextBookToLibrary(textBook);

            Assert.That(textBook.InventoryNumber, Is.EqualTo(universityLibrary.Catalogue.Count));
        }

        [Test]
        public void LoanTextBook_WorksCorrectly()
        {
            var textBook = new TextBook("Dune", "Frank Herbert", "Sci-Fi");
            universityLibrary.AddTextBookToLibrary(textBook);

            string result = universityLibrary.LoanTextBook(1, "Krasimir Dramaliev");

            Assert.That(result, Is.EqualTo("Dune loaned to Krasimir Dramaliev."));
            Assert.That(universityLibrary.Catalogue[0].Holder, Is.EqualTo("Krasimir Dramaliev"));
        }

        [Test]
        public void LoanTextBook_WorksCorrectly_IfAlreadyLoaned()
        {
            var textBook = new TextBook("Dune", "Frank Herbert", "Sci-Fi");
            universityLibrary.AddTextBookToLibrary(textBook);
            universityLibrary.Catalogue[0].Holder = "Krasimir Dramaliev";

            string result = universityLibrary.LoanTextBook(1, "Krasimir Dramaliev");

            Assert.That(result, Is.EqualTo("Krasimir Dramaliev still hasn't returned Dune!"));
            Assert.That(universityLibrary.Catalogue[0].Holder, Is.EqualTo("Krasimir Dramaliev"));
        }

        [Test]
        public void ReturnTextBook_ResetsHolder()
        {
            var textBook = new TextBook("Dune", "Frank Herbert", "Sci-Fi");
            textBook.Holder = "Krasimir Dramaliev";
            universityLibrary.AddTextBookToLibrary(textBook);

            string result = universityLibrary.ReturnTextBook(1);

            Assert.That(result, Is.EqualTo("Dune is returned to the library."));
            Assert.That(universityLibrary.Catalogue[0].Holder, Is.EqualTo(string.Empty));
        }

        [Test]
        public void ToString_ReturnsExpectedString()
        {
            universityLibrary.AddTextBookToLibrary(textBook);

            string actual = textBook.ToString();
            string expected = $"Book: {textBook.Title} - {1}" + Environment.NewLine + $"Category: {textBook.Category}" + Environment.NewLine + $"Author: {textBook.Author}";

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Constructor_CatalogueInitialized()
        {
            Assert.IsNotNull(universityLibrary.Catalogue);
        }
    }
}