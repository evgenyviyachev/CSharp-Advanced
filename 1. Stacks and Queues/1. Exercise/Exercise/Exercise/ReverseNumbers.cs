using System;
using System.Collections.Generic;

namespace Exercise
{
    class ReverseNumbers
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(' ');
            Stack<string> numbersInStack = new Stack<string>();
            for (int i = 0; i < numbers.Length; i++)
            {
                numbersInStack.Push(numbers[i]);
            }
            string delim = "";
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(delim + numbersInStack.Pop());
                delim = " ";
            }
            Console.WriteLine();
        }
    }
}