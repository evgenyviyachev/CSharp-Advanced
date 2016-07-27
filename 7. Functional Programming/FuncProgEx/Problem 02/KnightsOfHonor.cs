using System;

namespace Problem_02
{
    class KnightsOfHonor
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split();
            Action<string> act = s => Console.WriteLine("Sir " + s);
            for (int i = 0; i < input.Length; i++)
            {
                act(input[i]);
            }
        }
    }
}