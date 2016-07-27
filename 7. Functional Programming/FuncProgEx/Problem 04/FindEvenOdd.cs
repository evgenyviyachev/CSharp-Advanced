using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_04
{
    class FindEvenOdd
    {
        static void Main()
        {
            Predicate<int> condition;
            int[] boundaries = Console.ReadLine().Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int lowerBoundary = boundaries[0];
            int upperBoundary = boundaries[1];
            string wantedNums = Console.ReadLine();
            if (wantedNums == "even")
            {
                condition = x => x % 2 == 0;
            }
            else
            {
                condition = x => x % 2 == 1;
            }
            List<int> numsFinal = new List<int>();
            for (int i = lowerBoundary; i <= upperBoundary; i++)
            {
                if (condition(Math.Abs(i)))
                {
                    numsFinal.Add(i);
                }
            }
            Console.WriteLine(string.Join(" ", numsFinal));
        }
    }
}