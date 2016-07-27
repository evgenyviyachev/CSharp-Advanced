using System;

namespace Problem_07
{
    class PredicateForNames
    {
        static void Main()
        {
            int length = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();
            Action<string[], int> act = Print;
            act(names, length);
        }

        public static void Print(string[] names, int length)
        {
            foreach (var name in names)
            {
                if (name.Length <= length)
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}