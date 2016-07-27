using System;
using System.Linq;

namespace Problem_08
{
    class CustomComparator
    {
        static void Main()
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Array.Sort(nums, EvenBeforeOddSortAscending);
            Console.WriteLine(string.Join(" ", nums));
        }

        public static int EvenBeforeOddSortAscending(int a, int b)
        {
            if (Math.Abs(a) % 2 == 0 && Math.Abs(b) % 2 == 1)
            {
                return -1;
            }
            else if (Math.Abs(a) % 2 == 1 && Math.Abs(b) % 2 == 0)
            {
                return 1;
            }
            return a.CompareTo(b);
        }
    }
}