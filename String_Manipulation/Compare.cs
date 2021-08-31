using System;
using System.Threading;

namespace String_Manipulation
{
    internal class Compare
    {
        public static void ComparingStrings()
        {
            // Comparing strings
            // Print current culture – en-US / English(United-States)
            // Set in program class. 

            Console.WriteLine(Thread.CurrentThread.CurrentCulture.Name);
            Console.WriteLine(Thread.CurrentThread.CurrentCulture.DisplayName);

            const string helloOne = "HELLO";
            const string helloTwo = "hello";

            var comparison = helloOne.CompareTo(helloTwo); // returns 1. First string follows the second string in the sort order. 

            comparison = helloTwo.CompareTo(helloOne);  // returns -1 – first string precedes the second string in the sort order. 

            // 0 – strings are equal 
            // Default behaviour – CompareTo() and Compare() methods perform a case sensitive, cultural sensitive, linguistic comparison.

            // Ordinal comparisons – culture insensitive comparisons
            // Use the static string.CompareOrdinal
            const string helloThereOne = "HELLO";
            const string helloThereTwo = "hello";

            comparison = string.CompareOrdinal(helloThereOne, helloThereTwo);
            Console.WriteLine(comparison);

            // Returns -32 – the difference in the Unicode values is offset by 32 
            // Upper case HELLO precedes lower case hello
            // Upper case characters appear first in the Unicode table.

            // Culturl insensitive, case insensitive
            comparison = string.Compare(helloThereOne, helloThereTwo, StringComparison.OrdinalIgnoreCase);
            Console.WriteLine(comparison);
            // Strings are equal. Returns 0. Ignore case – strings are equal

            // Use CurrentCulture comparison
            // First string includes a hyphen
            // Soft hyphens may be treated with special rules in some cultures and affect how strings are sorted. 

            // EN-US culture
            Console.WriteLine("co-operate and cooperate current culture");
            comparison =
                  string.Compare("co-operate", "cooperate", StringComparison.CurrentCulture);
            Console.WriteLine(comparison);
            // Returns -1. First string precedes the second string. Hyphenated word placed before 2nd word

            Console.WriteLine("co-operate and cumulative current culture");
            comparison =
                   string.Compare("co-operate", "cumulative", StringComparison.CurrentCulture);
            Console.WriteLine(comparison);
            // Returns -1. First string precedes the second string. 
            // Hyphenated word placed before 2nd word

            Console.WriteLine("co-operate and code current culture");
            comparison =
                            string.Compare("co-operate", "code", StringComparison.CurrentCulture);
            Console.WriteLine(comparison);
            // Returns -1. First string precedes the second string. 
            // Hyphenated word placed before 2nd word.

            // Use Ordinal comparison
            Console.WriteLine("co-operate and cooperate ordinal");
            comparison = string.Compare("co-operate", "cooperate", StringComparison.Ordinal);
            Console.WriteLine(comparison);
            // Returns -66 (45(decimal unicode value for a hyphen) – 111(Unicode lower case o) = -66). First string precedes the second string. Hyphenated word placed before 2nd word

            Console.WriteLine("co-operate and cumulative ordinal");
            comparison = string.Compare("co-operate", "cumulative", StringComparison.Ordinal);
            Console.WriteLine(comparison);
            // Returns -6.

            Console.WriteLine("co-operate and code current ordinal");
            comparison = string.Compare("co-operate", "code", StringComparison.Ordinal);
            Console.WriteLine(comparison);
            // Returns -55
            // Note: on.Net 5 on Windows 10
            // Runtime uses ICU APIs for culture aware comparisons.

            //            Demo – set NLS instead
            // On Windows powershell:
            // Set - Item - Path Env: DOTNET_SYSTEM_GLOBALIZATION_USENLS - Value =”true”

            // EN-US culture
            Console.WriteLine("co-operate and cooperate current culture");
            comparison =
                  string.Compare("co-operate", "cooperate", StringComparison.CurrentCulture);
            Console.WriteLine(comparison);
            // Returns 1. 

            Console.WriteLine("co-operate and cumulative current culture");
            comparison =
                   string.Compare("co-operate", "cumulative", StringComparison.CurrentCulture);
            Console.WriteLine(comparison);
            // Returns -1. 

            Console.WriteLine("co-operate and code current culture");
            comparison = string.Compare("co-operate", "code", StringComparison.CurrentCulture);
            Console.WriteLine(comparison);
            // Returns 1. 

            // Different results – why?
            // NLS APIs for EN - US treat the hyphen as a soft character and provide less weight than the characters in the sort operation.May be more valid in UI presentations.

            // May want this as the default behaviour.
            Console.WriteLine();
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
        }

        public static void ComparingNullToEmpty()
        {
            // Dealing with strings containing empty or null character.
            Console.WriteLine("Provide a string. Type '--e' to create an empty string or '--n' for a null string");
            Console.WriteLine();
            Console.Write(">> ");
            var input = Console.ReadLine();
            if (input == "--e") input = string.Empty;
            if (input == "--n") input = null;

            Console.WriteLine(input is null ? "Input WAS null" : "Input WAS NOT null");
            // danger ahead
            // Causes NullReferenceException if input is null --n
            Console.WriteLine(input.Equals(string.Empty) ? "Input WAS empty" : "Input WAS NOT empty");
            // Following is safe
            Console.WriteLine(input == string.Empty ? "Input WAS empty" : "Input WAS NOT empty");

            // 
            Console.WriteLine(string.IsNullOrEmpty(input) ?
                "Input WAS null or empty" : "Input WAS NOT null or empty");
            Console.WriteLine(string.IsNullOrWhiteSpace(input) ?
                "Input WAS null, empty or whitespace" : "Input WAS NOT null, empty or whitespace");

            Console.WriteLine();
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
        }
    }
}