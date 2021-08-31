using System;
using System.Globalization;

namespace String_Manipulation
{
    internal class FormatNumeric
    {
        internal static void FormatNumericValuesAsStrings()
        {
            // Formatting overloads
            // ToString()
            // ToString(string? format)
            // ToString(IFormatProvider? formatProvider)
            // ToString (string? format, IFormatProvider? formatProvider);

            // Numerical value types accept a format string as part of their ToString() method overload
            // Numerical Format String[FormatSpecifier][PrecisionSpecifier]

            // [FormatSpecifier]
            // Single alphabetical character used to determine the format of the number.
            // [PrecisionSpecifier]
            // Is an optional integer that controls the number of digits in the formatted string.

            var cultures = new[] {
                new CultureInfo("en-US"),
                new CultureInfo("de-DE"),
                new CultureInfo("ja-JP")
            };

            var price = 1889.86159m;

            Console.WriteLine("Default formatting:");
            Console.WriteLine(price.ToString());
            Console.WriteLine();

            foreach (var culture in cultures)
            {
                Console.WriteLine(culture);
                // Pass culture to use in ToString output 
                Console.WriteLine(price.ToString(culture));
                // Include format string. C – Currency representation of numeric 
                // value.  
                Console.WriteLine(price.ToString("C", culture));
                // Format string – F – fixed point. 3 decimal places.
                Console.WriteLine(price.ToString("F3", culture));
                // Format string – N – produces a grouped separator – 1,000,000 with 1 
                // decimal place.
                Console.WriteLine(price.ToString("N1", culture));
                Console.WriteLine();
            }

            // control how numbers are formatted.

            //     o Currency symbol
            //     o Group separator symbol
            //     o Decimal symbol
            //     o Positive and negative signs

            // Double containing a fractional value
            var percent = .2569;
            foreach (var culture in cultures)
            {
                Console.WriteLine(culture);
                // Format string – P - percentage  
                Console.WriteLine(percent.ToString("P", culture));
                Console.WriteLine();
            }

            // Call the ToString() method directly on the numeric literal. 
            // Format string D – Decimal digit. 8 digits – integer only. 
            // Pads with leading 000 if required.
            Console.WriteLine(15988.ToString("D8"));
            Console.WriteLine();

            var temps = new[] { 31.25, -5.1, 0.0 };
            foreach (var temp in temps)
            {
                // Temperature data formatting. 
                // Digit placeholder 
                // #.# Any significant digits on the LHS of the decimal separator.
                // A single decimal digit after the decimal separator
                // Numeric formatting – can provide up to 3 distinct format strings.
                // Positive numeric, negative numeric, zero value
                // Includes literal text    
                Console.WriteLine(temp
                    .ToString("#.# 'degrees Celsius';#.# 'degrees below zero';'Freezing'"));
            }

            Console.WriteLine();
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
        }
    }
}