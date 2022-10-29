namespace LeetCode.Tasks
{
    internal sealed class FindClosestPalindrome
    {
        public string NearestPalindromic(string n)
        {
            if (n.Length == 1) return Math.Abs(int.Parse(n) - 1).ToString();

            var original = long.Parse(n);
            var pal = n.ToArray();
            var halfLen = pal.Length / 2;

            for (int i = halfLen - 1; i >= 0; i--)
            {
                if (pal[i] != pal[pal.Length - 1 - i])
                {
                    pal[pal.Length - 1 - i] = pal[i];
                }
            }

            var first = long.Parse(new string(pal));

            long bigger;
            long smaller;

            if (first == original)
            {
                bigger = IncreaseFromCenter((char[])pal.Clone());
                smaller = DecreaseFromCenter((char[])pal.Clone());
            }
            else if (first > original)
            {
                bigger = first;
                smaller = DecreaseFromCenter((char[])pal.Clone());
            }
            else
            {
                bigger = IncreaseFromCenter((char[])pal.Clone());
                smaller = first;
            }

            if (bigger - original < original - smaller)
            {
                return bigger.ToString();
            }
            else
            {
                return smaller.ToString();
            }
        }

        private long DecreaseFromCenter(char[] pal) => long.Parse(UpdateFromCenter(pal, '0', '9', -1));
        private long IncreaseFromCenter(char[] pal) => long.Parse(UpdateFromCenter(pal, '9', '0', 1));

        private char[] UpdateFromCenter(char[] pal, char from, char to, int inc)
        {
            var pal2 = (char[])pal.Clone();
            var bbb = pal2.Length % 2 == 0 ? 1 : 0;
            var halfLen = pal2.Length / 2;

            var fromCenter = 0;
            while (halfLen + fromCenter < pal2.Length && pal2[halfLen + fromCenter] == from)
            {
                pal2[halfLen + fromCenter] = pal2[halfLen - bbb - fromCenter] = to;
                fromCenter++;
            }
            if (halfLen + fromCenter < pal2.Length)
            {
                pal2[halfLen + fromCenter] += (char)inc;
                pal2[halfLen - bbb - fromCenter] = pal2[halfLen + fromCenter];
                if (pal2.First() == '0') pal2[pal2.Length - 1] = '9';
            }
            else
            {
                if (inc == 1)
                {
                    pal2 = pal2.ToList().Concat(new List<char> { '1' }).ToArray();
                    pal2[0] = '1';
                }
            }

            return pal2;
        }
    }
}
