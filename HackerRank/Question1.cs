using System.Collections.Generic;
using System.Linq;

namespace HackerRank
{
    internal class Question1
    {
        public static int countFamilyLogins(List<string> logins)
        {
            var dict = new Dictionary<string, Dictionary<int, int>>();

            foreach (var login in logins)
            {
                var normalized = Normalize(login);

                if (!dict.ContainsKey(normalized.Login))
                {
                    dict.Add(normalized.Login, new Dictionary<int, int>());
                }

                var entry = dict[normalized.Login];
                if (entry.ContainsKey(normalized.Offset))
                {
                    ++entry[normalized.Offset];
                }
                else
                {
                    entry.Add(normalized.Offset, 1);
                }
            }

            long count = 0;

            foreach (var offsets in dict.Values.ToArray())
            {
                foreach (var o in offsets)
                {
                    var down = (o.Key - 1 + 26) % 26;
                    var up = (o.Key + 1) % 26;
                    if (offsets.ContainsKey(down))
                    {
                        count += o.Value * offsets[down];
                    }
                }
            }

            return (int)count;
        }

        private static (string Login, int Offset) Normalize(string login)
        {
            var offset = login[0] - 'a';
            var normalized = new string(login.Select(x => RotateDown(x, offset)).ToArray());
            return (normalized, offset);
        }

        private static char RotateDown(char ch, int offset)
        {
            return (char)((ch - 'a' + 26 - offset) % 26 + 'a');
        }
    }
}
