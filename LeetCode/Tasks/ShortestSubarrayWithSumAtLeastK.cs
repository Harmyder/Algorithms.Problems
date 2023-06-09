namespace LeetCode.Tasks
{
    internal class ShortestSubarrayWithSumAtLeastK
    {
        public int Solve(int[] nums, int k)
        {
            var partialSums = new long[nums.Length + 1];
            partialSums[0] = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                partialSums[i + 1] = partialSums[i] + nums[i];
            }

            var leftBehind = new List<(long PartialSum, int Index)>();
            leftBehind.Add((partialSums[nums.Length], nums.Length));

            var minDist = int.MaxValue;
            for (var left = nums.Length - 1; left >= 0; left--)
            {
                var currPartialSum = partialSums[left];

                for (var i = leftBehind.Count - 1; i >= 0 && leftBehind[i].PartialSum < currPartialSum; --i)
                {
                    leftBehind.RemoveAt(leftBehind.Count - 1);
                }

                leftBehind.Add((currPartialSum, left));

                var desiredSumIndex = BinarySearchLowerBound(leftBehind, 0, leftBehind.Count, currPartialSum + k);

                if (desiredSumIndex >= 0)
                {
                    var right = leftBehind[desiredSumIndex].Index;
                    var dist = right - left;
                    minDist = Math.Min(minDist, dist);
                }
            }

            return minDist == int.MaxValue ? -1 : minDist;
        }

        private int BinarySearchLowerBound(List<(long PartialSum, int Index)> list, int left, int right, long partialSum)
        {
            if (right - left == 1)
            {
                return list[left].PartialSum >= partialSum ? left : -1;
            }

            var middle = (left + right) / 2;

            if (list[middle].PartialSum >= partialSum)
            {
                return BinarySearchLowerBound(list, middle, right, partialSum);
            }
            else
            {
                return BinarySearchLowerBound(list, left, middle, partialSum);
            }
        }

        public int SolveBrute(int[] nums, int k)
        {
            var partialSums = new int[nums.Length + 1];
            partialSums[0] = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                partialSums[i + 1] = partialSums[i] + nums[i];
            }

            var min = int.MaxValue;
            for (var i = 0; i < nums.Length; i++)
            {
                for (var j = i + 1; j <= nums.Length; j++)
                {
                    if (partialSums[j] - partialSums[i] >= k)
                    {
                        min = Math.Min(min, j - i);
                    }
                }
            }

            return min == int.MaxValue ? -1 : min;
        }
    }
}
