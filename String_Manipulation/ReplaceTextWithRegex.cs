using System.Text.RegularExpressions;

namespace String_Manipulation
{
    public class ReplaceTextWithRegex
    {
        public static void ReplaceTextWithRegexExercises()
        {
            // Pattern based string manipulation
            // Need to standardise this inconsistent data. 
            var data = new[]
            {
                "1. Joe Bloggs",
                "Sean Citizen",
                "5. Harry McGuire",
                "10. Manny Pacquoi"
            };

            var pattern = "[0-9]{1,2}\\. ?";

            foreach (var entry in data)
            {
                // Replace the component of the string that matches the pattern with the replacement string - string.Empty
                System.Console.WriteLine(Regex.Replace(entry, pattern, string.Empty));
            }
        }
    }
}