using System;
using System.Globalization;

namespace String_Manipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Comprehensive C# String Manipulation overview");

            StringAndCharTypes.IntroStringAndCharTypes();

            Compare.ComparingStrings();

            Sorting.StringSorting();

            Equality.StringEquality();

            Equality.EqualityOperators();

            Compare.ComparingNullToEmpty();

            Search.SearchingStrings();

            Search.SearchStringsLocatingWithIndexOf();

            Search.SearchingWithRegularExpressions();

            Search.SearchingWithReadonlySpan();

            FormatNumeric.FormatNumericValuesAsStrings();

            FormatDateTime.FormatDateTimeValuesAsStrings();

            FormatEnums.FormatEnumsAsStrings();
        }
    }
}