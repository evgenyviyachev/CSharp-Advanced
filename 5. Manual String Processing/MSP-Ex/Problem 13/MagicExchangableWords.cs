using System;
using System.Collections.Generic;

namespace Problem_13
{
    class MagicExchangableWords
    {
        static void Main()
        {
            string[] words = Console.ReadLine().Split(' ');
            string longerWord = "";
            string shorterWord = "";
            if (words[0].Length >= words[1].Length)
            {
                longerWord = words[0];
                shorterWord = words[1];
            }
            else
            {
                longerWord = words[1];
                shorterWord = words[0];
            }
            Dictionary<char, char> correspondingChars = new Dictionary<char, char>();
            bool isExchangable = true;
            for (int i = 0; i < shorterWord.Length; i++)
            {
                if (!correspondingChars.ContainsKey(shorterWord[i]))
                {
                    if (correspondingChars.ContainsValue(longerWord[i]))
                    {
                        isExchangable = false;
                        Console.WriteLine(isExchangable.ToString().ToLower());
                        return;
                    }
                    correspondingChars.Add(shorterWord[i], longerWord[i]);
                }
                else
                {
                    if (correspondingChars[shorterWord[i]] != longerWord[i])
                    {
                        isExchangable = false;
                        Console.WriteLine(isExchangable.ToString().ToLower());
                        return;
                    }
                }
            }

            for (int i = shorterWord.Length; i < longerWord.Length; i++)
            {
                if (!correspondingChars.ContainsValue(longerWord[i]))
                {
                    isExchangable = false;
                    Console.WriteLine(isExchangable.ToString().ToLower());
                    return;
                }
            }

            Console.WriteLine(isExchangable.ToString().ToLower());
        }
    }
}