namespace BookShop;

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
        int inputYear = int.Parse(Console.ReadLine());
        Console.WriteLine(GetBooksNotReleasedIn(db, inputYear));
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

}


