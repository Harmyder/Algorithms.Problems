using System;
using System.Collections.Generic;
using System.Linq;

namespace KickStart.Tasks
{
    internal class InterestingInteger
    {
        private const int MaxDigitsCount = 13;
        private const int MaxSum = 9 * MaxDigitsCount;

        static InterestingInteger()
        {
            for (var i = 0; i < DP.GetLength(0); ++i)
            {
                for (var j = 0; j < DP.GetLength(1); ++j)
                {
                    DP[i, j] = new Dictionary<long, long>();
                }
            }
        }

        public static long SmallestWrong = long.MaxValue;

        public static void Run(int i, string expectedAnswer = null)
        {
            var input = Console.ReadLine().Split(' ').Select(x => long.Parse(x)).ToArray();
            var a = input[0] - 1;
            var b = input[1];

            var res = RunSpecific(b) - RunSpecific(a);

            var answer = $"Case #{i + 1}: {res}";
            var color = expectedAnswer == null ? ConsoleColor.Magenta : expectedAnswer != answer ? ConsoleColor.Red : ConsoleColor.Green;

            Console.ForegroundColor = color;
            Console.WriteLine(answer);
            Console.ForegroundColor = ConsoleColor.Gray;

            if (expectedAnswer != null)
            {
                if (expectedAnswer != answer)
                {
                    SmallestWrong = Math.Min(SmallestWrong, res);
                    Console.WriteLine($"{a}-{b}");
                    Console.WriteLine(expectedAnswer);
                }
            }
        }

        public static long RunSpecific(long max)
        {
            if (max == 0) return 0;

            long res = 0;

            var digits = max.ToString().Select(x => x - '0').ToArray();

            for (var i = 1; i < digits.Length; ++i)
            {
                res += CountAll(digits.Length - i, 1, 0, true);
            }

            res += CountForSuffix(digits, 1, 0, true);

            return res;
        }

        private static Dictionary<long, long>[,] DP = new Dictionary<long, long>[MaxDigitsCount, MaxSum];

        private static long CountForSuffix(IEnumerable<int> suffix, long prod, int sum, bool isFirstDigit = false)
        {
            if (!suffix.Any())
            {
                if (prod == 0 || prod % sum == 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

            long res = 0;
            for (var i = isFirstDigit ? 1 : 0; i < suffix.First(); ++i)
            {
                res += CountAll(suffix.Count() - 1, prod * i, sum + i);
            }

            res += CountForSuffix(suffix.Skip(1), prod * suffix.First(), sum + suffix.First());

            return res;
        }

        private static long CountAll(int positionsCount, long prod, int sum, bool isFirstDigit = false)
        {
            if (positionsCount == 0)
            {
                if (prod == 0 || prod % sum == 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

            var store = DP[positionsCount, sum];

            if (store.ContainsKey(prod))
            {
                return store[prod];
            }

            long res = 0;

            for (var firstDigit = isFirstDigit ? 1 : 0; firstDigit < 10; ++firstDigit)
            {
                var nextSum = sum + firstDigit;
                if (nextSum > MaxSum) continue;
                res += CountAll(positionsCount - 1, prod * firstDigit, nextSum);
            }

            store.Add(prod, res);

            return res;
        }
    }
}
