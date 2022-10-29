using System.Diagnostics;

namespace LeetCode
{
    internal static class Utils
    {
        public static void PrintResult<T1, TResult>(TResult expected, Func<T1, TResult> func, T1 param1)
        {
            TResult actual = default;
            var elapsed = BenchmarkOnMilliseconds(() => actual = func(param1));
            var paramsString = $"{param1}";
            PrintResult_Internal(elapsed, expected, actual, paramsString);
        }

        public static void PrintResult<T1, T2, TResult>(TResult expected, Func<T1, T2, TResult> func, T1 param1, T2 param2)
        {
            TResult actual = default;
            var elapsed = BenchmarkOnMilliseconds(() => actual = func(param1, param2));
            var paramsString = $"{param1}, {param2}";
            PrintResult_Internal(elapsed, expected, actual, paramsString);
        }

        public static void PrintResult<T1, T2, T3, T4, TResult>(TResult expected, Func<T1, T2, T3, T4, TResult> func, T1 param1, T2 param2, T3 param3, T4 param4)
        {
            TResult actual = default;
            var elapsed = BenchmarkOnMilliseconds(() => actual = func(param1, param2, param3, param4));
            var paramsString = $"{param1}, {param2}, {param3}, {param4}";
            PrintResult_Internal(elapsed, expected, actual, paramsString);
        }

        public static void PrintResult<T1, T2, T3, T4, T5, TResult>(TResult expected, Func<T1, T2, T3, T4, T5, TResult> func, T1 param1, T2 param2, T3 param3, T4 param4, T5 param5)
        {
            TResult actual = default;
            var elapsed = BenchmarkOnMilliseconds(() => actual = func(param1, param2, param3, param4, param5));
            var paramsString = $"{param1}, {param2}, {param3}, {param4}, {param5}";
            PrintResult_Internal(elapsed, expected, actual, paramsString);
        }

        public static void PrintResultEnumerable<T1, TResult>(IEnumerable<TResult> expected, Func<T1, IEnumerable<TResult>> func, T1 param1)
        {
            IEnumerable<TResult> actual = null;
            var elapsed = BenchmarkOnMilliseconds(() => actual = func(param1));
            var paramsString = $"{param1}";
            PrintResult_Internal(elapsed, expected, actual, paramsString);
        }

        public static void PrintResultEnumerable<T1, T2, TResult>(IEnumerable<TResult> expected, Func<T1, T2, IEnumerable<TResult>> func, T1 param1, T2 param2)
        {
            IEnumerable<TResult> actual = null;
            var elapsed = BenchmarkOnMilliseconds(() => actual = func(param1, param2));
            var paramsString = $"{param1}, {param2}";
            PrintResult_Internal(elapsed, expected, actual, paramsString);
        }

        private static void PrintResult_Internal<TResult>(long milliseconds, TResult expected, TResult actual, string paramsString)
            => PrintResult_Internal2(
                milliseconds,
                expected.ToString(),
                actual.ToString(),
                EqualityComparer<TResult>.Default.Equals(expected, actual),
                paramsString);

        private static void PrintResult_Internal<TResult>(long milliseconds, IEnumerable<TResult> expected, IEnumerable<TResult> actual, string paramsString)
            => PrintResult_Internal2(
                milliseconds,
                $"{{{string.Join(", ", expected)}}}",
                $"{{{string.Join(", ", actual)}}}",
                expected.SequenceEqual(actual),
                paramsString);

        private static void PrintResult_Internal2(long milliseconds, string expected, string actual, bool areEqual, string paramsString)
        {
            var color = Console.ForegroundColor;

            if (areEqual)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"({paramsString}) [{milliseconds, 6}]: {expected}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"({paramsString}) [{milliseconds, 6}]: {expected} =/= {actual}");
            }

            Console.ForegroundColor = color;
        }

        private static long BenchmarkOnMilliseconds(Action action)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            action();
            stopWatch.Stop();
            return stopWatch.ElapsedMilliseconds;
        }
    }
}
