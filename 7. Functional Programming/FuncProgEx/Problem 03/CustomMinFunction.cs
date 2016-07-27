using System;
using System.Linq;

namespace Problem_03
{
    class CustomMinFunction
    {
        static void Main()
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Func<int[], int> customMin = x =>
            {
                int min = int.MaxValue;
                foreach (var num in x)
                {
                    if (num < min)
                    {
                        min = num;
                    }
                }
                return min;
            };
            Console.WriteLine(customMin(nums));
        }
    }
}