using System;
using System.Globalization;

namespace String_Manipulation
{
    internal class FormatDateTime
    {

        internal static void FormatDateTimeValuesAsStrings()
        {
            // Formatting overloads
            // ToString()
            // ToString(string? format)
            // ToString(IFormatProvider? formatProvider)
            // ToString (string? format, IFormatProvider? formatProvider);

            var cultures = new[] {
                new CultureInfo("en-US"),
                new CultureInfo("de-DE"),
                new CultureInfo("ja-JP")
            };

            var dateTime = new DateTime(2020, 03, 28, 07, 39, 54, 123);
            // DateTimeFormatInfo - provides culture specific information about the format of date and time values
            //                    - includes all necessary properties to control how dates are formatted
            //                    - DateTimeFormatInfo from the current culture info is used by default
            //                    - Culture specific names and the days of months
            foreach (var culture in cultures)
            {
                Console.WriteLine(culture);
                // Default format
                Console.WriteLine(dateTime.ToString(culture));
                // Single character format specifiers as a short-hand way to indicate the string representation
                // of the DateTime value
                // d - Culture's DateTimeFormat.ShortDatePattern
                Console.WriteLine(dateTime.ToString("d", culture));
                // D - Long date
                Console.WriteLine(dateTime.ToString("D", culture));
                // F - Full date/time (long)
                Console.WriteLine(dateTime.ToString("F", culture));
                // f - Full date/time (short)
                Console.WriteLine(dateTime.ToString("f", culture));
                // o - Round trip date/time
                Console.WriteLine(dateTime.ToString("o", culture));
                // m - Month/day
                Console.WriteLine(dateTime.ToString("m", culture));
                // t - Short time
                Console.WriteLine(dateTime.ToString("t", culture));
                // T - Long time
                Console.WriteLine(dateTime.ToString("T", culture));
                // Custom format
                // dddd - full name of the day of week
                // d - numeric value of day within month
                // MMMM - full month name
                // yyyy - 4 digit year
                // hh   - hour time 
                // mm   - minute time
                // tt   - AM/PM designator
                Console.WriteLine(dateTime.ToString("dddd, d MMMM yyyy 'at' hh:mm tt", culture));
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
        }
    }
}