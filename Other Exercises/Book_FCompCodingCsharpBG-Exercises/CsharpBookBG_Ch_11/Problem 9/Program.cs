using System; //national holidays and working saturdays for 2022

namespace Problem_9
{
    internal class Program
    {

        static void Main(string[] args)
        {
            DateTime[] holidays, workSaturdays;
            SpecialDaysDataBase(out holidays, out workSaturdays);

            int countWorkDays = 0;

            DateTime today = DateTime.Now;
            Console.WriteLine($"Today is: {today}");

            Console.Write("Enter future date [YYYY/MM/DD]: ");
            DateTime futureDate = Convert.ToDateTime(Console.ReadLine());

            //int countHolidays = holidays.Length;
            //int countWorkSaturdays = workSaturdays.Length;
            //int allHolidays = countHolidays + countWorkSaturdays;
            //int allDays = (futureDate.Date - today.Date).Days;

            //to be finished..
            for (DateTime currentDay = today; currentDay <= futureDate; currentDay.AddDays(1))
            {
                countWorkDays = CheckNormalWorkDays(holidays, countWorkDays, currentDay);

                countWorkDays = CheckWeekends(workSaturdays, countWorkDays, currentDay);

            }

            Console.WriteLine($"Working days in the interval are: {countWorkDays} days.");

        }

        private static void SpecialDaysDataBase(out DateTime[] holidays, out DateTime[] workSaturdays)
        {
            holidays = new DateTime[]
            {
                new DateTime(2022, 01, 03), //Нова година - 1 януари (събота, почива се на 3 януари, понеделник)
                new DateTime(2022, 04, 24),
                new DateTime(2022, 05, 02), //Ден на труда - 1 май (неделя, почива се на 2 май, понеделник) 
                new DateTime(2022, 05, 06),
                new DateTime(2022, 05, 24),
                new DateTime(2022, 09, 06),
                new DateTime(2022, 09, 22),
                new DateTime(2022, 12, 26),
                new DateTime(2022, 12, 27),
                new DateTime(2022, 12, 28),
            };
            workSaturdays = new DateTime[]
            {
                new DateTime(2022, 05, 14 ),
                new DateTime(2022, 06, 04 ),
                new DateTime(2022, 09, 01 ),
            };
        }

        private static int CheckNormalWorkDays(DateTime[] holidays, int countWorkDays, DateTime currentDay)
        {
            if (currentDay.DayOfWeek >= DayOfWeek.Monday && currentDay.DayOfWeek <= DayOfWeek.Friday)
            {
                countWorkDays++;

                countWorkDays = CheckDayForHoliday(holidays, countWorkDays, currentDay);

            }

            return countWorkDays;
        }

        private static int CheckDayForHoliday(DateTime[] holidays, int countWorkDays, DateTime currentDay)
        {
            if (currentDay.DayOfWeek == holidays[0].DayOfWeek || currentDay.DayOfWeek == holidays[1].DayOfWeek
                                                              || currentDay.DayOfWeek == holidays[2].DayOfWeek
                                                              || currentDay.DayOfWeek == holidays[3].DayOfWeek
                                                              || currentDay.DayOfWeek == holidays[4].DayOfWeek
                                                              || currentDay.DayOfWeek == holidays[5].DayOfWeek
                                                              || currentDay.DayOfWeek == holidays[6].DayOfWeek
                                                              || currentDay.DayOfWeek == holidays[7].DayOfWeek
                                                              || currentDay.DayOfWeek == holidays[8].DayOfWeek
                                                              || currentDay.DayOfWeek == holidays[9].DayOfWeek)
            {
                countWorkDays--;
            };

            return countWorkDays;
        }

        private static int CheckWeekends(DateTime[] workSaturdays, int countWorkDays, DateTime currentDay)
        {
            if (currentDay.DayOfWeek == DayOfWeek.Sunday)
            {
                countWorkDays--;
                countWorkDays = CheckWorkingWeekend(workSaturdays, countWorkDays, currentDay);
            }

            if (currentDay.DayOfWeek == DayOfWeek.Saturday)
            {
                countWorkDays--;
                countWorkDays = CheckWorkingWeekend(workSaturdays, countWorkDays, currentDay);
            }

            return countWorkDays;
        }

        private static int CheckWorkingWeekend(DateTime[] workSaturdays, int countWorkDays, DateTime currentDay)
        {

            if (currentDay.DayOfWeek == workSaturdays[0].DayOfWeek || currentDay.DayOfWeek == workSaturdays[1].DayOfWeek 
                                                                   || currentDay.DayOfWeek == workSaturdays[2].DayOfWeek)
            {
                countWorkDays++;
            }

            return countWorkDays;

            // for (int i = 0; i < countWorkSaturdays; i++)
            // {
            //     if (workSaturdays[i].Equals(currentDay))
            //     {
            //         countWorkDays++;
            //     }
            //
            //     return countWorkDays;
            // }
        }
    }
}
