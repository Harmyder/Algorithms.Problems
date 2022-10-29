using System.Collections.Generic;
using System.Linq;

namespace HackerRank
{
    internal class Result1
    {
        public static List<int> minimalHeaviestSetA(List<int> arr)
        {
            arr.Sort();
            var sum = arr.Aggregate((long)0, (sum, next) => sum + next);

            long curSubSum = 0;
            var res = new List<int>();
            for (var i = 0; curSubSum <= sum / 2; ++i)
            {
                curSubSum += arr[arr.Count - 1 - i];
                res.Add(arr[arr.Count - 1 - i]);
            }

            res.Sort();

            return res;
        }
    }
}
