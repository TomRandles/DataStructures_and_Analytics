using System;

namespace String_Manipulation
{
    public class FormatEnums
    {
        public enum Status { Red = 1, Yellow = 2, Green = 3 }
        public static void FormatEnumsAsStrings()
        {
            Console.Clear();

            var status = Status.Yellow;

            Console.WriteLine(status.ToString());
            Console.WriteLine(status.ToString("G"));
            Console.WriteLine(status.ToString("D"));
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
        }
    }
}