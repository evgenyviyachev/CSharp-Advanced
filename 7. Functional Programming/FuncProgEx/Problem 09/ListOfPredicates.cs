using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_09
{
    class ListOfPredicates
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            int[] sequence = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<int> divisibleNums = new List<int>();
            for (int i = 1; i <= N; i++)
            {
                if (isDivisibleBySequence(i, sequence))
                {
                    divisibleNums.Add(i);
                }
            }
            Console.WriteLine(string.Join(" ", divisibleNums));
        }

        public static bool isDivisibleBySequence(int number, int[] sequence)
        {
            for (int i = 0; i < sequence.Length; i++)
            {
                if (number % sequence[i] != 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}