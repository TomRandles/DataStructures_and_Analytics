using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Running;
using Microsoft.Extensions.ObjectPool;
using System;
using System.Buffers;
using System.Text;

// Reference - StringManipulations Pluralsight course 

namespace StringManipulation_Benchmarks
{
    internal class Program
    {
        private static void Main(string[] args) => BenchmarkRunner.Run<StringBenchmarks>();
    }

    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.SlowestToFastest)]
    public class StringBenchmarks
    {
        private const string Sentence = "A short sentence. "; // 17 chars

        private string _final;

        [Benchmark]
        public void NoBuilder()
        {
            for (var a = 0; a < 100; a++)
            {
                var finalString = string.Empty;

                for (var i = 0; i < 50; i++)
                {
                    finalString += Sentence;
                }

                _final = finalString;
            }
        }

        [Benchmark]
        public void Builder()
        {
            for (var a = 0; a < 100; a++)
            {
                var sb = new StringBuilder(1024);

                for (var i = 0; i < 50; i++)
                {
                    sb.Append(Sentence);
                }

                _final = sb.ToString();
            }
        }

        [Benchmark]
        public void PooledBuilder()
        {
            var provider = new DefaultObjectPoolProvider();
            var pool = provider.CreateStringBuilderPool();

            for (var a = 0; a < 100; a++)
            {
                var sbPooled = pool.Get();

                try
                {
                    for (var i = 0; i < 50; i++)
                    {
                        sbPooled.Append(Sentence);
                    }

                    _final = sbPooled.ToString();
                }
                finally
                {
                    pool.Return(sbPooled);
                }
            }
        }

        [Benchmark]
        public void StackAllocated()
        {
            for (var a = 0; a < 100; a++)
            {
                var sentenceSpan = Sentence.AsSpan();
                var length = sentenceSpan.Length;

                // Beware stackalloc, especially inside a loop - This is demo-ware!!
                Span<char> buffer = stackalloc char[1_024]; // 2kb

                var position = 0;

                for (var i = 0; i < 50; i++)
                {
                    sentenceSpan.CopyTo(buffer.Slice(position));
                    position += length;
                }

                _final = new string(buffer.Slice(0, position));
            }
        }

        [Benchmark]
        public void ArrayPool()
        {
            for (var a = 0; a < 100; a++)
            {
                var sentenceSpan = Sentence.AsSpan();
                var length = sentenceSpan.Length;
                var buffer = ArrayPool<char>.Shared.Rent(1_024); // slightly larger than we need

                try
                {
                    var span = buffer.AsSpan();
                    var position = 0;

                    for (var i = 0; i < 50; i++)
                    {
                        sentenceSpan.CopyTo(span.Slice(position));
                        position += length;
                    }

                    _final = new string(span.Slice(0, position));
                }
                finally
                {
                    ArrayPool<char>.Shared.Return(buffer);
                }
            }
        }

        [Benchmark]
        public void StringCreate()
        {
            for (var a = 0; a < 100; a++)
            {
                var finalLength = Sentence.Length * 50;
                var sentenceLength = Sentence.Length;

                _final = string.Create(finalLength, (Sentence, sentenceLength), concatAction);
            }
        }

        private static readonly SpanAction<char, ValueTuple<string, int>> concatAction = (chars, state) =>
        {
            var (sentence, length) = state;

            var position = 0;
            var sentenceSpan = sentence.AsSpan();

            for (var i = 0; i < 50; i++)
            {
                sentenceSpan.CopyTo(chars.Slice(position));
                position += length;
            }
        };
    }
}