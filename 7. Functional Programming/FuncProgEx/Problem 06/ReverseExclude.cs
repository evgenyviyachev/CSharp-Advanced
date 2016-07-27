using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_06
{
    class ReverseExclude
    {
        static void Main()
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            Func<List<int>, List<int>> reverseList = x => {
                x.Reverse();
                return x;
            };
            nums = reverseList(nums);
            int n = int.Parse(Console.ReadLine());
            Predicate<int> isDivisible = x => x % n == 0;
            nums.RemoveAll(isDivisible);
            Console.WriteLine(string.Join(" ", nums));
        }
    }
}