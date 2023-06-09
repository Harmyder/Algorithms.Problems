using System.Diagnostics;

namespace LeetCode.Tasks
{
    internal class GroupsOfStrings
    {
        private static readonly HashSet<char> Alphabet = new HashSet<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        private static readonly HashSet<int> TwoBitSets = ComputeTwoBitSets(); 

        public int[] GroupStrings(string[] words)
        {
            var wordsInt = words.Select(x => AlphabetSetToInt(x)).ToArray();

            var repeatsCount = wordsInt.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

            var distinct = wordsInt.Distinct().ToArray();

            var index = 0;
            var toIndex = distinct.ToDictionary(x => x, x => index++);

            var adjacency = new List<int>[distinct.Length];
            for (var i = 0; i < adjacency.Length; i++)
            {
                adjacency[i] = new List<int>();
            }

            var byLength = distinct.GroupBy(x => NumberOfSetBits(x)).OrderBy(x => x.Key).ToArray();

            HashSet<int> prevLookup = null;
            foreach (var withLength in byLength)
            {
                var lookup = new HashSet<int>();

                foreach (var word in withLength)
                {
                    var currentIndex = toIndex[word];

                    foreach (var twoBitSet in TwoBitSets)
                    {
                        var adjacent = word ^ twoBitSet;
                        if (lookup.Contains(adjacent))
                        {
                            var adjacentIndex = toIndex[adjacent];
                            adjacency[currentIndex].Add(adjacentIndex);
                            adjacency[adjacentIndex].Add(currentIndex);
                        }
                    }

                    if (prevLookup != null)
                    {
                        for (var charIndex = 0; charIndex < 26; ++charIndex)
                        {
                            var adjacent = word ^ (1 << charIndex);
                            if (adjacent < word && prevLookup.Contains(adjacent))
                            {
                                var adjacentIndex = toIndex[adjacent];
                                adjacency[currentIndex].Add(adjacentIndex);
                                adjacency[adjacentIndex].Add(currentIndex);
                            }
                        }
                    }

                    lookup.Add(word);
                }
                
                prevLookup = lookup;
            }

            var isVisited = new bool[distinct.Length];
            var groupsCount = 0;
            var maxCount = 0;
            for (var i = 0; i < distinct.Length; ++i)
            {
                if (!isVisited[i])
                {
                    groupsCount++;
                    var count = repeatsCount[distinct[i]];
                    var path = new List<(int WordIndex, int AdjacencyIndex)>() { (i, 0) };
                    isVisited[i] = true;
                    while (path.Any())
                    {
                        var currAdjacencyList = adjacency[path.Last().WordIndex];
                        var j = path.Last().AdjacencyIndex;
                        for (; j < currAdjacencyList.Count; ++j)
                        {
                            var currAdjacentWordIndex = currAdjacencyList[j];
                            if (!isVisited[currAdjacentWordIndex])
                            {
                                path[path.Count - 1] = (path.Last().WordIndex, j + 1);
                                path.Add((currAdjacentWordIndex, 0));
                                count += repeatsCount[distinct[currAdjacentWordIndex]];
                                isVisited[currAdjacentWordIndex] = true;
                                break;
                            }
                        }
                        if (j == currAdjacencyList.Count)
                        {
                            path.RemoveAt(path.Count - 1);
                        }
                    }
                    maxCount = Math.Max(maxCount, count);
                }
            }

            return new[] { groupsCount, maxCount };
        }

        private static int AlphabetSetToInt(string value)
        {
            var result = 0;
            foreach (var ch in value)
            {
                result |= 1 << (ch - 'a');
            }
            return result;
        }

        private static HashSet<int> ComputeTwoBitSets()
        {
            var hashSet = new HashSet<int>();
            for (var i = 0; i < Alphabet.Count; i++)
            {
                for (var j = i + 1; j < Alphabet.Count; j++)
                {
                    hashSet.Add((1 << i) + (1 << j));
                }
            }
            return hashSet;
        }

        private static int NumberOfSetBits(int i)
        {
            i = i - ((i >> 1) & 0x55555555);
            i = (i & 0x33333333) + ((i >> 2) & 0x33333333);
            return (((i + (i >> 4)) & 0x0F0F0F0F) * 0x01010101) >> 24;
        }
    }
}
