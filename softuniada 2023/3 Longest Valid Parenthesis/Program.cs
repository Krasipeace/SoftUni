class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();

        Console.WriteLine(GetLongestValidParentheses(input));  
    }

    public static int GetLongestValidParentheses(string s)
    {
        int counter = 0; 
        int currLength = 0; 
        int maxLength = 0; 
        int startIndex = 0;

        for (int i = 0; i < s.Length; ++i)
        {
            if (s[i] == '(')
            {
                counter++;
            }
            if (s[i] == ')')
            {
                counter--;
            }

            if (counter < 0)
            {
                counter = 0;
                startIndex = i + 1;

                if (maxLength < currLength)
                {
                    maxLength = currLength;
                }

                currLength = 0;
            }
            else
            {
                currLength++;
            }
        }

        if (counter > 0)
        {
            counter = 0;
            currLength = 0;

            for (int i = s.Length - 1; i >= startIndex; --i)
            {
                if (s[i] == '(')
                {
                    counter++;
                }
                if (s[i] == ')')
                {
                    counter--;
                }

                if (counter > 0)
                {
                    counter = 0;

                    if (maxLength < currLength)
                    {
                        maxLength = currLength;
                    }

                    currLength = 0;
                }
                else
                {
                    currLength++;
                }
            }
        }

        if (maxLength < currLength)
        {
            maxLength = currLength;
        }

        return maxLength;
    }
}