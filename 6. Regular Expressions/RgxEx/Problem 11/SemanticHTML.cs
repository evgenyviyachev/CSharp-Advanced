using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Problem_11
{
    class SemanticHTML
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string openTagPattern = @"<div(\s*.+)?\s+\w+\s?=\s?""(\w+)""\s*(\s.+)?>";
            string closeTagPattern = @"<\/div>\s*<!--\s*(\w+)\s*-->";
            List<string> output = new List<string>();

            while (input != "END")
            {
                if (Regex.IsMatch(input, openTagPattern))
                {
                    var matches = Regex.Match(input, openTagPattern);
                    string tagName = matches.Groups[2].Value;
                    string beforeTagname = matches.Groups[1].Value;
                    string afterTagname = matches.Groups[3].Value;
                    string result = "<" + tagName + beforeTagname + afterTagname + ">";
                    output.Add(result);
                }
                else if (Regex.IsMatch(input, closeTagPattern))
                {
                    var matches = Regex.Match(input, closeTagPattern);
                    string tagName = matches.Groups[1].Value;
                    string result = "</" + tagName + ">";
                    output.Add(result);
                }
                else
                {
                    output.Add(input);
                }
                input = Console.ReadLine();
            }

            foreach (var item in output)
            {
                Console.WriteLine(item);
            }
        }
    }
}