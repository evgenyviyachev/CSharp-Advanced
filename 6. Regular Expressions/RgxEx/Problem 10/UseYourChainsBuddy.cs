using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Problem_10
{
    class UseYourChainsBuddy
    {
        static void Main()
        {
            string inputLine = Console.ReadLine();
            string pattern = @"<p>(.*?)<\/p>";
            string notSmallLetterNumbers = @"[^a-z0-9]+";
            string whiteSpaces = @"\s+";
            List<string> instructions = new List<string>();
            Regex rgx = new Regex(pattern);
            Regex rgx2 = new Regex(notSmallLetterNumbers);
            Regex rgx3 = new Regex(whiteSpaces);
            Match match = rgx.Match(inputLine);
            StringBuilder sbFinal = new StringBuilder();
            while (match.Success)
            {
                string beforeDecryption = rgx3.Replace(rgx2.Replace(match.Groups[1].Value, " "), " ");
                StringBuilder sb = new StringBuilder(beforeDecryption);
                for (int i = 0; i < sb.Length; i++)
                {
                    if (char.IsLetter(sb[i]))
                    {
                        if (sb[i] >= 'a' && sb[i] <= 'm')
                        {
                            sb[i] = (char)(sb[i] + 13);
                        }
                        else
                        {
                            sb[i] = (char)(sb[i] - 13);
                        }
                    }
                }
                sbFinal.Append(sb);
                match = match.NextMatch();
            }
            Console.WriteLine(sbFinal.ToString());
        }
    }
}