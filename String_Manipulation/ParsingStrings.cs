using System;
using System.Globalization;

namespace String_Manipulation
{
    public class ParsingStrings
    {
        // Parsing - an operation that converts a string back into another .Net type
        // The reverse of formatting types to strings. E.g. converting a string date to DateTime object instance
        // Involves similar rules and considerations to formatting, e.g. cultural rules (nb: dates)
        // IFormatterProvider - can influence how a string is interpreted. 
        public static void ParsingNumbersExercises()
        {
            string aStringNumber = "12345678";
            int integerRepresentation;

            // Option 1 
            integerRepresentation = Convert.ToInt32(aStringNumber);
            Console.WriteLine($"{aStringNumber} => {integerRepresentation}");

            // Most types include parse methods. Preferred parsing mechanism.
            // Simplifies code required.
            // Parse will throw an exception of input string is not valid
            
            
            integerRepresentation = int.Parse(aStringNumber);
            Console.WriteLine($"{aStringNumber} => {integerRepresentation}");

            // Try methods - common in .Net. Allows for the attempt on an operation without the risk
            // of an exception.
            // No try catch blocks here - cleaner. 

            var result = Int32.TryParse(aStringNumber, out integerRepresentation) ? $"{integerRepresentation}" : "failed";
            Console.WriteLine(result);

            // Example with Double
            double doubleRepresentation;
            aStringNumber = "12345678.45454";
            result = Double.TryParse(aStringNumber, out doubleRepresentation) ? $"{doubleRepresentation}" : "failed";
            Console.WriteLine(result);

            // Provide number styles and culture argument to TryParse
            // -3,140 now parses.
            result = Int32.TryParse(aStringNumber, 
                                    NumberStyles.Any, 
                                    CultureInfo.CurrentCulture, 
                                    out integerRepresentation) ? $"{integerRepresentation}" : "failed";
            Console.WriteLine(result);
        }

        public static void ParsingBooleans()
        {
            var dataInput = new[]
            {
                "true",
                "false",
                "TRUE",
                "not true", // fails
                null        // fails
            };

            foreach (var entry in dataInput)
            {
                // Handles all anomalies - dodgy inputs. 
                var result = bool.TryParse(entry, out var retResult) ? $"{entry} => {retResult}" : "failed";
                Console.WriteLine(result);
            }
        }

        public static void ParsingDateTimeTypes()
        {
            // DateTime - can be complex to parse in .Net
            // So many formatting variations
            // Culture plays a more important role 
            Console.Clear();
            var cultures = new[]
            {
                new CultureInfo("en-US"),
                new CultureInfo("de-DE"),
                new CultureInfo("ja-JP")
            };

            var data = new[]
            {
                "2020-05-06T12:30:30.000000+02:00",
                "05/03/2021",
                "November 10, 2021",
                "March 2021",
                "15-11-2021 09:15 AM"
            };

            foreach (var culture in cultures)
            {
                foreach (var dateEntry in data)
                {
                    // Culturally specific - culture
                    // AdjustToUniversal - UTC time. 
                    Console.WriteLine(DateTime.TryParse(dateEntry, culture, DateTimeStyles.AdjustToUniversal, out var parsedDateResult)
                        ? $"{parsedDateResult:F}" : "skipped");

                }
            }

            var cultureUS = new CultureInfo("en-US");

            Console.WriteLine("Parse dates en-US culture exact: ");
            foreach (var dateEntry in data)
            {
                // DateTimeOffset - Point in time in UTC. 
                // Use TryParseExact for exact DateTime formats
                // "o" - round trip formatte date time. ISO8601 round-trip formatted dates
                // Culture specific - determines parsing rules. 
                // No DateTimeStyles
                Console.WriteLine(DateTimeOffset.TryParseExact(dateEntry, "o", cultureUS, DateTimeStyles.None, out var parsedDateResult)
                    ? $"{parsedDateResult.AddDays(10):F}" : "skipped");

            }
        }
    }
}