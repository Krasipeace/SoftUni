using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DefiningClasses
{
    public class DateModifier
    {
        public static int GetDateDifference(string first, string second)
        {
            var firstDate = DateTime.ParseExact(first, "yyyy MM dd", CultureInfo.InvariantCulture);
            var secondDate = DateTime.ParseExact(second, "yyyy MM dd", CultureInfo.InvariantCulture);
            var dateDifference = firstDate - secondDate;

            return Math.Abs(dateDifference.Days);
        }
    }
}
