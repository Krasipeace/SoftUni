namespace _04.CookiesProblem
{
    using System;
    using System.Linq;
    using _03.MinHeap;

    public class CookiesProblem
    {
        public int Solve(int minSweetness, int[] cookies)
        {
            var cookiesHeap = new MinHeap<int>();
            int countOperations = 0;

            foreach (var cookie in cookies)
            {
                cookiesHeap.Add(cookie);
            }

            while (cookiesHeap.Size > 0 && cookiesHeap.Peek() < minSweetness)
            {
                int firstCookie = cookiesHeap.ExtractMin();
                int secondCookie = cookiesHeap.ExtractMin();
                int combinedCookie = firstCookie + (2 * secondCookie);

                cookiesHeap.Add(combinedCookie);
                countOperations++;
            }

            return cookiesHeap.Peek() < minSweetness 
                ? -1 
                : countOperations;
        }
    }
}
