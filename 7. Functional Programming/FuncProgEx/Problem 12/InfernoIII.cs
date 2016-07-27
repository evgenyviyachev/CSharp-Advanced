using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_12
{
    class InfernoIII
    {
        static void Main()
        {
            List<int> nums = Console.ReadLine().Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<bool> isNotExcluded = new List<bool>();
            for (int i = 0; i < nums.Count; i++)
            {
                isNotExcluded.Add(true);
            }
            nums.Insert(0, 0);
            nums.Add(0);
            isNotExcluded.Insert(0, false);
            isNotExcluded.Add(false);
            string input = Console.ReadLine();
            while (input != "Forge")
            {
                string[] data = input.Split(';');
                string action = data[0];
                string[] conditionFull = data[1].Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string condition = conditionFull[1];
                int parameter = int.Parse(data[2]);
                if (action == "Exclude")
                {
                    if (condition == "Right")
                    {
                        isNotExcluded = Filter(isNotExcluded, nums, x => x = false, (x, y, z) => y + z == parameter);
                    }
                    else if (condition == "Left" && conditionFull.Length == 2)
                    {
                        isNotExcluded = Filter(isNotExcluded, nums, x => x = false, (x, y, z) => x + y == parameter);
                    }
                    else if (condition == "Left" && conditionFull.Length == 3)
                    {
                        isNotExcluded = Filter(isNotExcluded, nums, x => x = false, (x, y, z) => x + y + z == parameter);
                    }
                }
                else if (action == "Reverse")
                {
                    if (condition == "Right")
                    {
                        isNotExcluded = Filter(isNotExcluded, nums, x => x = true, (x, y, z) => y + z == parameter);
                    }
                    else if (condition == "Left" && conditionFull.Length == 2)
                    {
                        isNotExcluded = Filter(isNotExcluded, nums, x => x = true, (x, y, z) => x + y == parameter);
                    }
                    else if (condition == "Left" && conditionFull.Length == 3)
                    {
                        isNotExcluded = Filter(isNotExcluded, nums, x => x = true, (x, y, z) => x + y + z == parameter);
                    }
                }
                input = Console.ReadLine();
            }
            for (int i = nums.Count - 1; i >= 0; i--)
            {
                if (!isNotExcluded[i])
                {
                    nums.RemoveAt(i);
                }
            }
            Console.WriteLine(string.Join(" ", nums));
        }

        public static List<bool> Filter(List<bool> isNotExcluded, List<int> nums, Func<bool, bool> func, Func<int, int, int, bool> condition)
        {
            for (int i = 1; i < nums.Count - 1; i++)
            {
                if (condition(nums[i - 1], nums[i], nums[i + 1]))
                {
                    isNotExcluded[i] = func(isNotExcluded[i]);
                }
            }
            return isNotExcluded;
        }
    }
}