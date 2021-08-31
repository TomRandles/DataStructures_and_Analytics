using System;

namespace String_Manipulation
{
    internal class StringAndCharTypes
    {

        public static void IntroStringAndCharTypes()
        {
            // Strings and Arrays in .Net – have a variable size in memory.
            // Assigned using string literals – sequence of characters in ""
            String name = "Tom";
            Console.WriteLine(name);
            // or string – an alias to String
            // Use keyword string var – implicit typing
            // Intern pool
            // The.Net CLR maintains a table called the intern pool, containing a reference to each unique
            // string literal declared programmatically in the code.
            // Can assign null to a string.
            // Better to have an empty string. String.empty
            // Const – cannot update a local variable to have a different value. 
            string hello = "He said \"Hello\"";
            Console.WriteLine(hello);
            string dir = "c:\\home\\";
            Console.WriteLine(dir);
            string stringLiteralDir = @"c:\home\";
            Console.WriteLine(stringLiteralDir);
            string helloWithQuotes = @"He said ""Hello""";
            Console.WriteLine(helloWithQuotes);

            // Declaring and initialising Chars
            char firstChar = 'A';
            var secondChar = 'B';
            const char thirdChar = 'C';
            // Cannot be assigned to null – is a value type(struct).
            // Does have a default
            // char myChar = default; // Defaults to '\0'  - Null character code zero
            var characters = new[] { 'c', 'h', 'a', 'r', 's' };
            var charString = new string(characters); // valid use of string constructor

            // write an underlying string, based on length of header
            string title = "This is the title";
            string underline = new string('_', title.Length);

            char letterH = '\u0048'; // Unicode sequence for H
            char letterH2 = '\x0048'; // Hex representation
            char letterH3 = (char)72; // cast from decimal value for H

            var charactersAlso = new[] { 'c', 'h', 'a', 'r', 's' };
            var charString2 = new string(charactersAlso); // valid use of string constructor

            // write an underlying string, based on length of header
            string title2 = "This is the title";
            string underline2 = new string('_', title.Length);
            foreach (var character in characters)
            {
                if (char.IsLetter(character))
                    Console.Write("letter |");

                if (char.IsDigit(character))
                    Console.Write("digit |");

                if (char.IsWhiteSpace(character))
                    Console.Write("whitespace |");

                if (char.IsPunctuation(character))
                    Console.Write("punctuation |");

                if (char.IsSeparator(character))
                    Console.Write("separator |");
            }

            // String - best practices 1
            // Use lowercase string keyword
            // Use string.Empty instead of "" or null
            // Avoid null if at all possible. 
            // Prefer const fields rather than string literals. 
            // Use the char key word rather than the char type

            Console.WriteLine();
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
        }
    }
}