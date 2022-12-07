using NUnit.Framework;
using System;
using System.Linq;

namespace BankSafe.Tests
{
    [TestFixture]
    public class BankVaultTests
    {
        private Item item;
        private BankVault bankVault;

        [SetUp]
        public void Setup()
        {
            item = new Item("Krasi", "item666");
            bankVault = new BankVault();
        }

        [Test]
        public void CreateItemShouldWorkAsExpected()
        {
            Assert.AreEqual("Krasi", item.Owner);
            Assert.AreEqual("item666", item.ItemId);
        }

        [Test]
        public void AddItem_ShouldWorkAsExpected()
        {
            bankVault.AddItem("A1", item);
            Assert.IsTrue(bankVault.VaultCells.Values.Contains(item));
        }

        [Test]
        public void AddItemIntoNotExistingCell_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                bankVault.AddItem("F1", item);
            }, "Cell doesn't exists!");
        }

        [Test]
        public void AddItemIntoTakenCell_ShouldThrowException()
        {
            bankVault.AddItem("A1", item);
            Assert.Throws<ArgumentException>(() =>
            {
                bankVault.AddItem("A1", item);
            }, "Cell is already taken!");
        }

        [Test]
        public void RemoveItem_ShouldWorkAsExpected()
        {
            bankVault.AddItem("A1", item);
            bankVault.RemoveItem("A1", item);
            Assert.IsFalse(bankVault.VaultCells.Values.Contains(item));
            Assert.IsNull(bankVault.VaultCells["A1"]);
        }

        [Test]
        public void RemoveItemFromNonExistingCell_ShouldThrowException()
        {
            bankVault.AddItem("A1", item);
            Assert.Throws<ArgumentException>(() =>
            {
                bankVault.RemoveItem("F1", item);
            }, "Cell doesn't exists!");            
        }

        [Test]
        public void RemoveNonExistingItem_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                bankVault.RemoveItem("A1", item);
            }, $"Item in that cell doesn't exists!");
        }
    }
}