using System;
using System.Linq;

namespace KickStart.Tasks
{
    internal class Walktober
    {
        public static int Run()
        {
            var mnp = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            var partsCount = mnp[0];
            var daysCount = mnp[1];
            var p = mnp[2] - 1;

            var max = new int[daysCount];
            int[] john = null;

            for (var i = 0; i < partsCount; ++i)
            {
                var participant = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
                if (i == p) john = participant;
                else
                {
                    for (var j = 0; j < daysCount; ++j)
                    {
                        max[j] = Math.Max(participant[j], max[j]);
                    }
                }
            }

            var need = 0;
            for (var j = 0; j < daysCount; ++j)
            {
                if (john[j] < max[j]) need -= john[j] - max[j];
            }

            return need;
        }
    }
}
