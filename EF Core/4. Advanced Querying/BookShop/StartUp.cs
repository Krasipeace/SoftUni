namespace BookShop;

using System.Text;

using BookShop.Models.Enums;
using Data;
using Initializer;
using Microsoft.EntityFrameworkCore;

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
        //string input = Console.ReadLine();
        //Console.WriteLine(GetAuthorNamesEndingIn(db, input));


        // Book Search
        //string input = Console.ReadLine().ToLower();
        //Console.WriteLine(GetBookTitlesContaining(db, input));


        // Book Search by Author
        //string input = Console.ReadLine();
        //Console.WriteLine(GetBooksByAuthor(db, input));


        // Count Books
        //int input = int.Parse(Console.ReadLine());
        //Console.WriteLine(CountBooks(db, input));


        // Total Book Copies
        //Console.WriteLine(CountCopiesByAuthor(db));


        // Profit by Category
        //Console.WriteLine(GetTotalProfitByCategory(db));


        // Most Recent Books
        //Console.WriteLine(GetMostRecentBooks(db));


        // Increase Prices
        //int beforeYear = 2010;
        //Console.WriteLine("Books prices before changes: ");
        //Console.WriteLine();

        //var booksPrices = db.Books
        //    .FromSqlInterpolated($"SELECT * FROM Books WHERE YEAR(ReleaseDate) < {beforeYear} ORDER BY Title ASC")
        //    .ToList();
        //StringBuilder sb = new StringBuilder();

        //foreach (var book in booksPrices)
        //{
        //    sb.AppendLine($"{book.Title} - ${book.Price:f2}");
        //}

        //Console.WriteLine(sb.ToString());
        //Console.WriteLine();

        //IncreasePrices(db);

        //Console.WriteLine("Books prices after changes: ");
        //Console.WriteLine();

        //var booksPricesAfterChanges = db.Books
        //    .FromSqlInterpolated($"SELECT * FROM Books WHERE YEAR(ReleaseDate) < {beforeYear} ORDER BY Title ASC")
        //    .ToList();
        //StringBuilder sb2 = new StringBuilder();

        //foreach (var book in booksPricesAfterChanges)
        //{
        //    sb2.AppendLine($"{book.Title} - ${book.Price:f2}");
        //}

        //Console.WriteLine(sb2.ToString().TrimEnd());


        // Remove Books
        Console.WriteLine(RemoveBooks(db));
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

    // Book Search
    public static string GetBookTitlesContaining(BookShopContext context, string input)
    {
        var booksInfo = context.Books
            .Where(b => b.Title.ToLower().Contains(input.ToLower()))
            .Select(b => b.Title)
            .OrderBy(title => title)
            .ToArray();

        StringBuilder sb = new StringBuilder();

        foreach (var title in booksInfo)
        {
            sb.AppendLine(title);
        }

        return sb.ToString().TrimEnd();
    }

    // Book Search by Author
    public static string GetBooksByAuthor(BookShopContext context, string input)
    {
        var booksInfo = context.Books
            .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
            .OrderBy(b => b.BookId)
            .Select(b => $"{b.Title} ({b.Author.FirstName} {b.Author.LastName})")
            .ToArray();

        StringBuilder sb = new StringBuilder();

        foreach (var book in booksInfo)
        {
            sb.AppendLine(book);
        }

        return sb.ToString().TrimEnd();
    }

    // Count Books
    public static int CountBooks(BookShopContext context, int lengthCheck)
    {
        int booksCounter = context.Books
            .Where(b => b.Title.Length > lengthCheck)
            .Count();

        return booksCounter;
    }

    // Total Book Copies
    public static string CountCopiesByAuthor(BookShopContext context)
    {
        var copiesCounter = context.Authors
            .OrderByDescending(a => a.Books.Sum(b => b.Copies))
            .Select(a => $"{a.FirstName} {a.LastName} - {a.Books.Sum(b => b.Copies)}")
            .ToArray();

        StringBuilder sb = new StringBuilder();

        foreach (var author in copiesCounter)
        {
            sb.AppendLine(author);
        }

        return sb.ToString().TrimEnd();
    }

    // Profit by Category
    public static string GetTotalProfitByCategory(BookShopContext context)
    {
        var categoriesInfo = context.Categories
            .OrderByDescending(c => c.CategoryBooks.Sum(b => b.Book.Price * b.Book.Copies))
            .ThenBy(c => c.Name)
            .Select(c => $"{c.Name} ${c.CategoryBooks.Sum(b => b.Book.Price * b.Book.Copies):f2}")
            .ToArray();

        StringBuilder sb = new StringBuilder();

        foreach (var catProfit in categoriesInfo)
        {
            sb.AppendLine(catProfit);
        }

        return sb.ToString().TrimEnd();
    }

    // Most Recent Books
    public static string GetMostRecentBooks(BookShopContext context)
    {
        var categoriesInfo = context.Categories
            .OrderBy(c => c.Name)
            .Select(c => new
            {
                CategoryName = c.Name,
                CategoryBooks = c.CategoryBooks
                    .OrderByDescending(cb => cb.Book.ReleaseDate)
                    .Select(cb => new
                    {
                        BookTitle = cb.Book.Title,
                        BookYear = cb.Book.ReleaseDate.Value.Year
                    })
                    .Take(3)
            })
            .ToArray();

        StringBuilder sb = new StringBuilder();

        foreach (var category in categoriesInfo)
        {
            sb.AppendLine($"--{category.CategoryName}");

            foreach (var book in category.CategoryBooks)
            {
                sb.AppendLine($"{book.BookTitle} ({book.BookYear})");
            }
        }

        return sb.ToString().TrimEnd();
    }

    // Increase Prices
    public static void IncreasePrices(BookShopContext context)
    {
        var booksInfo = context.Books
            .Where(b => b.ReleaseDate.Value.Year < 2010)
            .ToArray();

        foreach (var book in booksInfo)
        {
            book.Price += 5;
        }

        context.SaveChanges();
    }

    // Remove Books
    public static int RemoveBooks(BookShopContext context)
    {
        var booksData = context.Books
            .Where(b => b.Copies < 4200)           
            .ToArray();

        context.RemoveRange(booksData);
        context.SaveChanges();
        
        return booksData.Count();
    }
}