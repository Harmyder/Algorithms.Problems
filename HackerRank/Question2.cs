using System;
using System.Linq;

namespace HackerRank
{
    internal class Question2
    {
        private const int CC = 3;
        public static int getMaxFreqDeviation(string s)
        {
            var pairs = new int[CC, CC, s.Length + 1];

            for (var c = 1; c <= s.Length; ++c)
            {
                var ch = s[c - 1] - 'a';

                for (var i = 0; i < CC; ++i)
                {
                    for (var j = 0; j <= i; ++j)
                    {
                        pairs[i, j, c] = pairs[i, j, c - 1];
                    }
                }

                for (var i = 0; i < CC; ++i)
                {
                    if (i > ch) ++pairs[i, ch, c];
                    if (i < ch) --pairs[ch, i, c];
                }

                ++pairs[ch, ch, c];
            }

            var mins = new int[CC, CC];
            var maxs = new int[CC, CC];

            for (var i = 0; i < CC; ++i)
            {
                for (var j = 0; j < CC; ++j)
                {
                    mins[i, j] = 0;
                    maxs[i, j] = 0;
                }
            }

            for (var c = 1; c <= s.Length; ++c)
            {
                for (var i = 0; i < CC; ++i)
                {
                    for (var j = 0; j < i; ++j)
                    {
                        mins[i, j] = pairs[i, j, mins[i, j]] < pairs[i, j, c] ? mins[i, j] : c;
                        maxs[i, j] = pairs[i, j, maxs[i, j]] > pairs[i, j, c] ? maxs[i, j] : c;
                    }
                }
            }

            for (var i = 0; i < CC; ++i)
            {
                if (i == 0)
                {
                    Console.WriteLine($"('_', '_'): " + string.Join("", Enumerable.Range(0, s.Length + 1).Select(x => $"{x, 3} ")));
                    Console.WriteLine($"            " + "    " + string.Join("", s.Select(x => $"{x, 3} ")));
                }

                for (int j = 0; j <= i; ++j)
                {
                    Console.Write($"('{(char)('a' + i)}', '{(char)('a' + j)}'): ");
                    for (var c = 0; c <= s.Length; ++c)
                    {
                        Console.Write($"{pairs[i, j, c], 3} ");
                    }
                    Console.WriteLine();
                }
            }

            var diff = 0;

            for (var i = 0; i < CC; ++i)
            {
                for (var j = 0; j < i; ++j)
                {
                    if (i != j)
                    {
                        var maxDiffIndex = maxs[i, j];
                        var minDiffIndex = mins[i, j];
                        Console.WriteLine($"{diff} ('{(char)('a' + i)}', '{(char)('a' + j)}'): {minDiffIndex} {maxDiffIndex}");
                        var minIndex = Math.Min(minDiffIndex, maxDiffIndex);
                        var maxIndex = Math.Max(minDiffIndex, maxDiffIndex);
                        var difi = pairs[i, i, maxIndex] - pairs[i, i, minIndex];
                        var difj = pairs[j, j, maxIndex] - pairs[j, j, minIndex];
                        var curDiff = pairs[i, j, maxDiffIndex] - pairs[i, j, minDiffIndex];
                        var absentLetterIndex = difi == 0 ? i : (difj == 0 ? j : -1);
                        if (absentLetterIndex != -1)
                        {
                            var letterCount = pairs[absentLetterIndex, absentLetterIndex, s.Length] - pairs[absentLetterIndex, absentLetterIndex, 0];
                            if (letterCount == 0)
                            {
                                continue;
                            }
                            else
                            {
                                --curDiff;
                            }
                        }
                        if (curDiff > diff)
                        {
                            Console.WriteLine($"up to {curDiff}: {s.Substring(minIndex, maxIndex - minIndex)}");
                            diff = curDiff;
                        }
                    }
                }
            }

            return diff;
        }
    }
}
