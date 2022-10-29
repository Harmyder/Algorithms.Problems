using System;
using System.Collections.Generic;

namespace KickStart.Sdk
{
    internal static class Numeric
    {
        public static int Inverse(int a, int modulo)
        {
            var res = ExtendedEuclid(a, modulo);
            return (res.Item2 + modulo) % modulo;
        }

        public static int Factorial(int n)
        {
            return (int)FactorialInternal(n);
        }

        public static int Factorial(int n, int modulo = 1)
        {
            return (int)FactorialInternal(n, modulo);
        }

        public static int SubFactorial(int n, int k)
        {
            return (int)SubFactorialInternal(n, k);
        }

        public static List<int> PrimeFactorsSlow(int num)
        {
            var factors = new List<int>();

            for (var i = 2; i <= num; ++i)
            {
                if (num % i == 0)
                {
                    factors.Add(i);
                    num /= i--;
                }
            }

            return factors;
        }

        public static long Choose(int n, int k)
        {
            if (n < k) throw new ArgumentException();

            return SubFactorial(n, n - k) / Factorial(k);
        }

        // Returns d = GCD(x, y) and x, y such, that ax + by = d
        private static (int, int, int) ExtendedEuclid(int a, int b)
        {
            if (b == 0) return (a, 1, 0);
            var (d, x, y) = ExtendedEuclid(b, a % b);
            return (d, y, x - (a / b) * y);
        }

        private static long FactorialInternal(long n)
        {
            if (n == 0) return 1;
            return n * FactorialInternal(n - 1);
        }

        private static long FactorialInternal(long n, int modulo)
        {
            if (n == 0) return 1;
            return n * FactorialInternal(n - 1, modulo) % modulo;
        }

        private static long SubFactorialInternal(long n, int k)
        {
            if (n == 0 || n == k) return 1;
            return n * SubFactorialInternal(n - 1, k);
        }
    }
}
