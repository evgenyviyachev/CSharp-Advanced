using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_02
{
    class SetsOfElements
    {
        static void Main()
        {
            int[] lengths = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < lengths[0]; i++)
            {
                firstSet.Add(int.Parse(Console.ReadLine()));
            }
            for (int i = 0; i < lengths[1]; i++)
            {
                secondSet.Add(int.Parse(Console.ReadLine()));
            }

            var finalSet = firstSet.Intersect(secondSet);
            Console.WriteLine(string.Join(" ", finalSet));
        }
    }
}