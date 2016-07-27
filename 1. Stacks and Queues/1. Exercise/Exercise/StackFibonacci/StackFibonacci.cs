using System;
using System.Collections.Generic;

namespace _9.StackFibonacci
{
    class StackFibonacci
    {
        static void Main()
        {
            Stack<long> fibNums = new Stack<long>();
            fibNums.Push(1);
            fibNums.Push(1);
            int position = int.Parse(Console.ReadLine()) - 1;
            for (int i = 0; i < position - 1; i++)
            {
                long secondNum = fibNums.Pop();
                long firstNum = fibNums.Peek();
                fibNums.Push(secondNum);
                fibNums.Push(firstNum + secondNum);
            }
            Console.WriteLine(fibNums.Peek());
        }
    }
}