namespace LeetCode.Tasks
{
    internal class MinimumDifference
    {
        public static int Run(int[] nums)
        {
            if (nums.Length == 0) return 0;
            if (nums.Length == 2) return Math.Abs(nums[1] - nums[0]);

            var n = nums.Length / 2;

            var left = nums.Take(n).ToArray();
            var right = nums.Skip(n).ToArray();

            var sum = nums.Sum();
            var diff = int.MaxValue;

            for (var i = 0; i < n; i++)
            {
                var sumsLeft = ComputeSums(left, i).OrderBy(x => x).ToArray();
                var sumsRight = ComputeSums(right, n - i).OrderByDescending(x => x).ToArray();

                var rightIndex = 0;
                for (var j = 0; j < sumsLeft.Length; ++j)
                {
                    var localDiffPrev = int.MaxValue;
                    while (rightIndex < sumsRight.Length)
                    {
                        var halfSum = sumsLeft[j] + sumsRight[rightIndex];
                        var localDiff = Math.Abs(sum - halfSum * 2);
                        if (localDiffPrev >= localDiff)
                        {
                            localDiffPrev = localDiff;
                            ++rightIndex;
                        }
                        else
                        {
                            --rightIndex;
                            break;
                        }
                    }
                    diff = Math.Min(diff, localDiffPrev);
                }
            }

            return diff;
        }

        public static int RunBrute(int[] nums)
        {
            if (nums.Length == 0) return 0;
            if (nums.Length == 2) return Math.Abs(nums[1] - nums[0]);

            var left = Enumerable.Range(0, nums.Length / 2).ToArray();
            --left[left.Length - 1];

            var sum = nums.Sum();

            var diff = int.MaxValue;

            var curLevel = nums.Length / 2 - 1;
            while (curLevel != 0)
            {
                if (left[curLevel] < nums.Length - (nums.Length / 2 - curLevel))
                {
                    left[curLevel] = left[curLevel] + 1;

                    if (left[curLevel] < nums.Length - (nums.Length / 2 - curLevel))
                    {
                        for (var i = curLevel + 1; i < nums.Length / 2; ++i)
                        {
                            left[i] = left[curLevel] + i - curLevel;
                        }
                        curLevel = nums.Length / 2 - 1;
                    }

                    var halfSum = left.Select(i => nums[i]).Sum();
                    var localDiff = Math.Abs(sum - halfSum * 2);
                    diff = Math.Min(diff, localDiff);
                }
                else
                {
                    --curLevel;
                }
            }

            return diff;
        }

        private static List<int> ComputeSums(int[] elems, int selectedCount)
        {
            if (selectedCount == 0) return new List<int> { 0 };

            var sums = new List<int>(6045); // 15!/7!/8!

            var indices = Enumerable.Range(0, selectedCount).ToArray();
            --indices[indices.Length - 1];

            var curLevel = selectedCount - 1;
            while (curLevel > -1)
            {
                if (indices[curLevel] < elems.Length - (selectedCount - curLevel))
                {
                    indices[curLevel] = indices[curLevel] + 1;

                    if (indices[curLevel] < elems.Length - (selectedCount - curLevel))
                    {
                        for (var i = curLevel + 1; i < selectedCount; ++i)
                        {
                            indices[i] = indices[curLevel] + i - curLevel;
                        }
                        curLevel = selectedCount - 1;
                    }

                    var sum = indices.Select(i => elems[i]).Sum();
                    sums.Add(sum);

                    //foreach (var i in indices) Console.Write(i + " ");
                    //Console.WriteLine();
                }
                else
                {
                    --curLevel;
                }
            }

            return sums;
        }
    }
}
