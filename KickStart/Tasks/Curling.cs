using System;
using System.Linq;

namespace KickStart.Tasks
{
    internal class Curling
    {
        public static (int, int) Run()
        {
            var rr = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            var rs = rr[0];
            var rh = rr[1];
            var maxDist = (rh + rs) * (rh + rs);

            var redCount = int.Parse(Console.ReadLine());
            var reds = new long[redCount];
            var closestRed = long.MaxValue;

            for (var i = 0; i < reds.Length; i++)
            {
                var xy = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

                reds[i] = Dist(xy[0], xy[1]);

                closestRed = Math.Min(closestRed, reds[i]);
            }

            var yellowCount = int.Parse(Console.ReadLine());
            var yellows = new long[yellowCount];
            var closestYellow = long.MaxValue;

            for (var i = 0; i < yellows.Length; i++)
            {
                var xy = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

                yellows[i] = Dist(xy[0], xy[1]);

                closestYellow = Math.Min(closestYellow, yellows[i]);
            }

            var yellowScore = 0;
            for (var i = 0; i < yellows.Length; i++)
            {
                if (yellows[i] < closestRed && yellows[i] <= maxDist) yellowScore++;
            }

            var redScore = 0;
            for (var i = 0; i < reds.Length; i++)
            {
                if (reds[i] < closestYellow && reds[i] <= maxDist) redScore++;
            }

            return (redScore, yellowScore);
        }

        private static long Dist(int x, int y)
        {
            return x * x + y * y;
        }
    }
}
