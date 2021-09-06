using System;
using System.Globalization;

namespace String_Manipulation
{
    public class StringInsertions
    {
        public static void StringInsertionExample()
        {
            Console.Clear();

            string originalFinalMessage = "Your greeting is !";

            Console.WriteLine("Please enter greeting:");
            var greeting = Console.ReadLine();
            originalFinalMessage.Insert(originalFinalMessage.IndexOf('!'), greeting);

            Console.WriteLine();
            Console.WriteLine("Press a key to continue ...");
            Console.ReadKey();
        }

        public static void StringInterpolationExamples()
        {
            // Introduced in C# 6
            // Recommended for creating formatted short strings. Readable, convenient.
            // A string literal with 0 or more interpolation expressions
            // Resolved at runtime to a resolved string.
            // Expressions are replaced with their result. 
            // Identified by the $ character. 
            // String interpolation - no longer need to provide object arguments, avoiding mistakes and making
            // the code more readable. Expressions appear at the correct location. 

            var temperature = new Random().NextDouble() * 20;

            // Short date format - d. temperature variable to 2 decimal places.  
            Console.WriteLine($"At {DateTime.Now:d} the temperature is {temperature:F2}°C");
            Console.WriteLine();

            var cultures = new[] {
                new CultureInfo("en-US"),
                new CultureInfo("de-DE"),
                new CultureInfo("ja-JP")
            };

            // Default - application uses the default culture when formatting the items.
            // To implicitly use interpolation in a culturally aware manner, the interpolated string can be cast to a 
            // FormattableString type object - represents a composite format string along with its arguments to be formatted.
            FormattableString formattableString = $"At {DateTime.Now:d} the temperature is {temperature:F2}°C";

            foreach (var culture in cultures)
            {
                Console.WriteLine(formattableString.ToString(culture));
            }

            // Best practices - use string interpolation vs composite formatting.
            // Avoids the risk of mis-ordering arguments.
            // Readable code produced. 

            Console.WriteLine();
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
        }
    }
}