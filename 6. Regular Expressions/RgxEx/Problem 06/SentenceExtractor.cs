using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Problem_06
{
    class SentenceExtractor
    {
        static void Main()
        {
            string keyWord = Console.ReadLine();
            Regex rgx = new Regex(@"\b" + keyWord + @"\b");
            string text = Console.ReadLine();
            string[] sentences = Regex.Split(text, @"(?<=[.!?])", RegexOptions.IgnorePatternWhitespace).Select(x => x.ToString().Trim()).ToArray();
            if (!sentences[sentences.Length-1].EndsWith(".")
                && !sentences[sentences.Length - 1].EndsWith("!")
                && !sentences[sentences.Length - 1].EndsWith("?"))
            {
                sentences[sentences.Length - 1] = "";
            }
            for (int i = 0; i < sentences.Length; i++)
            {
                Match match = rgx.Match(sentences[i]);
                if (match.Success)
                {
                    Console.WriteLine(sentences[i]);
                }
            }
        }
    }
}