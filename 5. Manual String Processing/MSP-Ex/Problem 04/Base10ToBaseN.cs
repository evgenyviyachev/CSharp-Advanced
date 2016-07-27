using System;
using System.Numerics;

namespace Problem_04
{
    class Base10ToBaseN
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Trim().Split();
            long baseToConvertTo = long.Parse(input[0]);
            BigInteger numBase10 = BigInteger.Parse(input[1]);
            if (numBase10 == 0)
            {
                Console.WriteLine(0);
                return;
            }
            int maxPower = 0;
            while (true)
            {
                if (numBase10 / BigInteger.Pow(baseToConvertTo, maxPower) <= 0)
                {
                    break;
                }
                maxPower++;
            }
            string num = "";
            for (int i = maxPower - 1; i >= 0; i--)
            {
                BigInteger digit = numBase10 / BigInteger.Pow(baseToConvertTo, i);
                num += digit.ToString();
                numBase10 = numBase10 % BigInteger.Pow(baseToConvertTo, i);
            }
            Console.WriteLine(num);
        }
    }
}