namespace LeetCode.Tasks
{
    internal class NumOfWays2SeparateNum
    {
        private const int M = 1000 * 1000 * 1000 + 7;

        private int?[,] _table;

        public int NumberOfCombinations(string num)
        {
            if (num[0] == '0') return 0;

            _table = new int?[num.Length, num.Length];

            var wasBiggerSameLen = new bool[num.Length, 2];

            for (var i = 0; i < num.Length; i++) _table[i, i] = 1;

            for (var pos = 2; pos <= num.Length; pos++)
            {
                var stringIndex = pos - 1;

                for (var lastNumLen = 1; lastNumLen < pos; ++lastNumLen)
                {
                    var lastNum = (pos - lastNumLen, lastNumLen);
                    
                    if (num[lastNum.Item1] == '0') continue;

                    _table[lastNumLen - 1, stringIndex] = 0;

                    if (lastNumLen > 1)
                    {
                        var correctionForSameLen = wasBiggerSameLen[lastNumLen - 2, pos % 2] ? 0 : _table[lastNumLen - 2, stringIndex - lastNumLen];
                        var cur = _table[lastNumLen - 2, stringIndex - 1] + (correctionForSameLen ?? 0);

                        _table[lastNumLen - 1, stringIndex] = (_table[lastNumLen - 1, stringIndex] + cur % M) % M;
                    }

                    if (lastNumLen * 2 <= pos)
                    {
                        var prevNumSameLen = (pos - lastNumLen * 2, lastNumLen);
                        if (wasBiggerSameLen[lastNumLen - 1, (pos + 1) % 2] = IsNonDec(num, prevNumSameLen, lastNum))
                        {
                            var waysForPrevSameLen = _table[lastNumLen - 1, stringIndex - lastNumLen] ?? 0;
                            var waysFromSameLen = _table[lastNumLen - 1, stringIndex] + waysForPrevSameLen;
                            _table[lastNumLen - 1, stringIndex] = waysFromSameLen % M;
                        }
                    }
                    else
                    {
                        wasBiggerSameLen[lastNumLen - 1, (pos + 1) % 2] = false;
                    }
                }
            }

            for (var i = 0; i < num.Length; i++)
            {
                for (var j = 0; j < num.Length; j++)
                    Console.Write($"{_table[i, j],6} ");
                Console.WriteLine();
            }

            int total = 0;
            
            for (var i = 0; i < num.Length; i++)
            {
                var cur = _table[i, num.Length - 1] ?? 0;
                total = (total + cur) % M;
            }

            return total;
        }
        
        private static bool IsNonDec(string num, (int, int) prev, (int, int) cur)
        {
            if (prev.Item2 != cur.Item2) throw new InvalidOperationException();
            for (var i = 0; i < prev.Item2; ++i)
            {
                if (num[prev.Item1 + i] > num[cur.Item1 + i]) return false;
                if (num[prev.Item1 + i] < num[cur.Item1 + i]) return true;
            }
            return true;
        }
    }

    public class NumOfWays2SeparateNumOld
    {
        private const int M = 1000 * 1000 * 1000 + 7;

        private int?[,] _table;

        public int NumberOfCombinations(string num)
        {
            if (num[0] == '0') return 0;
            _table = new int?[num.Length, num.Length];

            for (var i = 0; i < num.Length; i++) _table[i, i] = 1;

            for (var pos = 2; pos <= num.Length; pos++)
            {
                var stringIndex = pos - 1;

                for (var lastNumLen = 1; lastNumLen < pos; ++lastNumLen)
                {
                    var count = 0;

                    var lastNum = num.Substring(pos - lastNumLen, lastNumLen);

                    if (lastNum[0] == '0') continue;

                    for (
                        var prevNumLen = 1;
                        prevNumLen <= lastNumLen && prevNumLen + lastNumLen <= pos;
                        ++prevNumLen)
                    {
                        var prevNum = num.Substring(pos - lastNumLen - prevNumLen, prevNumLen);
                        if (IsNonDec(prevNum, lastNum))
                        {
                            var cur = _table[prevNumLen - 1, stringIndex - lastNumLen] ?? 0;
                            count = (count + cur) % M;
                        }
                    }

                    _table[lastNumLen - 1, stringIndex] = count;
                }
            }

            for (var i = 0; i < num.Length; i++)
            {
                for (var j = 0; j < num.Length; j++)
                    Console.Write($"{_table[i, j],6} ");
                Console.WriteLine();
            }

            int total = 0;

            for (var i = 0; i < num.Length; i++)
            {
                var cur = _table[i, num.Length - 1] ?? 0;
                total = (total + cur) % M;
            }

            return total;
        }

        private static bool IsNonDec(string prev, string cur)
        {
            if (prev.Length < cur.Length) return true;
            if (prev.Length > cur.Length) throw new InvalidOperationException();
            return string.Compare(prev, cur) <= 0;
        }
    }
}
