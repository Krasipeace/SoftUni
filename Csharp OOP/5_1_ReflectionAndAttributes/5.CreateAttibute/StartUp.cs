namespace AuthorProblem
{
    using System;

    [Author("Victor")]
    public class StartUp
    {
        [Author("George")]
        static void Main(string[] args)
        {
            AuthorAttribute authorAttribute = new AuthorAttribute("attr");
            Console.WriteLine(authorAttribute.GetType()); 
        }
    }
}
