namespace LeetCode.Tasks
{
    internal class GroupsOfStrings
    {
        public static List<int> Starts;

        public int[] GroupStrings(string[] words)
        {
            Array.Sort(words);

            var set = new HashSet<WordGroup>();

            var curWord = words[0];
            var curCount = 0;
            for (var i = 0; i < words.Length; i++)
            {
                if (words[i] != curWord)
                {
                    set.Add(new WordGroup(curWord, curCount));
                    curWord = words[i];
                    curCount = 0;
                }
                curCount++;
            }

            foreach (var word in set)
            {
                if (!word.IsVisited)
                {
                    Dfs(set, word);
                }
            }


        }

        private static void Dfs(HashSet<WordGroup> set, WordGroup start)
        {
            var word = start.Word;

            for 
        }

        private class WordGroup
        {
            private int _group;

            public WordGroup(string word, int count)
            {
                Word = word;
                Count = count;
            }

            public string Word { get; }
            public int Count { get; }
            public int Group
            {
                get => _group;
                set
                {
                    if (_group != 0) throw new InvalidOperationException();
                    _group = value;
                }
            }

            public bool IsVisited => _group != 0;
        }
    }
}
