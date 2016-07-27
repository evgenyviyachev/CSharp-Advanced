using System;
using System.Numerics;

namespace Problem_05
{
    class BaseNToBase10
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Trim().Split();
            long baseToConvertFrom = long.Parse(input[0]);
            string numBaseN = input[1];
            int maxPower = numBaseN.Length - 1;
            BigInteger numBase10 = 0;

            for (int i = 0; i <= maxPower; i++)
            {
                int digit = int.Parse(numBaseN[maxPower - i].ToString());
                numBase10 += digit * BigInteger.Pow(baseToConvertFrom, i);
            }
            Console.WriteLine(numBase10);
        }
    }
}