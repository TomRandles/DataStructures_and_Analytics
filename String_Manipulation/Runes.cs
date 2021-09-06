using System;
using System.Globalization;

namespace String_Manipulation
{
    public class Runes
    {
        public static void RunesDemo()
        {
            Console.Clear();

            // VS Studio does not actually present this rune properly
            // Is actually a grapheme cluster of 4 scalar values, that is, 4 runes. 
            var input = "👩🏽‍🚒";
            Console.WriteLine($"Analysis of: {input}");

            Console.WriteLine();
            Console.WriteLine("Chars:");

            var counter = 0;
            foreach (var character in input)
            {
                counter++;
                // This is a grapheme cluster, consisting of emoji surrogate pairs, these do not print out properly.
                Console.WriteLine(character);
            }
            // 7 characters in total required for representation of the text element.
            Console.WriteLine($"Total chars: {counter}");

            Console.WriteLine();
            Console.WriteLine("Runes:");

            counter = 0;
            // Iterate through the runes
            foreach (var rune in input.EnumerateRunes())
            {
                // 
                counter++;
                Console.WriteLine(rune);
            }
            // 4 Runes make up this element. 
            // Grapheme cluster is a woman firefighter - this iteration displays the component rune parts.

            Console.WriteLine($"Total runes: {counter}");

            Console.WriteLine();
            var stringInfo = new StringInfo(input);
            // One text element present, that is, one grapheme cluster.  
            Console.WriteLine($"Total text elements: {stringInfo.LengthInTextElements}");

            Console.WriteLine();
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
        }
    }
}
