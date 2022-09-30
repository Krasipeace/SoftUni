using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace _5._Date_Modifier
{
    public class DateModifier
    {
        public long GetDaysBetweenTwoDates(string firstDateAsString, string secondDateAsString)
        {
            DateTime firstDate = DateTime.ParseExact(firstDateAsString, "yyyy MM dd", CultureInfo.InvariantCulture);
            DateTime secondDate = DateTime.ParseExact(secondDateAsString, "yyyy MM dd", CultureInfo.InvariantCulture);

            return Math.Abs((firstDate - secondDate).Days);
        }
    }
}
