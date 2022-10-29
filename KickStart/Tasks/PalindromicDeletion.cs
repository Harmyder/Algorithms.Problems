using KickStart.Sdk;
using System;
using System.Linq;

namespace KickStart.Tasks
{
    internal class PalindromicDeletion
    {
        private const int M = 1000 * 1000 * 1000 + 7;

        public static void Run(int i)
        {
            var _ = Console.ReadLine();
            var str = Console.ReadLine();

            var res = RunInternal(str, 0);

            var inv = Numeric.Inverse(Numeric.Factorial(str.Length, M), M);
            res = res * inv % M;

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Case #{i + 1}: {res}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private static long RunInternal(string str, int factor)
        {
            long res = str.SequenceEqual(str.Reverse()) ? factor : 0;

            for (var i = 0; i < str.Length; ++i)
            {
                var nextFactor = Numeric.Factorial(str.Length - 1, M);
                var subRes = RunInternal(str.Substring(0, i) + str.Substring(i + 1), nextFactor);
                res = (res + subRes) % M;
            }

            return res;
        }
    }
}
