using System;

namespace Problem_01
{
    class ActionPrint
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split();
            Action<string> act = s => Console.WriteLine(s);
            for (int i = 0; i < input.Length; i++)
            {
                act(input[i]);
            }
        }
    }
}