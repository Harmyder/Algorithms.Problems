using System;

namespace KickStart.Tasks
{
    internal class SherlockAndWatsonGymSecrets
    {
        private const int M = 1000 * 1000 * 1000 + 7;

        public static string Run(int a, int b, long n, int k)
        {
            var count = 0;

            if (n >= k)
            {
                var squares = (n / k) * (n / k) % M;
                count += (int)(Run_Internal(a, b, k, k, k) * squares % M);
                count = (count + (Run_Internal(a, b, (int)(n % k), k, k) * (int)(n / k) % M)) % M;
                count = (count + (Run_Internal(a, b, k, (int)(n % k), k) * (int)(n / k) % M)) % M;
                count = (count + Run_Internal(a, b, (int)(n % k), (int)(n % k), k)) % M;
            }
            else
            {
                count = Run_Internal(a, b, (int)n, (int)n, k);
            }


            return count.ToString();
        }

        private static int Run_Internal(int a, int b, int ni, int nj, int k)
        {
            var count = 0;

            var jPowers = new int[nj + 1];
            for (var j = 1; j <= nj; j++)
            {
                jPowers[j] = Power(j, b, k);
            }

            for (int i = 1; i <= ni; i++)
            {
                var iPower = Power(i, a, k);
                for (int j = 1; j <= nj; j++)
                {
                    if (i == j) continue;

                    var sum = (iPower + jPowers[j]) % k;
                    if (sum == 0)
                    {
                        count = (count + 1) % M;
                    }
                }
            }

            return count;
        }

        private static int Power(int b, int exp, int mod)
        {
            if (exp == 0) return 1;
            if (exp == 1) return b % mod;

            var curExp = 1;
            var curPwr = b;
            while (curExp <= exp / 2)
            {
                curPwr = curPwr * curPwr % mod;
                curExp *= 2;
            }

            return curPwr * Power(b, exp - curExp, mod) % mod;
        }
    }
}
