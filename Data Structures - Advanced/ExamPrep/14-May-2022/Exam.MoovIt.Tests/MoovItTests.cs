using Exam.MoovIt;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class Tests
{
    private IMoovIt moovIt;

    private List<string> GetRandomLocationPoints()
    {
        Random random = new Random();

        int randomLength = (int)random.Next(5, 100);

        List<string> randomLocationPoints = new List<string>();

        for (int i = 0; i < randomLength; i++)
        {
            randomLocationPoints.Add(Guid.NewGuid().ToString());
        }

        return randomLocationPoints;
    }

    private Route GetRandomRoute()
    {
        Random random = new Random();

        return new Route(
            Guid.NewGuid().ToString(),
            random.Next(1, 1_000_000),
            random.Next(1, 1_000),
            random.Next(1, 1_000) > 500 ? true : false,
            this.GetRandomLocationPoints());
    }

    [SetUp]
    public void Setup()
    {
        this.moovIt = new MoovIt();
    }

    // Correctness Tests

    [Test]
    public void TestAddRoute_WithCorrectData_ShouldSuccessfullyAddRoute()
    {
        this.moovIt.AddRoute(GetRandomRoute());
        this.moovIt.AddRoute(GetRandomRoute());

        Assert.AreEqual(2, this.moovIt.Count);
    }

    [Test]
    public void TestContains_WithExistentRoute_ShouldReturnTrue()
    {
        Route route = GetRandomRoute();

        this.moovIt.AddRoute(route);

        Assert.IsTrue(this.moovIt.Contains(route));
    }

    [Test]
    public void TestContains_WithEqualRoute_ShouldReturnTrue()
    {
        Route route = new Route("Test1", 10D, 1, false, new List<string>(new string[] { "Sofia", "Plovdiv", "Stara Zagora", "Burgas" }));
        Route route2 = new Route("Test2", 10D, 1, false, new List<string>(new string[] { "Sofia", "Pleven", "Veliko Turnovo", "Varna", "Burgas" }));

        this.moovIt.AddRoute(route);

        Assert.IsTrue(this.moovIt.Contains(route2));
    }

    [Test]
    public void TestCount_With5Routes_ShouldReturn5()
    {
        this.moovIt.AddRoute(this.GetRandomRoute());
        this.moovIt.AddRoute(this.GetRandomRoute());
        this.moovIt.AddRoute(this.GetRandomRoute());
        this.moovIt.AddRoute(this.GetRandomRoute());
        this.moovIt.AddRoute(this.GetRandomRoute());

        Assert.AreEqual(5, this.moovIt.Count);
    }

    [Test]
    public void TestChooseRoute_WithNonexistentRoute_ShouldThrowException()
    {
        Route route = this.GetRandomRoute();

        this.moovIt.AddRoute(route);

        Assert.Throws<ArgumentException>(() => this.moovIt.ChooseRoute(this.GetRandomRoute().Id));
    }

    [Test]
    public void TestSearchRoutes_WithContainedPoints_ShouldReturnCorrectRoutes()
    {
        Route route = new Route("Test1", 10D, 200, false, new List<string>(new string[] { "Sofia", "Plovdiv", "Stara Zagora", "Burgas" }));
        Route route2 = new Route("Test2", 10D, 1, false, new List<string>(new string[] { "Vidin", "Pleven", "Veliko Turnovo", "Varna", "Burgas" }));
        Route route3 = new Route("Test3", 10D, 400, false, new List<string>(new string[] { "Vraca", "Plovdiv", "Stara Zagora", "Varna", "Burgas" }));
        Route route4 = new Route("Test4", 500D, 500, false, new List<string>(new string[] { "Sofia", "Plovdiv", "Stara Zagora", "Varna", "Burgas" }));

        this.moovIt.AddRoute(route);
        this.moovIt.AddRoute(route2);
        this.moovIt.AddRoute(route3);
        this.moovIt.AddRoute(route4);

        List<Route> routes = this.moovIt.SearchRoutes("Plovdiv", "Burgas").ToList();
        ;

        Assert.AreEqual(3, routes.Count);
        Assert.AreEqual(route, routes[0]);
        Assert.AreEqual(route4, routes[1]);
        Assert.AreEqual(route3, routes[2]);
    }

    [Test]
    public void TestGetTop5MostPopularRoutes_WithMoreThan5Routes_ShouldReturnCorrectResults()
    {
        Route route = new Route("Test1", 100D, 50, true, new List<string>(new string[] { "Sofia", "Plovdiv", "Stara Zagora", "Burgas" }));
        Route route2 = new Route("Test2", 100D, 50, true, new List<string>(new string[] { "Vidin", "Pleven", "Burgas" }));
        Route route3 = new Route("Test3", 10D, 100, true, new List<string>(new string[] { "Vraca", "Plovdiv", "Stara Zagora", "Burgas" }));
        Route route4 = new Route("Test4", 10D, 100, false, new List<string>(new string[] { "Mezdra", "Plovdiv", "Burgas" }));
        Route route5 = new Route("Test5", 250D, 200, false, new List<string>(new string[] { "Montana", "Plovdiv", "Stara Zagora", "Varna", "Burgas" }));
        Route route6 = new Route("Test6", 200D, 200, false, new List<string>(new string[] { "Svoge", "Plovdiv", "Stara Zagora", "Varna", "Burgas" }));

        this.moovIt.AddRoute(route);
        this.moovIt.AddRoute(route2);
        this.moovIt.AddRoute(route3);
        this.moovIt.AddRoute(route4);
        this.moovIt.AddRoute(route5);
        this.moovIt.AddRoute(route6);

        List<Route> list = this.moovIt.GetTop5RoutesByPopularityThenByDistanceThenByCountOfLocationPoints().ToList();

        Assert.AreEqual(5, list.Count);
        Assert.AreEqual(route6, list[0]);
        Assert.AreEqual(route5, list[1]);
        Assert.AreEqual(route4, list[2]);
        Assert.AreEqual(route3, list[3]);
        Assert.AreEqual(route2, list[4]);
    }

    // Performance Tests

    [Test]
    public void TestAddRoute_With100000Results_ShouldPassQuickly()
    {
        List<Route> routesToAdd = new List<Route>();

        int count = 100000;

        for (int i = 0; i < count; i++)
        {
            routesToAdd.Add(new Route(i + "", i * 1000D, i * 100, false, GetRandomLocationPoints()));
        }

        Stopwatch stopwatch = new Stopwatch(); stopwatch.Start();

        for (int i = 0; i < count; i++)
        {
            this.moovIt.AddRoute(routesToAdd[i]);
        }

        stopwatch.Stop();

        Assert.IsTrue(stopwatch.ElapsedMilliseconds < 450);
    }
}