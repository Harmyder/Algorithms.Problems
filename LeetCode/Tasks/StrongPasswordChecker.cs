namespace LeetCode.Tasks
{
    internal class StrongPasswordChecker
    {
        private const int MinLen = 6;
        private const int MaxLen = 20;
        private const int MaxRunLength = 2;

        private bool _hasLower;
        private bool _hasUpper;
        private bool _hasDigit;

        public int Check(string password)
        {
            if (password.Length < 3)
            {
                return MinLen - password.Length;
            }

            _hasLower = password.Any(x => char.IsLower(x));
            _hasUpper = password.Any(x => char.IsUpper(x));
            _hasDigit = password.Any(x => char.IsDigit(x));
            var toFixCount = (_hasLower ? 0 : 1) + (_hasUpper ? 0 : 1) + (_hasDigit ? 0 : 1);

            var toAdd = Math.Max(MinLen - password.Length, 0);
            var toDelete = Math.Max(password.Length - MaxLen, 0);

            toFixCount = Math.Max(toFixCount - toAdd, 0);

            var opsCount = toAdd + toDelete;

            var tooLongCharRunsAll = Split(password).Where(x => x > MaxRunLength);

            var tooLongCharRuns = new List<int>[MaxRunLength + 1];
            for (var i = 0; i <= MaxRunLength; ++i)
            {
                tooLongCharRuns[i] = tooLongCharRunsAll.Where(x => x % (MaxRunLength + 1) == i).ToList();
            }

            while (toDelete > 0 && tooLongCharRuns.Aggregate(0, (total, next) => total + next.Count) > 0)
            {
                var mostEffective = 0;
                for (var i = 0; i < MaxRunLength && tooLongCharRuns[mostEffective].Count == 0; ++i) ++mostEffective;
                var toTake = mostEffective == 0 ? Math.Min(tooLongCharRuns[mostEffective].Count, toDelete) : 1;
                toDelete -= toTake;
                var stillTooLong = tooLongCharRuns[mostEffective].Take(toTake).Select(x => x - 1).Where(x => x > MaxRunLength);
                tooLongCharRuns[(mostEffective + 2) % (MaxRunLength + 1)].AddRange(stillTooLong);
                tooLongCharRuns[mostEffective] = tooLongCharRuns[mostEffective].Skip(toTake).ToList();
            }

            if (toAdd > 0)
            {
                for (var i = 0; i < MaxRunLength; ++i)
                {
                    if (tooLongCharRuns[i].Any())
                    {
                        var newLength = tooLongCharRuns[i][0] - 2;
                        tooLongCharRuns[i].RemoveAt(0);
                        if (newLength > MaxRunLength)
                        {
                            tooLongCharRuns[newLength % (MaxRunLength + 1)].Add(newLength);
                        }
                        --toAdd;
                    }
                }
            }

            var replacedCount = 0;

            foreach (var item in tooLongCharRuns)
            {
                replacedCount += item.Aggregate(0, (total, next) => total + next / (MaxRunLength + 1));
            }

            opsCount += replacedCount;

            opsCount += Math.Max(toFixCount - replacedCount, 0);

            return opsCount;
        }

        private int[] Split(string s)
        {
            var cur = 0;
            var charRuns = new List<char[]>();
            while (cur < s.Length)
            {
                charRuns.Add(s.Skip(cur).TakeWhile(x => x == s[cur]).ToArray());
                cur += charRuns.Last().Length;
            }
            return charRuns.Select(x => x.Length).ToArray();
        }
    }
}
