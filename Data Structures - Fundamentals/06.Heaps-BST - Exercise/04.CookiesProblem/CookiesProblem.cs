namespace _04.CookiesProblem
{
    using Wintellect.PowerCollections;

    public class CookiesProblem
    {
        public int Solve(int minSweetness, int[] cookies)
        {
            var cookiesHeap = new OrderedBag<int>();
            cookiesHeap.AddMany(cookies);
            int countOperations = 0;

            while (cookiesHeap.GetFirst() < minSweetness && cookiesHeap.Count > 1)
            {
                int firstCookie = cookiesHeap.RemoveFirst();
                int secondCookie = cookiesHeap.RemoveFirst();
                int combinedCookie = firstCookie + (2 * secondCookie);

                cookiesHeap.Add(combinedCookie);
                countOperations++;
            }

            return cookiesHeap.GetFirst() < minSweetness
                ? -1
                : countOperations;
        }
    }
}
