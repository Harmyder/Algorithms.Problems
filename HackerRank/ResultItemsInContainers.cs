using System.Collections.Generic;

namespace HackerRank
{
    internal class ResultItemsInContainers
    {
        public static List<int> numberOfItems(string s, List<int> startIndices, List<int> endIndices)
        {
            var beforeInClosed = new int[s.Length + 1];
            var nextPipe = new int[s.Length + 1];
            nextPipe[s.Length] = int.MaxValue;

            var curItems = 0;
            var hasStarted = false;
            for (var i = 1; i <= s.Length; i++)
            {
                if (hasStarted && s[i - 1] == '*') curItems++;

                if (s[i - 1] == '|')
                {
                    beforeInClosed[i] = curItems;
                    nextPipe[i] = i;
                    hasStarted = true;
                }
                else
                {
                    beforeInClosed[i] = beforeInClosed[i - 1];
                }
            }

            for (var i = s.Length - 1; i > 0; i--)
            {
                if (s[i - 1] == '*')
                {
                    nextPipe[i] = nextPipe[i + 1];
                }
            }

            var res = new List<int>(startIndices.Count);

            for (var i = 0; i < startIndices.Count; i++)
            {
                var start = startIndices[i];
                var end = endIndices[i];

                if (nextPipe[start] >= end)
                {
                    res.Add(0);
                }
                else
                {
                    var beforeStart = beforeInClosed[nextPipe[start]];
                    var beforeEnd = beforeInClosed[end];
                    res.Add(beforeEnd - beforeStart);
                }
            }

            return res;
        }
    }
}
