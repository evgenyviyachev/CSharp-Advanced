using System;
using System.Collections.Generic;
using System.Text;

namespace Problem_10
{
    class SimpleTextEditor
    {
        static void Main()
        {
            Stack<string> text = new Stack<string>();
            text.Push("");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Trim().Split(' ');
                if (command[0] == "1")
                {
                    StringBuilder sb = new StringBuilder(text.Peek());
                    sb.Append(command[1]);
                    text.Push(sb.ToString());
                }
                else if (command[0] == "2")
                {
                    int charsToErase = int.Parse(command[1]);
                    text.Push(text.Peek().Substring(0, text.Peek().Length - charsToErase));
                }
                else if (command[0] == "3")
                {
                    int index = int.Parse(command[1]) - 1;
                    char indexToReturn = text.Peek()[index];
                    Console.WriteLine(indexToReturn);
                }
                else
                {
                    text.Pop();
                }
            }
        }
    }
}