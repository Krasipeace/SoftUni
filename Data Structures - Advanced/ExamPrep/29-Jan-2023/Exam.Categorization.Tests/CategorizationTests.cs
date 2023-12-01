using NUnit.Framework;
using System.Collections.Generic;
using Exam.Categorization;
using System;
using System.Linq;
using System.Diagnostics;

public class CategorizationTests
{
    private ICategorizator categorizator;

    private Category GetRandomCategory()
    {
        return new Category(
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString());
    }

    [SetUp]
    public void Setup()
    {
        this.categorizator = new Categorizator();
    }

    private void PerformCorrectnessTesting(List<Action> correctnessTests)
    {
        correctnessTests.ForEach(Test =>
        {
            this.categorizator = new Categorizator();

            try { Test.Invoke(); } catch (ArgumentException) { }
        });

        this.categorizator = new Categorizator();
    }

    // Correctness Tests

    [Test]
    public void TestSize_ShouldReturnCorrectResults()
    {
        this.categorizator.AddCategory(GetRandomCategory());
        this.categorizator.AddCategory(GetRandomCategory());
        this.categorizator.AddCategory(GetRandomCategory());

        Assert.AreEqual(this.categorizator.Size(), 3);
    }

    [Test]
    public void TestAddCategory_WithDuplicate_ShouldThrow()
    {
        Category category = this.GetRandomCategory();
        this.categorizator.AddCategory(category);

        // Little bit of hacks
        try
        {
            this.categorizator.AddCategory(category);
        }
        catch (ArgumentException e)
        {
            Assert.IsTrue(true);
            return;
        }

        Assert.IsTrue(false);
    }

    [Test]
    public void TestContains_WithExistentCategory_ShouldReturnTrue()
    {
        Category category = GetRandomCategory();
        this.categorizator.AddCategory(category);

        Assert.IsTrue(this.categorizator.Contains(category));
    }

    [Test]
    public void TestContains_WithNonExistentCategory_ShouldReturnFalse()
    {
        Category category = GetRandomCategory();
        this.categorizator.AddCategory(category);

        Assert.IsFalse(this.categorizator.Contains(GetRandomCategory()));
    }

    [Test]
    public void TestGetChildren_WithData_ShouldReturnCorrectResults()
    {
        Category category1 = new Category("1", "a", "te");
        Category category2 = new Category("2", "b", "tet");
        Category category3 = new Category("3", "c", "te");
        Category category4 = new Category("4", "d", "te");
        Category category5 = new Category("5", "e", "te");

        this.categorizator.AddCategory(category1);
        this.categorizator.AddCategory(category2);
        this.categorizator.AddCategory(category3);
        this.categorizator.AddCategory(category4);
        this.categorizator.AddCategory(category5);

        this.categorizator.AssignParent(category3.Id, category2.Id);
        this.categorizator.AssignParent(category4.Id, category2.Id);
        this.categorizator.AssignParent(category5.Id, category4.Id);
        this.categorizator.AssignParent(category2.Id, category1.Id);

        HashSet<Category> set =this.categorizator.GetChildren(category1.Id).ToHashSet();

        Assert.AreEqual(set.Count, 4);
        Assert.IsTrue(set.Contains(category2));
        Assert.IsTrue(set.Contains(category3));
        Assert.IsTrue(set.Contains(category4));
        Assert.IsTrue(set.Contains(category5));
    }

    // Performance Tests

    [Test]
    public void TestContains_With100000Results_ShouldPassQuickly()
    {
        this.PerformCorrectnessTesting(new List<Action>(new Action[]{
                this.TestContains_WithExistentCategory_ShouldReturnTrue,
                this.TestContains_WithNonExistentCategory_ShouldReturnFalse,
        }));

        int count = 100000;

        Category categoryToContain = null;

        for (int i = 0; i < count; i++)
        {
            if (i == count / 2)
            {
                categoryToContain = GetRandomCategory();
                this.categorizator.AddCategory(categoryToContain);
            }
            else
            {
                this.categorizator.AddCategory(GetRandomCategory());
            }
        }

        Stopwatch stopwatch = new Stopwatch(); stopwatch.Start();

        this.categorizator.Contains(categoryToContain);

        stopwatch.Stop();

        long elapsedTime = stopwatch.ElapsedMilliseconds;

        Assert.IsTrue(elapsedTime <= 5);
    }

    [Test]
    public void TestGetChildren_With100000Results_ShouldPassQuickly()
    {
        this.PerformCorrectnessTesting(new List<Action>(new Action[]{
                this.TestGetChildren_WithData_ShouldReturnCorrectResults,
        }));

        int count = 100000;

        Category parentCategory = null;

        for (int i = 0; i < count; i++)
        {
            if (i == count / 2)
            {
                parentCategory = new Category(i + "", i + "name", "bar");
                this.categorizator.AddCategory(parentCategory);
            }
            else if (i > count / 2)
            {
                this.categorizator.AddCategory(new Category(i + "", i + "name", "foo"));
                this.categorizator.AssignParent(i + "", parentCategory.Id);
            }
            else
            {
                this.categorizator.AddCategory(new Category(i + "", i + "name", "foo"));
            }
        }

        Stopwatch stopwatch = new Stopwatch(); stopwatch.Start();

        this.categorizator.GetChildren(parentCategory.Id);

        stopwatch.Stop();

        long elapsedTime = stopwatch.ElapsedMilliseconds;

        Assert.IsTrue(elapsedTime <= 100);
    }
}
