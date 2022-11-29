namespace Book.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;
    using static System.Net.Mime.MediaTypeNames;

    public class Tests
    {
        private Book defaultBook;
        [SetUp]
        public void SetUp()
        {
            defaultBook = new Book("City and the stars", "Arthur C. Clarke");
            defaultBook.AddFootnote(1, "Alvin exits Diaspar");
        }


        [Test]
        public void Test_CreateBookWorksAsExpected()
        {
            Book book = new Book("City and the stars", "Arthur C. Clarke");

            Assert.AreEqual("City and the stars", defaultBook.BookName);
            Assert.AreEqual("Arthur C. Clarke", defaultBook.Author);
        }

        [Test]
        public void Test_BookNameShouldWorkAsExpected()
        {
            string expectedBookName = "City and the stars";
            Book book = new Book(expectedBookName, "Arthur C. Clarke");
            string actualBookName = defaultBook.BookName;
            Assert.AreEqual(expectedBookName, actualBookName);
        }

        [Test]
        public void Test_BookAuthorShouldWorkAsExpected()
        {
            string expectedAuthorName = "Arthur C. Clarke";
            Book book = new Book("City and the stars", expectedAuthorName);
            string actualAuthorName = defaultBook.Author;
            Assert.AreEqual(expectedAuthorName, actualAuthorName);
        }

        [TestCase(null)]
        [TestCase("")]
        public void Test_EmptyOrNullBookName_ShouldThrowArgumentExpection(string bookName)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book(bookName, "Arthur C. Clarke");
            }, $"Invalid {nameof(bookName)}!");
        }

        [TestCase(null)]
        [TestCase("")]
        public void Test_EmptyOrNullAuthor_ShouldThrowArgumentExpection(string authorName)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book("City and the stars", authorName);
            }, $"Invalid {nameof(authorName)}!");
        }

        [Test]
        public void Test_AddFootNoteCounter_ShouldWorkAsExpected()
        {
            Assert.AreEqual(defaultBook.FootnoteCount, 1);
        }

        [Test]
        public void Test_AddExistingFootNote_ShouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                defaultBook.AddFootnote(1, "Alvin exits Diaspar");
            }, "Footnote already exists!");
        }

        [Test]
        public void Test_FindFootNote_ShouldWorkAsExpected()
        {
            string expected = "Footnote #1: Alvin exits Diaspar";
            string actual = defaultBook.FindFootnote(1);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_FindFootNote_WhichSearchForInexistentNote_ShouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                defaultBook.FindFootnote(11);
            }, "Footnote doesn't exists!");
        }

        [Test]
        public void Test_AlterFootNote_ShouldWorkAsExpected()
        {
            string alterText = "Alvin discover Lys";
            string expected = $"Footnote #1: {alterText}";
            defaultBook.AlterFootnote(1, alterText);
            string actual = defaultBook.FindFootnote(1);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_AlterFootNote_WhichIndexDoesNotExist_ShouldThrowInvalidOperationException()
        {
            string alterText = "Alvin discover Lys";
            string expected = $"Footnote #1: {alterText}";          
            Assert.Throws<InvalidOperationException>(() =>
            {
                defaultBook.AlterFootnote(11, alterText);
            }, "Footnote does not exists!");
        }
    }
}