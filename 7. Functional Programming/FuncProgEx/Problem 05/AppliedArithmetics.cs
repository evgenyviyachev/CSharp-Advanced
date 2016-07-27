using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_05
{
    class AppliedArithmetics
    {
        static void Main()
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            string input = Console.ReadLine();
            while (input != "end")
            {
                switch (input)
                {
                    case "add":
                        ApplyFunc(nums, x => x + 1);
                        break;
                    case "multiply":
                        ApplyFunc(nums, x => x * 2);
                        break;
                    case "subtract":
                        ApplyFunc(nums, x => x - 1);
                        break;
                    case "print":
                        Console.WriteLine(string.Join(" ", nums));
                        break;
                    default:
                        break;
                }
                input = Console.ReadLine();
            }
        }

        public static List<int> ApplyFunc(List<int> nums, Func<int, int> function)
        {
            for (int i = 0; i < nums.Count; i++)
            {
                nums[i] = function(nums[i]);
            }
            return nums;
        }
    }
}