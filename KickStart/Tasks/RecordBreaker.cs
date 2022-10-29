using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace KickStart.Tasks
{
    internal class RecordBreaker
    {
        public static string Run(string line1, string line2)
        {
            var daysCount = int.Parse(line1);
            var prevMax = -1;
            var recordsCount = 0;
            var days = line2.Split(' ').Select(x => int.Parse(x)).Append(-1).ToArray();
            if (days.Length != daysCount + 1)
            {
                throw new InvalidDataException();
            }
            for (var d = 0; d < daysCount; ++d)
            {
                if (days[d] > prevMax && days[d] > days[d + 1])
                {
                    ++recordsCount;
                }
                prevMax = Math.Max(prevMax, days[d]);
            }
            return recordsCount.ToString();
        }

        public static void Test(int testCasesCount)
        {
            for (var i = 0; i < testCasesCount; ++i)
            {
                var (days, recordsCount) = GenerateTestCase();
                var actual = Run(days.Count().ToString(), string.Join(' ', days));
                if (int.Parse(actual) != recordsCount)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public static (List<int>, int) GenerateTestCase()
        {
            var rnd = new Random();
            var isFirst = rnd.Next(0, 1) == 1;
            var days = new List<int>();
            var recordsCount =0;
            var curMax = 100;
            days.Add(curMax);
            if (isFirst)
            {
                days.Add(days.First() - rnd.Next(1, days.First()));
                ++recordsCount;
            }
            else
            {
                curMax += rnd.Next(0, 10);
                days.Add(curMax);
            }

            for (var i = 0; i < 100; ++i)
            {
                AddNext();
            }

            if (days.Where(x => x >= days.Last()).Count() == 1)
            {
                ++recordsCount;
            }

            return (days, recordsCount);

            void AddNext()
            {
                var nextInc = rnd.Next(-1 * days.Last(), 100);
                if (rnd.Next(1, 5) == 1) nextInc = 0;
                if (days.Where(x => x >= days.Last()).Count() == 1)
                {
                    if (nextInc < 0)
                    {
                        ++recordsCount;
                    }
                }
                days.Add(days.Last() + nextInc);
            }
        }
    }
}
