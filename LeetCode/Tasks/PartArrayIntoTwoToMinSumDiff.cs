namespace LeetCode.Tasks
{
    internal class PartArrayIntoTwoToMinSumDiff
    {
        public int MinimumDifference(int[] nums)
        {
            var n = nums.Length;

            var left = nums.Take(n / 2).ToArray();
            var right = nums.Skip(n / 2).ToArray();

            var minDiff = int.MaxValue;
            for (var i = 0; i < n / 2; ++i)
            {
                var diffsLeft = new List<int>();
                var diffsRight = new List<int>();

                ListDifferences(left, 0, i, 0, 0, diffsLeft);
                ListDifferences(right, 0, n / 2 - i, 0, 0, diffsRight);

                diffsLeft.Sort();
                diffsRight = diffsRight.Select(x => -x).OrderBy(x => x).ToList();

                var leftIndex = 0;
                var rightIndex = 0;
                var minDiffLocal = int.MaxValue;
                for (var j = 0; j < diffsLeft.Count; ++j)
                {
                    var diffLeft = diffsLeft[leftIndex];
                    var diffRightInverse = diffsRight[rightIndex];

                    minDiffLocal = Math.Min(minDiffLocal, Math.Abs(diffLeft - diffRightInverse));
                    (leftIndex, rightIndex) = diffLeft < diffRightInverse ? (leftIndex + 1, rightIndex) : (leftIndex, rightIndex + 1);
                }

                minDiff = Math.Min(minDiffLocal, minDiff);
            }

            return minDiff;
        }

        private void ListDifferences(int[] nums, int startIndex, int leftCount, int sumLeft, int sumRight, List<int> diffs)
        {
            if (leftCount == 0)
            {
                sumRight += nums.Skip(startIndex).Sum();
                diffs.Add(sumLeft - sumRight);
                return;
            }

            for (var i = startIndex; i < nums.Length - leftCount + 1; ++i)
            {
                ListDifferences(nums, i + 1, leftCount - 1, sumLeft + nums[i], sumRight, diffs);

                sumRight += nums[i];
            }
        }
    }
}
