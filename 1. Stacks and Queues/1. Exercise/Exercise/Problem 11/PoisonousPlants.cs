using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_11
{
    class PoisonousPlants
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine().Trim());
            List<long> plants = Console.ReadLine().Trim()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse).ToList();
            int counter = 0;
            bool die = true;
            while (die)
            {
                Stack<int> alive = new Stack<int>();
                alive.Push(0);
                Stack<int> dead = new Stack<int>();
                for (int i = 1; i < plants.Count; i++)
                {                    
                    if (plants[i-1] >= plants[i])
                    {
                        alive.Push(i);
                    }
                    else
                    {
                        dead.Push(i);
                    }
                }
                if (dead.Count == 0)
                {
                    break;
                }
                while (dead.Count != 0)
                {
                    plants.RemoveAt(dead.Pop());
                }
                counter++;
            }
            Console.WriteLine(counter);
        }
    }
}