using System;
using System.Collections.Generic;
using System.Linq;

namespace KickStart.Tasks
{
    internal class HappySubarrays
    {
        public static long Run()
        {
            var len = int.Parse(Console.ReadLine());
            var arr = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).Concat(new[] { 0 }).ToArray();

            var reversePartial = new long[arr.Length];
            reversePartial[len] = 0;
            for (var i = len - 1; i >= 0; i--)
            {
                reversePartial[i] = reversePartial[i + 1] + arr[i];
            }

            var sumPP = 0L;
            var sum = 0L;
            var lastLevelHappy = new SortedSet<(long, int)>();
            for (var i = 0; i < len; i++)
            {
                lastLevelHappy.Add((reversePartial[i], i));
                sumPP += reversePartial[i];
                
                var currOffset = reversePartial[i + 1];

                while (lastLevelHappy.Count > 0 && lastLevelHappy.Min.Item1 < currOffset)
                {
                    sumPP -= lastLevelHappy.Min.Item1;
                    lastLevelHappy.Remove(lastLevelHappy.Min);
                }

                var increment = sumPP - currOffset * lastLevelHappy.Count;
                sum += increment;
            }

            return sum;
        }
    }
}
