using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.MaximumElement
{
    class MaximumElement
    {
        static void Main()
        {
            int lines = int.Parse(Console.ReadLine());
            Stack<int> numbers = new Stack<int>();
            for (int i = 0; i < lines; i++)
            {
                string[] command = Console.ReadLine().Trim().Split(' ');
                if (command.Length > 1)
                {
                    numbers.Push(int.Parse(command[1]));
                }
                else
                {
                    if (command[0].Equals("2"))
                    {
                        numbers.Pop();
                    }
                    else
                    {
                        Console.WriteLine(numbers.Max());
                    }
                }
            }
        }
    }
}