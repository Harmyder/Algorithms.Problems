using System;
using System.Linq;

namespace KickStart.Tasks
{
    internal class SortTheFabrics
    {
        public static void Run(int testNumber)
        {
            var count = int.Parse(Console.ReadLine());

            var fabrics = new Fabric[count];
            for (var i = 0; i < count; i++)
            {
                var parts = Console.ReadLine().Split(' ');
                fabrics[i] = new Fabric(parts[0], int.Parse(parts[1]), int.Parse(parts[2]));
            }

            Array.Sort(fabrics, (x, y) =>
            {
                var isTie = x.Color == y.Color;
                if (isTie)
                {
                    return x.U.CompareTo(y.U);
                }
                return x.Color.CompareTo(y.Color);
            });

            var fabrics2 = fabrics.ToArray();

            Array.Sort(fabrics, (x, y) =>
            {
                var isTie = x.D == y.D;
                if (isTie)
                {
                    return x.U.CompareTo(y.U);
                }
                return x.D.CompareTo(y.D);
            });

            var res = 0;
            for (var i = 0; i < count; i++)
            {
                if (fabrics[i].U == fabrics2[i].U)
                {
                    ++res;
                }
            }

            Console.WriteLine($"Case #{testNumber + 1}: {res}");
        }

        private struct Fabric
        {
            public Fabric(string color, int d, int u)
            {
                Color = color;
                D = d;
                U = u;
            }

            public string Color { get; set; }
            public int D { get; set; }
            public int U { get; set; }
        }
    }
}
