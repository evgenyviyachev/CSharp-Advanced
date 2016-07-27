using System;

namespace Problem_01
{
    class ReverseString
    {
        static void Main()
        {
            char[] input = Console.ReadLine().ToCharArray();
            Array.Reverse(input);
            Console.WriteLine(new string(input));
        }
    }
}