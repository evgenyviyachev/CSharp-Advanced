using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.BasicOperations
{
    class BasicOperations
    {
        static void Main()
        {
            string[] elements = Console.ReadLine().Split(' ');
            Stack<int> numbersInStack = new Stack<int>();
            string[] numbers = Console.ReadLine().Split(' ');
            for (int i = 0; i < numbers.Length; i++)
            {
                numbersInStack.Push(int.Parse(numbers[i]));
            }

            int numbersToPop = int.Parse(elements[1]);

            if (numbersToPop >= numbersInStack.Count)
            {
                Console.WriteLine(0);
                return;
            }

            for (int i = 0; i < numbersToPop; i++)
            {
                numbersInStack.Pop();
            }

            int numberToCheck = int.Parse(elements[2]);

            if (numbersInStack.Contains(numberToCheck))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(numbersInStack.Min());
            }
        }
    }
}