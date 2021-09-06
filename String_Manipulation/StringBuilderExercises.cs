using Microsoft.Extensions.ObjectPool;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace String_Manipulation
{
    public class StringBuilderExercises
    {
        public static void GettingStartedWithStringBuilder()
        {
            // Use string builder to concatenate several strings efficiently.k
            // String Builder
            // Modify text data without allocating additional string objects. 
            // Provides a way to work with a mutable sequence of characters. 
            // Improve performance when concatenating many strings, such as with unbounded
            // loops.

            var data = FakeAPICall();

            StringBuilder sb = new StringBuilder();
            // String builders internal character buffers can be mutated.
            foreach (var l in data)
            {
                sb.Append(l);
            }
            sb.Append("More text here - finalising!").Append($"Finished at {DateTime.Now:d}");

            // StringBuilder details 
            // Provides a way to mutate text internally
            // Maintains an internal buffer of characters 
            // Can grow by referencing a new StringBuilder with an increased (doubled) buffer capacity

            Console.WriteLine(sb.ToString());
            // Traverses through the linked list of string builders to return the final string from
            // the occupied characters in all chunks. 

            // StringBuilder.MaxCapacity = 256;
            // Can set internal char array size at construction
            var longString = new StringBuilder(2048);
            

        }
        public static void ConfiguringAStringBuilder()
        {
            // Configure sb via its constructor and via its properties

            // Providing capacity up front
            var newStringBuilder = new StringBuilder("Initial string", 1024);

            //or
            var sentence = "This is a new sencence";
            var newStringBuilder2 = new StringBuilder(sentence, sentence.Length * 11);
            for (var i=0; i<10;i++)
            {
                newStringBuilder2.Append(sentence);
            }
            
            Console.WriteLine($"StringBuilder example length {newStringBuilder2.Length}, capacity: {newStringBuilder2.Capacity}");

            // Can optimize a string builder's use. Avoid growing its capacity too often by linking new string builders

            // Ensure capacity - make sure program has sufficient space in sb for the task at hand.
            newStringBuilder2.EnsureCapacity(newStringBuilder2.Length * 41);

            // Using Max capacity - in memory constrained environments. 
            // 256 - initial capacity
            // Can grow to 2048
            var stringBuilder3 = new StringBuilder(256, 2048);
        }

        public static void StringBuilderRemoveAndAppendLine()
        {
            var sb = new StringBuilder();
            string inputString;
            while ((inputString = Console.ReadLine()) != "Exit")
            {
                sb.Append(inputString).Append(',');
            }
            // Remove last comma.
            sb.Remove(sb.Length - 1, 1);
            //Append a line - default line terminator
            sb.AppendLine();
            sb.Append("Some more text");
            Console.WriteLine(sb.ToString());

            // Removes all characters from the StringBuilder instance
            // Note: worth reusing a single StringBuilder instance
            sb.Clear();

            var temperature = new Random().NextDouble() * 20;

            var cultures = new []
            {
                new CultureInfo("en-US"),
                new CultureInfo("de-DE"),
                new CultureInfo("ja-JP")
            };

            foreach (var culture in cultures)
            {
                // Format directly into the string builder
                // Append the string returned by the processing of the composite format string containing one or more
                // format items
                sb.AppendFormat(culture, "At {0,d}, the temperature is: {0:F2}", DateTime.Now, temperature);
                sb.AppendLine();
            }
            Console.WriteLine(sb.ToString());

            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        public static void WorkingWithStringBuilders()
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmopqrstuvwxyz";

            //Generate an array of 25 random strings.
            var myArray = new string[25];
            for (var i=0; i<25; i++)
            {
                myArray[i] = new string(Enumerable.Range(1, random.Next(5, 10))
                    .Select(_ => chars[random.Next(chars.Length)]).ToArray());
            }
            var sb = new StringBuilder("StringBuilder with random words");
            sb.AppendLine();

            foreach (var entry in myArray)
            {
                sb.Append(entry).Append(',');
            }
            sb.Remove(sb.Length - 1, 1);

            Console.WriteLine(sb.ToString());

            // Replace ',' with '|'
            sb.Replace(',', '|');

            //Insert text into StringBuilder instance
            sb.Insert(0, "Here is a new sentence at the start of StringBuilder instance");

            Console.WriteLine();
            Console.WriteLine(sb.ToString());

        }

        // ObjectPool - should be a singleton in the .Net application
        // Could use DI to achieve this. 
        // Here, will use a static pool to hold a single ObjectPool instance
        private static readonly ObjectPool<StringBuilder> DemoObjectPool = 
            new DefaultObjectPoolProvider().CreateStringBuilderPool();
        public static void StringBuilderAndObjectPool()
        {
            Console.Clear();

            // Get a StringBuilder instance from the Object Pool
            // Receive an existing, unused StringBuilder if one exists in the pool.
            // Otherwise, a new StringBuilder instance is created and made available
            var sbPooled = DemoObjectPool.Get();

            // Use try finally pattern with pooled StringBuilder
            try
            {
                // Use StringBuilder as normal
                sbPooled.Append("This is the first sentence to go on the pooled StringBuilder");
            }
            finally
            {
                // Return StringBuilder to the Object Pool
                DemoObjectPool.Return(sbPooled);
            }

            // NB-Warning: pooling instances requires memory to be occupied for the life of the
            // application. The StringBuilder instances are never released. 
            // This can result in unsatisfactory overhead if the pooled items are used infrequently.
            // Limit the size of the pool to control this. 
            // Consider also limiting the maximum number of items that are pooled at any one time.
            // Prove that the pool provides expected improvement by benchmarking and profiling the 
            // code under realistic workloads.
        }

        private static IEnumerable<string> FakeAPICall()
        {
            return new List<string>
            {
                "This is the first string",
                "This is the second string",
                "This is the third string",
                "This is the fourth string",
                "This is the fifth string"
            };            
        }
    }
}