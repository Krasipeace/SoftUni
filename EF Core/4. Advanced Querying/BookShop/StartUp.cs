﻿namespace BookShop;

using System.Text;

using BookShop.Models.Enums;
using Data;
using Initializer;

public class StartUp
{
    public static void Main()
    {
        using var db = new BookShopContext();
        //DbInitializer.ResetDatabase(db);

        // Age Restriction
        //string command = Console.ReadLine().ToLower();
        //string result = GetBooksByAgeRestriction(db, command);
        //Console.WriteLine(result);

        // Golden Books
        //Console.WriteLine(GetGoldenBooks(db));

        // Books by Price
        //Console.WriteLine(GetBooksByPrice(db));

        // Not Released In
        //int inputYear = int.Parse(Console.ReadLine());
        //Console.WriteLine(GetBooksNotReleasedIn(db, inputYear));

        // Get Books by Category
        //string inputCategories = Console.ReadLine().ToLower();
        //Console.WriteLine(GetBooksByCategory(db, inputCategories));

        // Released Before Date
        //string inputDate = Console.ReadLine();
        //Console.WriteLine(GetBooksReleasedBefore(db, inputDate));

        // Author Search
        string input = Console.ReadLine();
        Console.WriteLine(GetAuthorNamesEndingIn(db, input));
    }

    // Age Restriction
    public static string GetBooksByAgeRestriction(BookShopContext context, string command)
    {
        var ageCategories = Enum.Parse<AgeRestriction>(command, true);

        var bookTitles = context.Books
            .Where(b => b.AgeRestriction == ageCategories)
            .Select(b => b.Title)
            .OrderBy(title => title)
            .ToArray();

        StringBuilder sb = new StringBuilder();

        foreach (var book in bookTitles)
        {
            sb.AppendLine(book);
        }

        return sb.ToString().TrimEnd();
    }

    // Golden Books
    public static string GetGoldenBooks(BookShopContext context)
    {
        var goldenBooks = context.Books
            .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
            .OrderBy(b => b.BookId)
            .Select(b => b.Title)
            .ToArray();

        StringBuilder sb = new StringBuilder();

        foreach (var book in goldenBooks)
        {
            sb.AppendLine(book);
        }

        return sb.ToString().TrimEnd();
    }

    // Books by Price
    public static string GetBooksByPrice(BookShopContext context)
    {
        var booksInfo = context.Books
            .Where(b => b.Price > 40)
            .OrderByDescending(b => b.Price)
            .Select(b => $"{b.Title} - ${b.Price:f2}")
            .ToArray();

        StringBuilder sb = new StringBuilder();

        foreach (var book in booksInfo)
        {
            sb.AppendLine(book);
        }

        return sb.ToString().TrimEnd();
    }

    // Not Released In
    public static string GetBooksNotReleasedIn(BookShopContext context, int year)
    {
        var booksInfo = context.Books
            .Where(b => b.ReleaseDate.Value.Year != year)
            .OrderBy(b => b.BookId)
            .Select(b => b.Title)
            .ToArray();

        StringBuilder sb = new StringBuilder();

        foreach (var book in booksInfo)
        {
            sb.AppendLine(book);
        }

        return sb.ToString().TrimEnd();
    }

    // Book Titles by Category
    public static string GetBooksByCategory(BookShopContext context, string input)
    {
        string[] inputCategories = input.ToLower().Split(" ").ToArray();

        var booksInfo = context.BooksCategories
            .Where(bc => inputCategories.Contains(bc.Category.Name.ToLower()))
            .Select(bc => bc.Book.Title)
            .OrderBy(title => title)
            .ToArray();

        StringBuilder sb = new StringBuilder();

        foreach (var book in booksInfo)
        {
            sb.AppendLine(book);
        }

        return sb.ToString().TrimEnd();
    }

    // Released Before Date
    public static string GetBooksReleasedBefore(BookShopContext context, string date)
    {
        var formattedDate = DateTime.ParseExact(date, "dd-MM-yyyy", null);

        var booksInfo = context.Books
            .Where(b => b.ReleaseDate < formattedDate)
            .OrderByDescending(b => b.ReleaseDate)
            .Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:f2}")
            .ToArray();

        StringBuilder sb = new StringBuilder();

        foreach (var book in booksInfo)
        {
            sb.AppendLine(book);
        }

        return sb.ToString().TrimEnd();
    }

    // Author Search
    public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
    {
        var authorsInfo = context.Authors
            .Where(a => a.FirstName.EndsWith(input))
            .Select(a => a.FirstName + " " + a.LastName)
            .OrderBy(name => name)
            .ToArray();

        StringBuilder sb = new StringBuilder();

        foreach (var author in authorsInfo)
        {
            sb.AppendLine(author);
        }

        return sb.ToString().TrimEnd();
    }
}