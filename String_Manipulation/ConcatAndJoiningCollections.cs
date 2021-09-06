using System;

namespace String_Manipulation
{
    public class ConcatAndJoiningCollections
    {
        public static void StringConcatAndJoinExamples()
        {
            Console.Clear();

            var words = new string[5];
            Console.WriteLine("Provide 5 words:");

            for (var i = 0; i < words.Length; i++)
            {
                Console.Write(">> ");
                words[i] = Console.ReadLine();
            }
            Console.WriteLine();

            var finalSentence = string.Empty;
            foreach (var word in words)
            {
                finalSentence = finalSentence + word;
            }

            Console.WriteLine(finalSentence);
            Console.WriteLine();
            Console.WriteLine(string.Concat(words));
            Console.WriteLine();
            Console.WriteLine(string.Join(' ', words));
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
        }
    }
}