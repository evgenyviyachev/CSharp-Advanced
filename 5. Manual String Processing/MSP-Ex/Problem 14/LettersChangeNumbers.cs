using System;
using System.Text.RegularExpressions;

namespace Problem_14
{
    class LettersChangeNumbers
    {
        static void Main()
        {
            Regex whiteSpaces = new Regex("\\s+");
            string[] input = whiteSpaces.Replace(Console.ReadLine(), " ").Trim().Split(' ');
            double totalSum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                char firstLetter = input[i][0];
                char lastLetter = input[i][input[i].Length - 1];
                int letterPosition = 0;
                double number = double.Parse(input[i].Substring(1, input[i].Length - 2));
                if (char.IsUpper(firstLetter))
                {
                    letterPosition = firstLetter - 64;
                    number /= letterPosition;
                }
                else {
                    letterPosition = firstLetter - 96;
                    number *= letterPosition;
                }
                if (char.IsUpper(lastLetter))
                {
                    letterPosition = lastLetter - 64;
                    number -= letterPosition;
                }
                else {
                    letterPosition = lastLetter - 96;
                    number += letterPosition;
                }
                totalSum += number;
            }
            Console.WriteLine($"{totalSum:0.00}");
        }
    }
}