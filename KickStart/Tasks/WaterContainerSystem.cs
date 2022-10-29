using System;
using System.Collections.Generic;
using System.Linq;

namespace KickStart.Tasks
{
    internal class WaterContainerSystem
    {
        public static void Run(int testNumber)
        {
            var nq = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            var n = nq[0];
            var q = nq[1];

            var adjacency = new Dictionary<int, List<int>>();

            for (int i = 0; i < n - 1; i++)
            {
                var pair = Console.ReadLine().Split(' ').Select(x => int.Parse(x) - 1).ToArray();
                if (adjacency.ContainsKey(pair[0])) adjacency[pair[0]].Add(pair[1]);
                else adjacency[pair[0]] = new List<int> { pair[1] };
                if (adjacency.ContainsKey(pair[1])) adjacency[pair[1]].Add(pair[0]);
                else adjacency[pair[1]] = new List<int> { pair[0] };
            }

            for (var i = 0; i < q; ++i) Console.ReadLine();

            var res = Compute(adjacency, n, q);

            Console.WriteLine($"Case #{testNumber + 1}: {res}");
        }

        private static int Compute(Dictionary<int, List<int>> adjacency, int n, int q)
        {
            var rootIndex = 0;

            var prevLevel = new HashSet<int>();
            var currLevel = new List<int>();
            var nextLevel = new List<int>();

            currLevel.Add(rootIndex);
            var perLevelCount = new List<int>();

            while (currLevel.Count != 0)
            {
                perLevelCount.Add(currLevel.Count);

                foreach (var nodeIndex in currLevel)
                {
                    var hasChildren = adjacency.ContainsKey(nodeIndex);

                    if (hasChildren)
                    {
                        nextLevel.AddRange(adjacency[nodeIndex].Where(x => !prevLevel.Contains(x)));
                    }
                }

                prevLevel = currLevel.ToHashSet();
                currLevel = nextLevel;
                nextLevel = new List<int>();
            }

            var upToTheLevel = 0;
            for (var i = 0; i<perLevelCount.Count; ++i)
            {
                if (upToTheLevel + perLevelCount[i] <= q)
                {
                    upToTheLevel += perLevelCount[i];
                }
                else
                {
                    break;
                }
            }

            return upToTheLevel;
        }
    }
}
