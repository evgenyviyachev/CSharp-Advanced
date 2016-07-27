using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Problem_16
{
    class ExtractHyperlinks
    {
        static void Main()
        {
            string currentLine = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            
            while (currentLine != "END")
            {
                sb.Append(currentLine);
                sb.Append(Environment.NewLine);
                currentLine = Console.ReadLine();
            }
            Regex regex = new Regex(@"(?:<a)(?:[\s_0-9a-zA-Z=""()]*?.*?)(?:href(?:[\s]*)?=(?:['""\s]*)?)([a-zA-Z:#\/._\-0-9!?=^+]*(\([""'a-zA-Z\s.()0-9]*\))?)(?:[\sa-zA-Z=""()0-9]*.*?)?(?:\>)");
            string text = sb.ToString();
            Match hyperlink = regex.Match(text);
            while (hyperlink.Success)
            {
                Console.WriteLine(hyperlink.Groups[1].Value);
                hyperlink = hyperlink.NextMatch();
            }
        }
    }
}