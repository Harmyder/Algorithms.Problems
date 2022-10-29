using System;
using System.Collections.Generic;

namespace HackerRank
{
    internal static class Utils
    {
        public static void Print(long expected, long actual)
        {
            Print(expected.ToString(), actual.ToString());
        }

        public static void Print<T>(IEnumerable<T> expected, IEnumerable<T> actual)
        {
            Print("[" + string.Join(", ", expected) + "]", "[" + string.Join(", ", actual) + "]");
        }

        public static void Print(string expected, string actual)
        {
            Console.ForegroundColor = expected != actual ? ConsoleColor.Red : ConsoleColor.Green;
            Console.WriteLine($"{expected} -- {actual}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
