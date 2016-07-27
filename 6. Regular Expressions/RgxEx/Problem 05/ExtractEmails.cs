using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem_05
{
    class ExtractEmails
    {
        static void Main()
        {
            Regex rgx = new Regex(@"(?:^|\s)([a-z0-9]+[\.\-_a-z0-9]*[a-z0-9]+)@([a-z]+[a-z\-]*[\.]+[\.\-_a-z]*[a-z]+)");
            string text = Console.ReadLine();
            Match match = rgx.Match(text);
            while (match.Success)
            {
                Console.WriteLine($"{match.Groups[1].Value}@{match.Groups[2].Value}");
                match = match.NextMatch();
            }
        }
    }
}