using System;
using System.Collections.Generic;
using System.Linq;

namespace KickStart.Tasks
{
    internal class TouchbarTyping
    {
        public static int Run(int[] word, int[] keyboard)
        {
            var table = new int[word.Length, keyboard.Length];
            for (var i = 1; i < word.Length; i++) for (var j = 0; j < keyboard.Length; j++) table[i, j] = int.MaxValue;

            var letterPositions = keyboard.Select((x1, i) => (x1, i)).GroupBy(x2 => x2.Item1).ToDictionary(x3 => x3.Key, x4 => x4.Select(x5 => x5.Item2).ToArray());

            for (var i = 1; i < word.Length; i++)
            {
                var prevLetterPositions = letterPositions[word[i - 1]];

                var heap = new SortedSet<(int Value, int Index)>(prevLetterPositions.Select(index => (table[i - 1, index] + index, index)));

                var firstPrevPositionIndex = 0;
                var prevCurLetterPosition = 0;
                var bestPrevLetterPosition = prevLetterPositions.First();
                foreach (var curLetterPosition in letterPositions[word[i]])
                {
                    var bestCurLetterPosition = bestPrevLetterPosition;
                    table[i, curLetterPosition] = table[i - 1, bestCurLetterPosition] + Math.Abs(curLetterPosition - bestCurLetterPosition);

                    while (firstPrevPositionIndex < prevLetterPositions.Length && prevLetterPositions[firstPrevPositionIndex] <= curLetterPosition)
                    {
                        var pos = prevLetterPositions[firstPrevPositionIndex++];
                        var dist = curLetterPosition - pos;
                        if (table[i, curLetterPosition] > table[i - 1, pos] + dist)
                        {
                            table[i, curLetterPosition] = table[i - 1, pos] + dist;
                            bestCurLetterPosition = pos;
                        }

                        var wasRemoved = heap.Remove((table[i - 1, pos] + pos, pos));
                        if (!wasRemoved) throw new InvalidOperationException();
                    }

                    if (heap.Count != prevLetterPositions.Length - firstPrevPositionIndex) throw new InvalidOperationException();

                    if (heap.Count > 0)
                    {
                        var min = heap.Min;
                        table[i, curLetterPosition] = Math.Min(table[i, curLetterPosition], table[i - 1, min.Index] + min.Index - curLetterPosition);
                    }

                    prevCurLetterPosition = curLetterPosition;
                    bestPrevLetterPosition = bestCurLetterPosition;
                }
            }

            for (var i = 0; i < word.Length; i++)
            {
                for (var j = 0; j < keyboard.Length; ++j)
                {
                    Console.Write($"{(table[i, j] == int.MaxValue ? null : table[i, j]),11}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            var res = int.MaxValue;
            for (var j = 0; j < keyboard.Length; ++j)
            {
                res = Math.Min(res, table[word.Length - 1, j]);
            }

            return res;
        }
    }
}
