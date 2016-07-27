using System;
using System.Linq;

namespace Problem_09
{
    class TextFilter
    {
        static void Main()
        {
            string[] bannedWords = Console.ReadLine().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
            string[] asterix = new string[bannedWords.Length];
            string text = Console.ReadLine();
            for (int i = 0; i < bannedWords.Length; i++)
            {
                asterix[i] = new string('*', bannedWords[i].Length);
            }
            for (int i = 0; i < bannedWords.Length; i++)
            {
                text = text.Replace(bannedWords[i], asterix[i]);
            }
            Console.WriteLine(text);
        }
    }
}