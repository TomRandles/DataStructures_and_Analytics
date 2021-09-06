using System;
using System.Collections.Generic;
using System.Globalization;

namespace String_Manipulation
{
    internal class CompositeFormatting
    {
        internal static void CompositeFormattingDemoOne()
        {
            Console.Clear();

            Console.Write("What is your first name? ");
            var firstName = Console.ReadLine();

            Console.Write("What is your last name? ");
            var lastName = Console.ReadLine();

            // Composite formatting
            // Takes a composite format string - "Hello {0] {1}"
            // Followed by one or more objects that contribute to the final string.
            // Mixture of literal text and placeholders called format items - {0} {1}
            // corresponding to subsequent argument objects
            // NB: indexing position important.
            // String interpolation (C# 6) has superseded string formatting in this manner
            var finalWelcome = string.Format("Hello {0} {1}", firstName, lastName);

            Console.WriteLine(finalWelcome);

            Console.WriteLine();
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
        }

        internal static void CompositeFormattingDemoTwo()
        {
            Console.Clear();

            // Format string Component - control how objects are formatted.
            // Format item syntax {0:d} 
            // 0 - index component 
            // d - optional format string
            // No format string? Defaults to the G format for dates, numbers and enumerations.  

            var cultures = new[] {
                new CultureInfo("en-US"),
                new CultureInfo("de-DE"),
                new CultureInfo("ja-JP")
            };

            Console.Write("What is the price? >> ");
            var priceText = Console.ReadLine();

            if (decimal.TryParse(priceText, out var price))
            {
                foreach (var culture in cultures)
                {
                    // Currency formatting  - C string format. Culturally aware. 
                    var formattedPrice = string.Format(culture, "The price of the car is {0:C}", price);
                    Console.WriteLine(formattedPrice);
                }
            }

            Console.WriteLine();

            var temperature = new Random().NextDouble() * 20;

            foreach (var culture in cultures)
            {
                // Culture added as argument to string.Format method
                // 0 index, d - short datetime format specifier. 
                // 1 index, fixed format specifier with 2 decimal places to represent temperature. 
                // Objects added after string format in correct order.     
                Console.WriteLine(string.Format(culture, "At {0:d}, the temp is {1:F2}°C",
                    DateTime.Now, temperature));
            }

            Console.WriteLine();
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
        }

        internal static void CompositeFormattingDemoThree()
        {
            Console.Clear();

            // Format item syntax
            // {0, 20} 
            // 0 - index component
            // 20 - Alignment component - optional signed integer. Formatted field's preferred width
            // Includes padding if required. 
            // {0,-10} Negative, left aligned, width 10
            // {0,20} Positive, right aligned, width 20
            // Note, alignment format pretty rare.
            var qualifyingTimes = new Dictionary<string, TimeSpan>
            {
                {"Damon Hill", new TimeSpan(0, 0, 1, 26, 875)},
                {"Jacques Villeneuve", new TimeSpan(0, 0, 1, 27, 070)},
                {"Michael Schumacher", new TimeSpan(0, 0, 1, 27, 707)}
            };

            // Cw - supports String.Format() syntax automatically
            Console.WriteLine("{0,-20}{1,10}", "Driver", "Lap time");
            Console.WriteLine();

            foreach (var result in qualifyingTimes)
            {
                // Minutes, seconds, and a 3 portion of the fractional lap time
                Console.WriteLine("{0,-20}{1,10:mm\\:ss\\.fff}", result.Key, result.Value);
            }

            Console.WriteLine();
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
        }
    }
}