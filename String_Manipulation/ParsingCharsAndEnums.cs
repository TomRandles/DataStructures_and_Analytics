using System;

namespace String_Manipulation
{
    public class ParsingCharsAndEnums
    {
        public static void ParsingCharsExercises()
        {
            Console.Clear();

            const string aLetterString = "N";

            Console.Write("A parsed letter: -> ");
            Console.WriteLine(char.TryParse(aLetterString, out var parsedLetter) ? parsedLetter : "skipped" );

            Console.WriteLine("");
            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();
        }

        public static void ParsingEnumsExercises()          
        {
            Console.Clear();

            var data = new[]
            {
                "Monday",
                "December",
                "SATURDAY"
            };

            // Ensure SATURDAY is parsed successfully
            bool ignoreCase = true;
            foreach (var entry in data)
            {
                // 
                Console.Write($"Item -> {entry}");
                Console.WriteLine(Enum.TryParse(typeof(DayOfWeek), entry, ignoreCase, out var parsedEntry) ? (DayOfWeek)parsedEntry : "not matched");
            }

            Console.WriteLine("");
            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();
        }
    }
}