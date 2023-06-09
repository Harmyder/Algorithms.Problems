namespace LeetCode
{
    internal class SplitArraySameAverage
    {
        private const byte NotUsed = 100;

        public bool Solve(int[] nums)
        {
            if (nums.Length == 1) return false;

            var averageScaled = nums.Sum();
            nums = nums.Select(x => x * nums.Length).ToArray();

            var dp = new HashSet<int>();

            dp.Add(0);

            for (var i = 0; i < nums.Length - 1; i++)
            {
                foreach (var key in dp.ToArray())
                {
                    var prevSum = key >> 8;
                    var prevCount = key % 256;
                    var currSum = prevSum + nums[i];
                    var currCount = prevCount + 1;
                    if (currSum == averageScaled * currCount) return true;
                    dp.Add(currSum * 256 + currCount);
                }
            }

            return false;
        }

        public bool SolveOld(int[] nums)
        {
            if (nums.Length == 1) return false;

            var averageScaled = nums.Sum();
            nums = nums.Select(x => x * nums.Length).ToArray();

            for (var i = 1; i < nums.Length; i++)
            {
                var expectedSubsum = averageScaled * i;
                if (HasSubseqWithSum(nums, i, expectedSubsum))
                {
                    return true;
                }
            }

            return false;
        }

        private bool HasSubseqWithSum(int[] nums, int expectedCount, int expectedSubSum)
        {
            var dp = new HashSet<int>();

            dp.Add(0);

            for (var i = 0; i < nums.Length; i++)
            {
                foreach (var key in dp.ToArray())
                {
                    var prevSum = key >> 8;
                    var prevCount = key % 256;
                    var currSum = prevSum + nums[i];
                    var currCount = prevCount + 1;
                    if (currSum > expectedSubSum || currCount > expectedCount) continue;
                    if (currSum == expectedSubSum && currCount == expectedCount) return true;
                    dp.Add(currSum * 256 + currCount);
                }
            }

            Console.WriteLine(dp.Count());

            return false;
        }

        private bool HasSubseqWithSumBak(int[] nums, int len, int sum)
        {
            var dp = new bool[nums.Length + 1, sum + 1, nums.Length + 1];

            dp[0, 0, 0] = true;

            for (var i = 0; i < nums.Length; i++)
            {
                for (var j = 0; j < sum; j++)
                {
                    for (var k = 0; k <= i; ++k)
                    {
                        if (dp[i, j, k])
                        {
                            dp[i + 1, j, k] = true;
                            
                            var currSum = j + nums[i];

                            if (k + 1 == len && currSum == sum) return true;
                            else if (k + 1 > len || currSum > sum) continue;

                            dp[i + 1, currSum, k + 1] = true;
                        }
                    }
                }
            }

            return false;
        }
    }
}
