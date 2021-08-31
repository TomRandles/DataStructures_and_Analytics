using System;
using System.Text.RegularExpressions;

namespace String_Manipulation
{
    internal class Search
    {


        internal static void SearchingStrings()
        {
            // Common operation
            // Identify the existence of or position of text within a string
            // Search for a matching sequence of characters.
            // Search for a pattern of characters

            var data = new[]
            {
                "Make: Ford, Model: Fiesta",
                "make: Punto",
                "Ferrari f40, car",
                "1. ford"
            };

            foreach (var entry in data)
            {
                Console.WriteLine(entry);

                // Case sensitive, ordinal search the default
                // Ordinal appropriate here – not presenting to end user.
                // Best practice – always provide an explicit StringComparison mode enum
                // No ambiguity 
                var isFord = entry.Contains("Ford", StringComparison.Ordinal);
                Console.WriteLine(isFord ? "CONTAINS Ford" : "DOES NOT CONTAIN Ford");

                // Case insensitive
                isFord = entry.Contains("Ford", StringComparison.OrdinalIgnoreCase);
                Console.WriteLine(isFord ? "CONTAINS Ford (Ignore case)" :
                    "DOES NOT CONTAIN Ford (Ignore case)");
                // Warning: StartsWith and EndsWidth default to case sensitive and culture 
                // sensitive comparison
                var isValid = entry.StartsWith("make:", StringComparison.OrdinalIgnoreCase);
                Console.WriteLine(isValid ? "IS valid" : "IS NOT valid");

                var containsComma = entry.Contains(',', StringComparison.Ordinal);
                Console.WriteLine(containsComma ? "HAS comma" : "DOES NOT have comma");
                Console.WriteLine();

            }
            Console.WriteLine();
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
        }
        internal static void SearchingWithRegularExpressions()
        {
            // Search for Patterns using Regular Expressions
            Console.Clear();

            var data = new[]
            {
                "Make: Ford, Model: Fiesta",
                "make: Punto",
                "Ferrari f40, car",
                "1. ford"
            };

            const string startsWithPattern = "^[A-Za-z]";
            const string matchPattern = ": (\\w+),";
            // a-zA-Z0-9_    + stands for: 1 or more characters

            foreach (var entry in data)
            {
                Console.WriteLine(entry);

                // Match string against RE
                var match = Regex.Match(entry, startsWithPattern);
                Console.WriteLine(match.Success ? "STARTS with text" :
                                                  "DOES NOT START with text");

                match = Regex.Match(entry, matchPattern);
                Console.WriteLine(match.Success ? "VALID" : "NOT VALID");

                Console.WriteLine();
            }

            // Regular Expression – Sequence of Characters that define a pattern
            // Characters can be literal characters or meta characters with special meaning
            // Search within strings for a matching pattern

            // Https://docs.microsoft.com/en-us/dotnet/standard/base-types/regular-expression-languange-quick-reference
            // String literal can represent a regular expression.
            Console.WriteLine();
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
        }
        internal static void SearchingWithReadonlySpan()
        {
            // Searching with ReadOnlySpan

            // Advanced searching technique – Span<T> and ReadOnlySpan<T>
            // Search within strings.
            // Note: advanced topic and not common in C# code bases
            // Introduced in C# 7.2.
            // Reference System.Memory in NetStandard 1.0
            // Read - write access to contiguous memory.
            // Managed heap
            // Stack
            // Unmanaged memory location
            // String – uses a contiguous block of memory on the heap.
            // Cannot use a span < T > on a string.Strings are immutable and span<T> is a read - write type.
            // Use ReadOnlySpan < T > instead to work with strings – read - only view of in-memory data
            // Spans advantage – inspecting and parsing data with zero allocations.
            // Optimized for high performance scenarios.Avoid consuming heap memory.Avoids overhead

            var data = new[]
            {
                "Make: Ford, Model: Fiesta",
                "make: Punto",
                "Ferrari f40, car",
                "1. ford"
            };

            // ReadOnlySpan of Characters. Can cast array of characters to span
            // Array also contiguous memory 
            ReadOnlySpan<char> makeSpan = new[] { 'm', 'a', 'k', 'e' };

            foreach (var entry in data)
            {
                Console.WriteLine(entry);

                // Process each string from the data array
                // Use span based techniques, create a read-only span over the strings 
                // memory. entrySpan is of type ReadOnlySpan<char>
                var entrySpan = entry.AsSpan();

                // Use this view over each string’s memory and compare it to our 
                // makeSpan
                // Valid – expect the word “make” to appear in the entrySpan variable
                // First, need to Slice into entrySpan’s first 4 characters.
                // Produces new span – First 4 characters
                // Second, compare resulting characters sequence with makeSpan 
                // SequenceEqual – case sensitive and ordinal methods.    
                var isValid = entrySpan.Slice(0,
                                             makeSpan.Length).SequenceEqual(makeSpan);
                Console.WriteLine(isValid ? "VALID" : "INVALID");

                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
        }
        internal static void SearchStringsLocatingWithIndexOf()
        {
            // Locating where text appears within a string
            // IndexOf – identify the position of a character or a sequence of characters within a string.
            // NB: Zero based numbering.
            var data = new[]
            {
                "Make: Ford, Model: Fiesta",
                "make: Punto",
                "Ferrari f40, car",
                "1. ford"
            };

            foreach (var entry in data)
            {
                Console.WriteLine(entry);

                var colonPosition = entry.IndexOf(':', StringComparison.Ordinal);
                Console.WriteLine("First colon: " + colonPosition);

                var startAt = colonPosition + 1;
                // Find next colon’s position
                colonPosition = entry.IndexOf(':', startAt, entry.Length - startAt);
                Console.WriteLine("Next colon: " + colonPosition);

                // Work backwards through the string. Reverse order. 
                colonPosition = entry.LastIndexOf(':');
                Console.WriteLine("Last colon: " + colonPosition);

                // Search for index of a set of characters
                // Match any of the entries and an index will be returned. 
                // Ordinal comparisons only
                var colonCommaPosition = entry.IndexOfAny(new[] { ',', ':' });
                Console.WriteLine("Colon/comma: " + colonCommaPosition);

                // Search for the position of a string.   
                var modelPosition = entry.IndexOf("model",
                                                  StringComparison.OrdinalIgnoreCase);
                Console.WriteLine("model: " + modelPosition);

                Console.WriteLine();
            }

            // -1 Negative return – no match was found
            Console.WriteLine();
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
        }
    }
}