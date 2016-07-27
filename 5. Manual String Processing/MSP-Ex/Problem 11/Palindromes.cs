using System;
using System.Collections.Generic;

namespace Problem_11
{
    class Palindromes
    {
        static void Main()
        {
            SortedSet<string> palindromes = new SortedSet<string>();
            string[] wordsInText = Console.ReadLine().Split(new[] { ' ', ',', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < wordsInText.Length; i++)
            {
                string word = wordsInText[i];
                bool isPalindrome = true;
                for (int j = 0; j < word.Length / 2; j++)
                {
                    if (word[j] != word[word.Length - 1 - j])
                    {
                        isPalindrome = false;
                    }
                }

                if (isPalindrome)
                {
                    palindromes.Add(word);
                }
            }
            Console.WriteLine($"[{string.Join(", ", palindromes)}]");
        }
    }
}