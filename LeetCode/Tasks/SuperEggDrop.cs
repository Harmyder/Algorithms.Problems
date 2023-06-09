namespace LeetCode.Tasks
{
    internal class SuperEggDrop
    {
        public int Solve(int givenEggsCount, int givenFloorsCount)
        {
            //var dp = SolveDP(eggsCount, floorsCount);
            //return dp[floorsCount, eggsCount];

            var maxSteps = 142;
            var dp = new int[maxSteps + 1, givenEggsCount + 1];

            for (var i = 1; i <= givenEggsCount; ++i)
            {
                dp[1, i] = 1;
            }

            for (var i = 1; i <= maxSteps; ++i)
            {
                dp[i, 1] = i;
            }

            for (var eggsCount = 2; eggsCount <= givenEggsCount; ++eggsCount)
            {
                for (var stepsCount = 2; ; ++stepsCount)
                {
                    var maxWholeSide = dp[stepsCount - 1, eggsCount];
                    var maxBrokenSide = dp[stepsCount - 1, eggsCount - 1];

                    var total = maxWholeSide + maxBrokenSide + 1;

                    dp[stepsCount, eggsCount] = total;

                    if (total > givenFloorsCount)
                    {
                        break;
                    }
                }
            }

            var resultStepsCount = 0;
            //Console.WriteLine(string.Join(", ", Enumerable.Range(1, maxSteps).Select(i => dp[i, givenEggsCount])));
            while (dp[++resultStepsCount, givenEggsCount] < givenFloorsCount) ;

            return resultStepsCount;
        }

        public void Test()
        {
            var n = 1000;
            var k = 100;
            var dp = SolveDP(k, n);

            for (var floorsCount = 1; floorsCount <= n; ++floorsCount)
            {
                Console.Write($"{dp[floorsCount, 1]}".PadRight(4, ' '));
                for (var eggsCount = 2; eggsCount <= k; eggsCount++)
                {
                    {
                        Console.Write($"{dp[floorsCount, eggsCount]}".PadRight(3, ' '));
                    }
                }
                Console.WriteLine();
            }
        }

        public int[,] SolveDP(int k, int n)
        {
            var dp = new int[n + 1, k + 1];

            for (var eggsCount = 1; eggsCount <= k; eggsCount++)
            {
                dp[1, eggsCount] = 1;
            }

            for (var floorsCount = 2; floorsCount <= n; ++floorsCount)
            {
                dp[floorsCount, 1] = floorsCount;

                for (var eggsCount = 2; eggsCount <= k; eggsCount++)
                {
                    var min = int.MaxValue;
                    
                    for (var m = 1; m < floorsCount; ++m)
                    {
                        var wholeCase = dp[floorsCount - m, eggsCount];
                        var brokenCase = dp[m - 1, eggsCount - 1];
                        var worstCase = Math.Max(brokenCase, wholeCase);
                        min = Math.Min(min, 1 + worstCase);
                    }

                    dp[floorsCount, eggsCount] = min;
                }
            }

            return dp;
        }
    }
}
