using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.BalancedParentheses
{
    class BalancedParentheses
    {
        static void Main()
        {
            char[] symbols = Console.ReadLine().ToCharArray();
            if (symbols.Length % 2 == 1 || symbols.Length == 0)
            {
                Console.WriteLine("NO");
            }
            else
            {
                int length = symbols.Length / 2;
                Stack<char> firstHalf = new Stack<char>();
                Queue<char> secondHalf = new Queue<char>();
                for (int i = 0; i < length; i++)
                {
                    firstHalf.Push(symbols[i]);
                }
                for (int i = 0; i < length; i++)
                {
                    secondHalf.Enqueue(symbols[length + i]);
                }

                for (int i = 0; i < length; i++)
                {
                    char firstSymbol = firstHalf.Pop();
                    char secondsSymbol = secondHalf.Dequeue();

                    if ((firstSymbol == '(' && secondsSymbol != ')')
                        || (firstSymbol == '[' && secondsSymbol != ']')
                        || (firstSymbol == '{' && secondsSymbol != '}'))
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
                Console.WriteLine("YES");
            }
        }
    }
}