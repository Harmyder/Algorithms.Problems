using System;
using System.Collections.Generic;
using System.Linq;

namespace KickStart.Tasks
{
    internal class StoryOfSeasons
    {
        public static string Run()
        {
            // Stress tree
            //for (var length = 2; length < 1000; ++length)
            //{
            //    var rnd = new Random(1);
            //    var data = new long[length];
            //    for (var i = 0; i < length; ++i) data[i] = 1;// rnd.Next(1, 1000);
            //    var dataOriginal = data.ToArray();
            //    var dataOrdered = data.Select((v, i) => (Value: v, Index: i)).OrderBy(x => x.Value).ToArray();
            //    var tree = new PartialSumTree(dataOrdered.Select(x => x.Value).ToArray());
            //    var orderedToOriginal = dataOrdered.Select(x => x.Index).ToArray();
            //    var order = Enumerable.Range(0, length).OrderBy(a => rnd.Next(0, length * length * length)).ToArray();
            //    for (var i = 0; i < length; ++i)
            //    {
            //        var value = data[orderedToOriginal[order[i]]];
            //        data[orderedToOriginal[order[i]]] = 0;
            //        tree.Delete(order[i]);
            //        var sumTreeFull = tree.PartialSum(data.Length - 1);
            //        var nextBiggerValueIndex = Array.FindIndex(dataOrdered, 0, x => x.Value > value);
            //        var sumTreeBefore = nextBiggerValueIndex == -1 ? sumTreeFull : tree.PartialSum(nextBiggerValueIndex - 1);
            //        var sumTree = sumTreeFull - sumTreeBefore;
            //        var sumArray = data.Aggregate((long)0, (accum, v) =>
            //        {
            //            return accum + ((v > value) ? v : 0);
            //        });
            //        if (sumArray != sumTree)
            //        {
            //            throw new InvalidOperationException();
            //        }
            //    }
            //}

            var line1 = Console.ReadLine().Split(' ').Select(x => long.Parse(x)).ToArray();
            var daysCount = line1[0];
            var vegiesCount = line1[1];
            var maxDayCount = line1[2];

            Console.WriteLine($"{daysCount}, {vegiesCount}, {maxDayCount}");

            var seeds = new Seed[vegiesCount];
            for (var i = 0; i < vegiesCount; ++i)
            {
                var line = Console.ReadLine().Split(' ').Select(x => long.Parse(x)).ToArray();
                seeds[i] = new Seed(line[0], line[1], (int)line[2]);
            }

            Array.Sort(seeds, (x, y) => -x.Days.CompareTo(y.Days));

            var cutter = new Cutter(seeds);

            long res = 0;

            var daysLeft = daysCount - 2;
            var curDayAvailableCount = maxDayCount;
            for (var i = 0; i < seeds.Length; ++i)
            {
                var seed = seeds[i];
                cutter.DeleteCur(i);
                if (seed.Days > daysLeft + 1) continue;
                var moreValuableCount = cutter.CountNextBetter(seed.Value);
                var availableCount = daysLeft * maxDayCount + curDayAvailableCount - moreValuableCount;
                if (availableCount > 0)
                {
                    var usedCount = Math.Min(availableCount, seed.Quantity);
                    if (usedCount > curDayAvailableCount)
                    {
                        usedCount = curDayAvailableCount;
                        curDayAvailableCount = maxDayCount;
                        --daysLeft;
                        --i;
                    }
                    else if (usedCount == curDayAvailableCount)
                    {
                        curDayAvailableCount = maxDayCount;
                        --daysLeft;
                    }
                    else
                    {
                        curDayAvailableCount -= usedCount;
                    }
                    seed.Use(usedCount);
                    res += usedCount * seed.Value;
                }
            }

            return $"{res}";
        }

        private class Cutter
        {
            private readonly Seed[] _byDays;
            private long _curByDays;

            private readonly int[] _dayToValueIndices;
            private readonly PartialSumTree _partialSumTree;
            private readonly ValueIndex[] _firstValueIndices;

            public Cutter(Seed[] sortedByDay)
            {
                _byDays = sortedByDay;

                var byValues = sortedByDay.Select((v, i) => (Seed: v, ByDayIndex: i)).OrderBy(x => x.Seed.Value).ToArray();
                _dayToValueIndices = new int[sortedByDay.Length];
                for (var i = 0; i < byValues.Length; ++i)
                {
                    _dayToValueIndices[byValues[i].ByDayIndex] = i;
                }
                _partialSumTree = new PartialSumTree(byValues.Select(x => x.Seed.Quantity).ToArray());
                int lastValue = -1;
                var firstValueIndices = new List<ValueIndex>();
                for (var i = 0; i < byValues.Length; ++i)
                {
                    var value = byValues[i].Seed.Value;
                    if (value != lastValue)
                    {
                        firstValueIndices.Add(new ValueIndex(value, i));
                        lastValue = value;
                    }
                }
                firstValueIndices.Add(new ValueIndex(int.MaxValue, byValues.Length));
                _firstValueIndices = firstValueIndices.ToArray();
            }

            public void DeleteCur(int curIndex)
            {
                if (curIndex - _curByDays > 1) throw new InvalidOperationException();
                _curByDays = curIndex;
                _partialSumTree.Delete(_dayToValueIndices[curIndex]);
            }

            public long CountNextBetter(long minValue)
            {
                var fullSum = _partialSumTree.PartialSum(_dayToValueIndices.Length - 1);
                var firstValueIndex = Array.BinarySearch(_firstValueIndices, new ValueIndex(_byDays[_curByDays].Value, -1), Comparer<ValueIndex>.Create((x, y) => x.Value.CompareTo(y.Value)));
                var beforeSum = _partialSumTree.PartialSum(_firstValueIndices[firstValueIndex + 1].Index - 1);
                var res = fullSum - beforeSum;
                return res;
            }
        }

        private struct ValueIndex
        {
            public ValueIndex(int v, int i)
            {
                Value = v;
                Index = i;
            }

            public int Value { get; }
            public int Index { get; }
        }

        private class PartialSumTree
        {
            private readonly long[] _tree;
            private readonly int _power;

            public PartialSumTree(long[] data)
            {
                _power = 1;
                while (_power < data.Length)
                    _power *= 2;

                _tree = new long[_power * 2];

                for (var i = 0; i < data.Length; ++i)
                {
                    Add(data[i], i);
                }
            }

            public void Delete(int index)
            {
                var value = _tree[_power + index];
                Add(-value, index);
            }

            public long PartialSum(int r)
            {
                var location = _power + r;
                long res = _tree[location];
                while (location != Lsb(location))
                {
                    if ((location & 1) == 1)
                    {
                        res += _tree[--location];
                    }
                    else
                    {
                        location = (location >> 1);
                    }
                }
                return res;
            }

            private void Add(long value, int index)
            {
                var location = _power + index;
                while (location > 0)
                {
                    _tree[location] += value;
                    location >>= 1;
                }
            }

            private int Lsb(int i) => i & -i;
        }

        [System.Diagnostics.DebuggerDisplay("q:{Quantity}, l:{Days}, v:{Value}")]
        private class Seed
        {
            public Seed(long q, long g, int v)
            {
                Quantity = q;
                Days = g;
                Value = v;
            }

            public void Use(long quantity)
            {
                Quantity -= quantity;
                if (Quantity < 0) throw new InvalidOperationException();
            }

            public long Quantity { get; private set; }
            public long Days { get; }
            public int Value { get; }
        }
    }
}
