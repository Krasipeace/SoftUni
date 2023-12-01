using NUnit.Framework;
using System.Collections.Generic;
using System;
using Exam.TaskManager;
using System.Linq;
using System.Diagnostics;

public class TaskManagerTests
{
    private ITaskManager taskManager;

    private Task GetRandomTask()
    {
        Random random = new Random();

        return new Task(
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                random.Next(1, 1_000_000_000),
                Guid.NewGuid().ToString());
    }

    [SetUp]
    public void Setup()
    {
        this.taskManager = new TaskManager();
    }

    private void PerformCorrectnessTesting(List<Action> correctnessTests)
    {
        correctnessTests.ForEach(Test =>
        {
            this.taskManager = new TaskManager();

            try { Test.Invoke(); } catch (ArgumentException) { }
        });

        this.taskManager = new TaskManager();
    }

    // Correctness Tests

    [Test]
    public void TestSize_ShouldReturnCorrectResults()
    {
        this.taskManager.AddTask(GetRandomTask());
        this.taskManager.AddTask(GetRandomTask());
        this.taskManager.AddTask(GetRandomTask());

        Assert.AreEqual(this.taskManager.Size(), 3);
    }

    [Test]
    public void TestContains_WithExistentTask_ShouldReturnTrue()
    {
        Task task = GetRandomTask();
        this.taskManager.AddTask(task);

        Assert.IsTrue(this.taskManager.Contains(task));
    }

    [Test]
    public void TestGetTask_WithNonExistentTask_ShouldThrowException()
    {
        Task task = GetRandomTask();
        this.taskManager.AddTask(task);

        // Little bit of hacks
        try
        {
            this.taskManager.GetTask(GetRandomTask().Id);
        }
        catch (ArgumentException e)
        {
            Assert.IsTrue(true);
            return;
        }

        Assert.IsTrue(false);
    }

    [Test]
    public void TestRescheduleTask_WithExistentTask_ShouldReturnCorrectResults()
    {
        Task task = GetRandomTask();
        this.taskManager.AddTask(task);
        this.taskManager.ExecuteTask();
        this.taskManager.RescheduleTask(task.Id);
        Task rescheduledExecuted = this.taskManager.ExecuteTask();

        Assert.AreEqual(task, rescheduledExecuted);
    }

    // Performance Tests

    [Test]
    public void testContains_With100000Results_ShouldPassQuickly()
    {
        this.PerformCorrectnessTesting(new List<Action>(new Action[]{
                this.TestContains_WithExistentTask_ShouldReturnTrue,
        }));

        int count = 100000;

        Task taskToContain = null;

        for (int i = 0; i < count; i++)
        {
            if (i == count / 2)
            {
                taskToContain = GetRandomTask();
                this.taskManager.AddTask(taskToContain);
            }
            else
            {
                this.taskManager.AddTask(GetRandomTask());
            }
        }

        Stopwatch stopwatch = new Stopwatch(); stopwatch.Start();

        this.taskManager.Contains(taskToContain);

        stopwatch.Stop();

        long elapsedTime = stopwatch.ElapsedMilliseconds;

        Assert.IsTrue(elapsedTime <= 5);
    }

    [Test]
    public void testGetTask_With100000Results_ShouldPassQuickly()
    {
        this.PerformCorrectnessTesting(new List<Action>(new Action[]{
                this.TestGetTask_WithNonExistentTask_ShouldThrowException,
        }));

        int count = 100000;

        Task taskToContain = null;

        for (int i = 0; i < count; i++)
        {
            if (i == count / 2)
            {
                taskToContain = GetRandomTask();
                this.taskManager.AddTask(taskToContain);
            }
            else
            {
                this.taskManager.AddTask(GetRandomTask());
            }
        }

        Stopwatch stopwatch = new Stopwatch(); stopwatch.Start();

        this.taskManager.GetTask(taskToContain.Id);

        stopwatch.Stop();

        long elapsedTime = stopwatch.ElapsedMilliseconds;

        Assert.IsTrue(elapsedTime <= 5);
    }
}
