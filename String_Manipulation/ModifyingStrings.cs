using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace String_Manipulation
{
    public class ModifyingStrings
    {
        public static void SplittingStringExample()
        {
            var inputParagraph = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut " +
                                 "labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris " +
                                 "nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit " +
                                 "esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in " +
                                 "culpa qui officia deserunt mollit anim id est laborum.";

            // Break into sentences
            var counter = 0;

            var sentencesArray = inputParagraph.Split('.', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries); 
            foreach (var sentence in sentencesArray)
            {
                counter++;
                Console.WriteLine($"Sentence {counter}: {sentence}.");

            }

            var stringInputTwo = "adslkfa;WOEIRWEIFWEIOF,rrigirjoier322342|fkdgporpg,ergergeregerger";
            foreach (var portion in stringInputTwo.Split(',', '|', ';'))
            {
                Console.WriteLine($"Portion: {portion}");
            }
        }

        public static void SplittingStringsWithRegEx()
        {

            var ipData = new[]
            {
                "192.168.05.03",
                "127.0.0.1",
                "435 555 55"
            };


            // Validate IP addresses
            // Split them out into their component parts - IP v4 address pattern
            // Parenthesis capture the source string. 
            var ipPattern = "^([0-9]{1,3})\\.([0-9]{1,3})\\.([0-9]{1,3})\\.([0-9]{1,3})$";
            var regularExpEngine = new Regex(ipPattern);

            foreach (var IPAddress in ipData)
            {
                var ipAddressOctets = Regex.Split(IPAddress, ipPattern);
                foreach (var addressOctet in ipAddressOctets)
                {
                    Console.WriteLine(addressOctet);
                }
            }
        }

        public static void ExtractingSubstringExamples()
        {
            var crData = new[]
            {
                "Make: Ferrari",
                "Model: 488",
                "Engine: Twin-Turbo 3.9L V8.",
                "Top Speed: 205 mph."
            };
            foreach (var entry in crData)
            {
                var colonPos = entry.IndexOf(':', StringComparison.Ordinal);
                var startPos = colonPos + 2;
                // C# v8 - ^1 operator - begin at the end of the index. Help to get the last character.  
                var endPos = entry[^1] == '.' ? entry.Length - 1 : entry.Length; 

                if (entry.Length > startPos)
                {
                    Console.WriteLine($"{entry.Substring(0,colonPos)} : {entry.Substring(startPos, endPos)}");
                }
            }
        }

        public static void ChangingCaseExamples()
        {
            const string myName = "Tom Randles";
            // To upper - culture independent - invariant. 
            Console.WriteLine(myName.ToUpper(CultureInfo.InvariantCulture));
            //or
            Console.WriteLine(myName.ToUpperInvariant());
            // To lower - culture independent - invariant. 
            Console.WriteLine(myName.ToLower(CultureInfo.InvariantCulture));
            //or
            Console.WriteLine(myName.ToLowerInvariant());

            // Case and char
            const char myFirstInitial = 't';

            Console.WriteLine(char.ToUpperInvariant(myFirstInitial));
            Console.WriteLine(char.ToLowerInvariant(myFirstInitial));

            // JSON name for a property
            // Convert to suitable C# equivalent. 
            string jsonName = "sports_car_manufacturer";

            // Create a culture text info - writing system associated with the culture. 
            var textInfo = new CultureInfo("en-GB", false).TextInfo;

            // Converts words in argument to title case. 
            var intermediateName = textInfo.ToTitleCase(jsonName);
            Console.WriteLine(intermediateName.Replace("_", string.Empty));

            var sentence = "This is a really short sentence.";

            // Change the first character of every word to upper case
            Console.WriteLine(textInfo.ToTitleCase(sentence));
        }
    }
}