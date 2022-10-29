using KickStart.Tasks;
using System;
using System.Collections.Generic;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var testsCount = int.Parse(Console.ReadLine());


            for (var i = 0; i < testsCount; ++i)
            {
                var res = HappySubarrays.Run();
                var output = $"Case #{i + 1}: {res}";
                Console.WriteLine(output);
            }

            Console.ReadLine();
        }
    }
}
