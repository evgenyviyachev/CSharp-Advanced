using System;
using System.Text.RegularExpressions;

namespace Problem_03
{
    class SeriesOfLetters
    {
        static void Main()
        {
            string text = Console.ReadLine();
            Regex rgx = new Regex(@"([A-Za-z])\1+");
            Match match = rgx.Match(text);
            while (match.Success)
            {                
                char letter = match.Value.ToString()[0];
                text = text.Replace(match.Value, letter.ToString());
                match = rgx.Match(text);
            }
            Console.WriteLine(text);
        }
    }
}