namespace LeetCode.Tasks
{
    internal class CountNumberOfIdealArrays
    {
        private const int M = 1000 * 1000 * 1000 + 7;
        public int IdealArrays(int n, int maxValue)
        {
            var maxDividersCount = 63;
            var table = new int[maxValue + 1, maxDividersCount + 1];

            for (var i = 1; i <= maxValue; i++)
            {
                for (var j = 1; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        for (var k = 1; k < maxDividersCount; k++)
                        {
                            table[i, k + 1] += table[j, k];
                        }
                    }
                }

                table[i, 1] = 1;
            }

            //for (var num = 1; num <= maxValue; num++)
            //{
            //    Console.Write($"{num,4}:");
            //    for (var i = 1; i <= 10; i++)
            //    {
            //        Console.Write($"{table[num, i],5}");
            //    }
            //    Console.WriteLine();
            //}

            var byLenCounts = new int[maxDividersCount + 1];
            for (var i = 1; i <= maxDividersCount; i++)
            {
                for (var j = 1; j <= maxValue; ++j)
                {
                    byLenCounts[i] = (byLenCounts[i] + table[j, i]) % M;
                }
            }

            long total = 0;
            for (var i = 1; i <= Math.Min(maxDividersCount, n); ++i)
            {
                if (byLenCounts[i] > 0)
                {
                    var choose = Choose(n - 1, i - 1, M);
                    total += byLenCounts[i] * choose % M;
                }
                //Console.WriteLine(total);
            }            

            return (int)(total % M);
        }

        private long Choose(int n, int k)
        {
            if (k == 0) return 1;
            var nominator = Enumerable.Range(n - k + 1, k).Aggregate((long)1, (total, next) => total * next);
            var denominator = Enumerable.Range(1, k).Aggregate((long)1, (total, next) => total * next);
            return nominator / denominator;
        }

        private long Choose(int n, int k, int m)
        {
            if (k == 0) return 1;

            var nom = Enumerable.Range(n - k + 1, k).Aggregate((long)1, (total, next) => total * next % M);
            var denom = Enumerable.Range(1, k).Aggregate((long)1, (total, next) => total * next % M);
            var denomInverse = Inverse(denom, M);
            return nom * denomInverse % M;
        }

        private static long Inverse(long a, long p)
        {
            return (ExtendedEuclide(a, p).Item2 + p) % p;
        }

        private static (long, long, long) ExtendedEuclide(long a, long b)
        {
            if (b == 0) return (a, 1, 0);
            var (d, x, y) = ExtendedEuclide(b, a % b);
            return (d, y, x - (a / b) * y);
        }
    }
}
