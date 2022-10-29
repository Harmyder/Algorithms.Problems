using System.Diagnostics;

namespace LeetCode.Tasks
{
    internal class LongestIncreasingSubsequence2
    {
        public int LengthOfLIS(int[] nums, int k)
        {
            var dp = new Tree(nums);

            dp.Upsert(nums.Last(), 1);

            for (var i = nums.Length - 2; i >= 0; --i)
            {
                var num = nums[i];
                var currCount = dp.MaxCountForRange(num + 1, num + k);
                ++currCount;

                dp.Upsert(nums[i], currCount);
            }

            return dp.Max;
        }

        private class Tree
        {
            private const int LevelsCount = 19;
            private int[] _tree = new int[1 << LevelsCount];
            private int[] _sortedValues;
            private Dictionary<int, int> _valueToIndex = new Dictionary<int, int>();

            public Tree(int[] nums)
            {
                _sortedValues = nums.Distinct().OrderBy(x => x).ToArray();
                for (var i = 0; i < _sortedValues.Length; ++i)
                {
                    _valueToIndex.TryAdd(_sortedValues[i], i);
                }
            }

            public int Max => _tree[1];

            public void Upsert(int value, int count)
            {
                var index = (1 << (LevelsCount - 1)) + _valueToIndex[value];
                var binary = Convert.ToString(index, 2);

                var currIndex = 0;
                foreach (var bit in binary)
                {
                    currIndex = bit == '0' ? currIndex * 2 : currIndex * 2 + 1;
                    _tree[currIndex] = Math.Max(_tree[currIndex], count);
                }
            }

            public int MaxCountForRange(int lo, int hi)
            {
                var loIndex = FindNextValueIndex(lo);
                var hiIndex = FindPrevValueIndex(hi);
                return MaxCountForRange_Internal(loIndex + (1 << LevelsCount - 1), hiIndex + (1 << LevelsCount - 1), 1, 1);
            }

            private int MaxCountForRange_Internal(int lo, int hi, int node, int level)
            {
                var levelsBelowCount = LevelsCount - level;
                var leftLeaf = node * (1 << levelsBelowCount);
                var rightLeaf = leftLeaf + (1 << levelsBelowCount) - 1;
                if (lo <= leftLeaf && rightLeaf <= hi)
                {
                    return _tree[node];
                }
                else if (lo > rightLeaf || hi < leftLeaf)
                {
                    return 0;
                }
                var left = MaxCountForRange_Internal(lo, hi, node * 2, level + 1);
                var right = MaxCountForRange_Internal(lo, hi, node * 2 + 1, level + 1);
                return Math.Max(left, right);
            }

            private int FindNextValueIndex(int value) => FindNextValueIndex_Internal(value, 0, _sortedValues.Length - 1, true);

            private int FindPrevValueIndex(int value) => FindNextValueIndex_Internal(value, 0, _sortedValues.Length - 1, false);

            private int FindNextValueIndex_Internal(int value, int indexLo, int indexHi, bool isNext)
            {
                if (indexLo >= indexHi)
                {
                    if (_sortedValues[indexLo] == value) return indexLo;
                    if (_sortedValues[indexLo] > value) return isNext ? indexLo : indexLo - 1;
                    if (_sortedValues[indexLo] < value) return isNext ? indexLo + 1: indexLo;
                }

                var indexMiddle = (indexLo + indexHi) / 2;

                if (value < _sortedValues[indexMiddle])
                {
                    return FindNextValueIndex_Internal(value, indexLo, indexMiddle - 1, isNext);
                }
                
                if (value > _sortedValues[indexMiddle])
                {
                    return FindNextValueIndex_Internal(value, indexMiddle + 1, indexHi, isNext);
                }

                return FindNextValueIndex_Internal(value, indexMiddle, indexMiddle, isNext);
            }
        }
    }
}
