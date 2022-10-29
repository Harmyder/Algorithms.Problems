namespace LeetCode.Tasks
{
    internal class WildcardMatching
    {
        private const char AnySingle = '?';
        private const char AnySequence = '*';

        public static bool IsMatch(string s, string p)
        {
            p = Normalize(p);
            var runs = p.Split(AnySequence);
            return IsMatch_Internal(s, runs);
        }

        private static bool IsMatch_Internal(string s, string[] runs)
        {
            var cur = 0;

            for (var r = 0; r < runs.Length - 1; ++r)
            {
                if (cur + runs[r].Length > s.Length && runs[r].Length > 0) return false;

                var isRunMatch = true;
                for (var i = 0; i < runs[r].Length; ++i)
                {
                    if (!AreEqual(s[cur + i], runs[r][i]))
                    {
                        isRunMatch = false;
                    }
                }

                if (isRunMatch)
                {
                    cur += runs[r].Length;
                }
                else
                {
                    if (r == 0) return false;

                    cur += 1;
                    r -= 1;
                }
            }

            if (runs.Count() == 1)
            {
                if (runs.Last().Length != s.Length) return false;
            }
            else
            {
                if (runs.Last().Length == 0) return true;
                if (cur + runs.Last().Length > s.Length) return false;
                cur = s.Length - runs.Last().Length;
            }

            for (var i = 0; i < runs.Last().Length; ++i)
            {
                if (!AreEqual(s[cur + i], runs.Last()[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private static string Normalize(string p)
        {
            if (p == "") return "";
            var result = p[0].ToString();
            for (var i = 1; i < p.Length; ++i)
            {
                if (p[i] != AnySequence || p[i - 1] != AnySequence) result += p[i].ToString();
            }
            return result;
        }

        private static bool AreEqual(char a, char b)
        {
            return a == b || a == AnySingle || b == AnySingle;
        }
    }
}
