using System;

namespace Gladkih.Nsudotnet.Calendar
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the date: ");
            String dateString = Console.ReadLine();
            DateTime userDate;

            if (!DateTime.TryParse(dateString, out userDate))
            {
                Console.WriteLine("Incorrect format!");
                return;
            }

            DateTime currentDay = userDate.AddDays(-userDate.Day + 1);
            currentDay = currentDay.AddDays(-(int) currentDay.DayOfWeek + 1);

            do
            {
                if (0 == (int)currentDay.DayOfWeek || 6 == (int)currentDay.DayOfWeek)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write("{0} ", currentDay.ToString("ddd"));
                Console.ResetColor();
                currentDay = currentDay.AddDays(1);
            } while ((int) currentDay.DayOfWeek != 1);
            Console.WriteLine();

            int workingDays = 0;
            currentDay = currentDay.AddDays(-7);
            while (currentDay.Month <= userDate.Month)
            {
                do
                {
                    if (currentDay.Month != userDate.Month)
                    {
                        Console.Write("  ");
                    }
                    else
                    {
                        if (0 == (int) currentDay.DayOfWeek || 6 == (int) currentDay.DayOfWeek)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else
                        {
                            workingDays++;
                        }
                        if (userDate == currentDay)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                        }
                        if (DateTime.Today == currentDay)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                        }
                        Console.Write(currentDay.Day.ToString("D2"));
                    }
                    Console.ResetColor();
                    Console.Write(" ");
                    currentDay = currentDay.AddDays(1);
                } while ((int)currentDay.DayOfWeek != 1);
                Console.WriteLine();
            }
            Console.WriteLine("Number of working days in month is {0}", workingDays);
        }

    }
}
