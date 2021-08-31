using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_Manipulation
{
    internal class FormattingGuids
    {
        internal static void FormattingGuidsAsStrings()
        {
            // GUIDs - Global Unique Identifiers
            // Large enough so that they are guaranteed to be unique
            // when generated randomally
            // 128 bit integer
            // Often represented in text format
            Console.Clear();

            var guid = Guid.NewGuid();

            // Default - 32 digits separated by hyphens. Most used.
            Console.WriteLine(guid.ToString());
            // D - 32 digits separated by hyphens
            Console.WriteLine(guid.ToString("D"));
            // N - 32 digits with no hyphens
            Console.WriteLine(guid.ToString("N"));
            // B - Include hyphens, enclose in braces
            Console.WriteLine(guid.ToString("B"));
            // P - Include hyphens, enclose in parenthes
            Console.WriteLine(guid.ToString("P"));
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
        }
    }
}
