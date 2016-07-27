using System;
using System.Collections.Generic;

namespace _8.RecursiveFibonacci
{
    class RecursiveFibonacci
    {
        static void Main()
        {
            int input = int.Parse(Console.ReadLine()) - 1;
            Console.WriteLine(GetFibonacciNumber(input));
        }

        public static long GetFibonacciNumber(int input)
        {
            if (input < 2)
            {
                return 1;
            }
            return GetFibonacciNumber(input - 1) + GetFibonacciNumber(input - 2);
        }
    }
}