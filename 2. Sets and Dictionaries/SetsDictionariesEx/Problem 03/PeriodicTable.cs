using System;
using System.Collections.Generic;

namespace Problem_03
{
    class PeriodicTable
    {
        static void Main()
        {
            int lines = int.Parse(Console.ReadLine());
            SortedSet<string> elements = new SortedSet<string>();
            for (int i = 0; i < lines; i++)
            {
                string[] currentElements = Console.ReadLine().Trim().Split(' ');
                for (int j = 0; j < currentElements.Length; j++)
                {
                    elements.Add(currentElements[j]);
                }
            }
            Console.WriteLine(string.Join(" ", elements));
        }
    }
}