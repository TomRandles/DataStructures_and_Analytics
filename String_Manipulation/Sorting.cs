using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace String_Manipulation
{
    internal class Sorting
    {

        public static void StringSorting()
        {
            // 4.Sorting Strings
            var strings = new[]
            {
                "banana",
                "apple",
                "Lemon",
                "Apple",
                "grapes",
                "Banana",
                "lemon",
                "Grapes",
                ".grapes"
            };

            var initialCulture = CultureInfo.CurrentCulture;
            Console.WriteLine("Default:");
            // Use LINQ – OrderBy()
            var sorted = strings.OrderBy(s => s);
            foreach (var s in sorted)
            {
                // Uses current culture – EN-US
                // Alphebetically, lower case preceding title case.   
                // Basic compare methods 
                //  
                Console.WriteLine(s);
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Ordinal:");
            // Ordinal. Uppercase chars appear first. 
            // Upper case chars have a lower UniCode value, and so appear first
            // . Period char is even lower in UniCode – appears first.      
            sorted = strings.OrderBy(s => s, StringComparer.Ordinal);
            foreach (var s in sorted)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();
            Console.WriteLine();

            // Ordinal ignore case. 
            // lower case appear first 
            // Except for Lemon
            // Upper case Lemon appeared before lemon in the original array.
            // Don’t care about case, so left as is – has not been reordered.  
            Console.WriteLine("OrdinalIgnoreCase:");
            sorted = strings.OrderBy(s => s, StringComparer.OrdinalIgnoreCase);
            foreach (var s in sorted)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("en-GB ignore symbols:");

            // Get full control over string comparison
            // Create our own string comparer
            // Provide a different culture for the string comparer.
            // Differs from the current culture.

            // Note that CompareOptions.IgnoreSymbols – deals with problematic period char. 
            var sc =
            StringComparer.Create(new CultureInfo("en-GB"), CompareOptions.IgnoreSymbols);
            // Pass string comparer to order by
            sorted = strings.OrderBy(s => s, sc);
            foreach (var s in sorted)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Array.Sort");
            // Non LINQ approach use the Array.Sort method.   
            Array.Sort(strings, sc);
            foreach (var s in strings)
            {
                Console.WriteLine(s);
            }

            // Note: Custom string comparers – a great way to take granular control of how string comparisons take place.

            // Cultural differences when sorting
            // Sorting US and British English is quite straight forward.
            // What about cultures that include Diacritics and additional characters in their alphabets?

            // Includes special character æ – appears after z in Danish alphabet	
            var stringsNew = new SortedSet<string> { "brug", "æbler" };
            // Print using EN-US current culture
            Console.WriteLine(Thread.CurrentThread.CurrentCulture);
            foreach (var s in stringsNew)
            {
                // Assumes that the æ char comes first. 
                // Maybe correct to an untrained eye   
                Console.WriteLine(s);
            }
            Console.WriteLine();

            // Use new comparer designed for Danish culture
            // Don’t need compare options
            var comparerNew =
                StringComparer.Create(new CultureInfo("da-DK"), CompareOptions.None);
            stringsNew = new SortedSet<string>(comparerNew) { "brug", "æbler" };

            Console.WriteLine(Thread.CurrentThread.CurrentCulture);
            foreach (var s in strings)
            {
                // New custom comparer knows that the æ char comes after z.
                // sorts accordingly. 
                Console.WriteLine(s);
            }
            Console.WriteLine();

            // Set culture to Danish culture – applies to all 
            // further sortings/comparisons
            CultureInfo.CurrentCulture = new CultureInfo("da-DK");
            // Uses current culture by default
            stringsNew = new SortedSet<string> { "brug", "æbler" };

            Console.WriteLine(Thread.CurrentThread.CurrentCulture);
            foreach (var s in strings)
            {
                // Sorts with Danish alphabet insight – current culture
                Console.WriteLine(s);
            }

            // Return culture to initial value – EN-US
            CultureInfo.CurrentCulture = initialCulture;

            Console.WriteLine();
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
        }
    }
}