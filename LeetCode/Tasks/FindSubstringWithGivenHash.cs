namespace LeetCode.Tasks
{
    internal class FindSubstringWithGivenHash
    {
        public string SubStrHash(string s, int power, int modulo, int k, int hashValue)
        {
            for (int i = 0; i < s.Length - k; i++)
            {
                long curPower1 = 1;
                var hash = 0;
                for (var j = 0; j < k; j++)
                {
                    hash = (int)((hash + Val(s[i + j]) * curPower1 % modulo) % modulo);
                    curPower1 = (curPower1 * power) % modulo;
                }
                if (hash == hashValue)
                {
                    Console.WriteLine($"{i}: {s.Substring(i, k)}");
                }
            }

            var partialHashes = new int[s.Length];
            var partialToPos = new Dictionary<int, List<int>>();

            partialHashes[0] = Val(s[0]) % modulo;
            partialToPos[partialHashes[0]] = new List<int> { 0 };

            long curPower = 1;
            for (var i = 1; i < s.Length; i++)
            {
                curPower = (curPower * power) % modulo;
                var partialHash = (int)((partialHashes[i - 1] + Val(s[i]) * curPower % modulo) % modulo);
                partialHashes[i] = partialHash;
                if (partialToPos.ContainsKey(partialHash))
                {
                    partialToPos[partialHash].Add(i);
                }
                else
                {
                    partialToPos[partialHash] = new List<int> { i };
                }
            }

            if (partialToPos.ContainsKey(hashValue))
            {
                var end = partialToPos[hashValue].Where(x => x == k - 1);
                if (end.Any())
                {
                    return s.Substring(0, k);
                }
            }

            curPower = 1;
            var curSuffixHash = hashValue;
            for (var i = 0; i < s.Length - 1; i++)
            {
                curPower = (curPower * power) % modulo;
                curSuffixHash = (int)((hashValue * curPower) % modulo);
                var fullHash = (partialHashes[i] + curSuffixHash) % modulo;
                if (partialToPos.ContainsKey(fullHash))
                {
                    var end = partialToPos[fullHash].Where(x => x == i + k);
                    if (end.Any())
                    {
                        var tentative = s.Substring(i + 1, k);
                        if (hashValue == ComputeHash(tentative, k, power, modulo)) return tentative;
                    }
                }
            }

            throw new InvalidDataException();
        }

        private static char Val(char ch) => (char)(ch - 'a' + 1);

        private static int ComputeHash(string s, int k, int power, int modulo)
        {
            long curPower = 1;
            var hash = 0;
            for (var j = 0; j < k; j++)
            {
                hash = (int)((hash + Val(s[j]) * curPower % modulo) % modulo);
                curPower = (curPower * power) % modulo;
            }
            return hash;
        }
    }
}
