namespace LeetCode.Tasks
{
    internal class Regular
    {
        public static bool IsMatch(string s, string p)
        {
            var runs = p.Split('*');
            return IsMatch_Internal(s, runs);
        }

        private static bool IsMatch_Internal(string s, IEnumerable<string> runs)
        { 
            var i = 0;

            if (runs.Count() > 1)
            {
                var run = runs.First();

                for (var j = 0; j < run.Length - 1; j++)
                {
                    if (i >= s.Length || !AreEqual(run[j], s[i++])) return false;
                }

                var nextRuns = runs.Skip(1);

                if (nextRuns.First().Length == 0)
                {
                    return s.Skip(i).All(c => AreEqual(c, run.Last()));
                }

                for (; i < s.Length && AreEqual(s[i], run.Last()); ++i)
                {
                    var isMatch = IsMatch_Internal(s.Substring(i), nextRuns);
                    if (isMatch) return true;
                }

                return IsMatch_Internal(s.Substring(i), nextRuns);
            }
            else
            {
                foreach (var ch in runs.Last())
                {
                    if (i >= s.Length || !AreEqual(ch, s[i++])) return false;
                }

                return i == s.Length;
            }
        }

        private static bool AreEqual(char a, char b)
        {
            return a == b || a == '.' || b == '.';
        }
    }
}
