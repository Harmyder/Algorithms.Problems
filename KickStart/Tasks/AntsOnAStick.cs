using System;
using System.Collections.Generic;
using System.Linq;

namespace KickStart.Tasks
{
    internal class AntsOnAStick
    {
        public static void RunWithRead()
        {
            var testsCount = int.Parse(Console.ReadLine());

            for (var i = 0; i < testsCount; ++i)
            {
                var firstLine = Console.ReadLine().Split(' ');
                var antsCount = int.Parse(firstLine[0]);
                var stickLen = int.Parse(firstLine[1]);
                var ants = new List<AntsOnAStick.Ant>();
                for (var j = 0; j < antsCount; ++j)
                {
                    var antLine = Console.ReadLine().Split(' ');
                    ants.Add(new AntsOnAStick.Ant(int.Parse(antLine[0]), (AntsOnAStick.Direction)int.Parse(antLine[1])));
                }
                var res = AntsOnAStick.Run(stickLen, ants.ToArray());

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Case #{i + 1}: {string.Join(' ', res)}");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        public enum Direction
        {
            Left,
            Right,
        }

        public struct  Ant
        {
            public Ant(int pos, Direction dir)
            {
                Pos = pos;
                Dir = dir;
            }
            public readonly int Pos;
            public readonly Direction Dir;
        }

        public static int[] Run(int stickLen, Ant[] ants)
        {
            var sortedAnts = ants.Select((x, i) => new KeyValuePair<Ant, int>(x, i + 1)).OrderBy(x => x.Key.Pos).ToArray();

            var timeFallingLeft = sortedAnts.Select(x => x.Key).Where(x => x.Dir == Direction.Left).Select(x => x.Pos).ToArray();
            var timeFallingRight = sortedAnts.Select(x => x.Key).Where(x => x.Dir == Direction.Right).Select(x => stickLen - x.Pos).Reverse().ToArray();

            var res = new List<int>();

            var curLeft = 0;
            var curRight = 0;
            var lastTime = 0;
            var lastSingleTimeBatch = new List<int>();
            for (var i = 0; i < ants.Length; ++i)
            {
                if (curRight == timeFallingRight.Length || curLeft < timeFallingLeft.Length && timeFallingLeft[curLeft] < timeFallingRight[curRight])
                {
                    if (lastTime != timeFallingLeft[curLeft])
                    {
                        res.AddRange(lastSingleTimeBatch.OrderBy(x => x));
                        lastSingleTimeBatch.Clear();
                    }
                    lastSingleTimeBatch.Add(sortedAnts[curLeft++].Value);
                }
                else if (curLeft >= timeFallingLeft.Length || curRight < timeFallingRight.Length && timeFallingLeft[curLeft] > timeFallingRight[curRight])
                {
                    if (lastTime != timeFallingRight[curRight])
                    {
                        res.AddRange(lastSingleTimeBatch.OrderBy(x => x));
                        lastSingleTimeBatch.Clear();
                    }
                    lastSingleTimeBatch.Add(sortedAnts[ants.Length - ++curRight].Value);
                }
                else
                {
                    if (lastTime != timeFallingRight[curRight])
                    {
                        res.AddRange(lastSingleTimeBatch.OrderBy(x => x));
                        lastSingleTimeBatch.Clear();
                    }
                    lastSingleTimeBatch.Add(sortedAnts[curLeft++].Value);
                    lastSingleTimeBatch.Add(sortedAnts[ants.Length - ++curRight].Value);
                    ++i;
                }
            }

            res.AddRange(lastSingleTimeBatch.OrderBy(x => x));

            return res.ToArray();
        }
    }
}
