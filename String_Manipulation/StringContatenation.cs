using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_Manipulation
{
    internal class StringContatenation
    {
        internal static void ConcatenatingStringsUsingOperators()
        {
            Console.Clear();

            var welcome = "Hello ";

            Console.Write("What is your first name? ");
            var firstName = Console.ReadLine();

            Console.Write("What is your last name? ");
            var lastName = Console.ReadLine();

            // Strings are immutable. Operations will need to create new instances. 
            // May have performance implications
            var finalWelcome = welcome + firstName + " " + lastName;
            welcome += firstName + " " + lastName;

            // Split across multiple lines
            // String literals evaluated at compile time rather than runtime.
            // Effectively a single string literal

            var literalWelcome = "Hello" +
                                 " " +
                                 "Steve";

            Console.WriteLine(finalWelcome);
            Console.WriteLine(welcome);

            Console.WriteLine();
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
        }
    }
}
