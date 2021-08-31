using System;
using System.Globalization;
using System.Threading;

namespace String_Manipulation
{
    internal class Equality
    {

        public static void StringEquality()
        {
            // String Equality
            var helloWorld = "Hello World!";
            var helloWorldLower = "hello world!";

            // Equals uses a case sensitive ordinal. Result: false
            Console.WriteLine(helloWorld.Equals(helloWorldLower));

            // Same as default above. Should use this approach - best practice. 
            // Result: false
            Console.WriteLine(
                helloWorld.Equals(helloWorldLower, StringComparison.Ordinal));

            // Equal – ignore case 
            Console.WriteLine(
              helloWorld.Equals(helloWorldLower, StringComparison.OrdinalIgnoreCase));


            // Note: String literals – added to the intern pool.
            // Repeated string literals reference the same string instance. 
            // Performance considerations – applies to equality checks.
            // Same string literal comparison will involve a reference check, not the character content to confirm their value equality. 

            // Cultural differences for Equality


            var initialCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = new CultureInfo("de-DE");

            Console.WriteLine(Thread.CurrentThread.CurrentCulture);

            var footballOne = "fussball";
            // ß – represents ss. 
            var footballTwo = "fußball";
            // Unicode for ß – \u00DF 
            var footballThree = "fu\u00DFball";

            // Windows 10 – .Net 5 ICU APIs in use for the cultural information 

            // Returns False – ordinal check. Unicode characters different.
            Console.WriteLine(footballOne.Equals(footballTwo));
            // Returns False -      
            Console.WriteLine(
                footballOne.Equals(footballTwo, StringComparison.CurrentCulture));
            // Returns False  
            Console.WriteLine(
                footballOne.Equals(footballThree, StringComparison.CurrentCulture));

            // Windows 10 – .Net Core 3.1 NLS APIs in use for the cultural information 

            // Returns False – ordinal check. Unicode characters different
            Console.WriteLine(footballOne.Equals(footballTwo));
            // Returns True – ß and ss treated culturally as identical in the NLS APIs
            Console.WriteLine(
                footballOne.Equals(footballTwo, StringComparison.CurrentCulture));
            // Returns True - ß and ss treated culturally as identical in the NLS APIs 
            Console.WriteLine(
                footballOne.Equals(footballThree, StringComparison.CurrentCulture));

            CultureInfo.CurrentCulture = initialCulture; // return culture to original

            Console.WriteLine();
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
        }
        public static void EqualityOperators()
        {
            var helloWorld = "Hello World!";
            var helloWorldLower = "hello world!";
            Console.WriteLine(helloWorld);
            Console.WriteLine(helloWorldLower);
            Console.WriteLine();

            Console.WriteLine(helloWorld == helloWorldLower ? "equal" : "not equal");
            // == equality operator functionally equivalent to calling Equals() with out a string comparison mode.
            // Uses case sensitive ordinal comparison by default.
            // NB: Best practice – use Equals with a specific string comparison mode specified. 

            Console.WriteLine();
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
        }
    }
}