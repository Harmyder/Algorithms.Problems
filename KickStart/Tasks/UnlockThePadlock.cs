using System;
using System.Collections.Generic;
using System.Linq;

namespace KickStart.Tasks
{
    internal class UnlockThePadlock
    {
        public static void Run(int testIndex)
        {
            var range = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).Last();

            var array = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            var normalized = Normalize(array);

            var res = RunInternal(range, normalized);

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Case #{testIndex + 1}: {res}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private static int[] Normalize(int[] input)
        {
            var onlyLocalExtremum = new List<int>() { input[0] };

            for (var i = 1; i < input.Length - 1; ++i)
            {
                if (input[i] < Math.Min(input[i - 1], input[i + 1]) || Math.Max(input[i - 1], input[i + 1]) < input[i])
                {
                    onlyLocalExtremum.Add(input[i]);
                }
            }

            onlyLocalExtremum.Add(input.Last());

            return onlyLocalExtremum.ToArray();
        }

        private static int RunInternal(int range, int[] array)
        {
            var res = int.MaxValue;

            for (var i = 0; i < array.Length; ++i)
            {
                var localRes = RunFrom(i, range, array);
                res = Math.Min(res, localRes);
            }

            return res;
        }

        private static int RunFrom(int start, int range, int[] array)
        {

            return 0;
        }

        private class Cell
        {
            public Cell(int goal, int cost)
            {
                Goal = goal;
                Cost = cost;
            }

            public int Goal { get; }
            public int Cost { get; }
        }
    }
}
