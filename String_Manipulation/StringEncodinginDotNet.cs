using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_Manipulation
{
    public class StringEncodinginDotNet
    {
        public static void EncodingStringsAsASCII()
        {
            Console.Clear();

            var input = "Some text to encode";
            Console.WriteLine();
            Console.WriteLine();

            // Get byte count to use for encoding. 
            var byteLength = Encoding.ASCII.GetByteCount(input);
            Console.WriteLine($"Input string char length: {input.Length} ");
            Console.WriteLine($"Byte count for encoding of \"{input}\" is: {byteLength} ");
            Console.WriteLine();

            var data = new byte[byteLength];
            // ASCII encode the input and store in the data array
            Encoding.ASCII.GetBytes(input, data);
            Console.Write("Encoded bytes: ");
            // Visualise the hexadecimal representation of the byte array
            Console.WriteLine(BitConverter.ToString(data));
            Console.WriteLine();
            // Decode string
            var decodedString = Encoding.ASCII.GetString(data);


        }

        public static void EncodingStringsAsUTF8()
        {
            Console.Clear();

            var input = "Some text which includes an emoji 🔥";
            Console.WriteLine($"Encoding: {input}");
            Console.WriteLine();

            var byteLength = Encoding.UTF8.GetByteCount(input);
            Console.WriteLine($"String char length: {input.Length}");
            Console.WriteLine($"Bytes required: {byteLength}");

            Console.WriteLine();

            var data = Encoding.UTF8.GetBytes(input);
            Console.Write("Encoded bytes: ");
            Console.WriteLine(BitConverter.ToString(data));

            var decodedString = Encoding.UTF8.GetString(data);
            Console.Write("Decoded string: ");
            Console.WriteLine(decodedString);

        }
    }
}
