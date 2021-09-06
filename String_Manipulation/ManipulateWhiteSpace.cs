namespace String_Manipulation
{
    public class ManipulateWhiteSpace
    {
        public static void MiscWhiteSpaceExercises()
        {
            var myString = "  This is a sentence with plenty of white space . ";

            // trim string - removes leading and trailing white spaces. 
            var newString1 = myString.Trim();
            //or
            newString1 = myString.TrimStart();
            var newString2 = newString1.TrimEnd();

            var line = "/// This is a code comment";
            var charsToTrim = new [] { '/', ' '};

            var trimmedLine = line.Trim(charsToTrim);

            System.Console.WriteLine(trimmedLine);

            // Padding
            var data = new[] { "Cat", "Dog", "Mouse", "Frog" };

            foreach (var entry in data)
            {
                // Write aligned within a 15 character wide column
                System.Console.WriteLine(entry.PadLeft(15, ' '));
            }

        }
    }
}
