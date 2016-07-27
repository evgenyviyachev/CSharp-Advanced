using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Problem_04
{
    class ReplaceTag
    {
        static void Main()
        {
            string text = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            while (text != "end")
            {
                sb.Append(text);
                sb.Append(Environment.NewLine);
                text = Console.ReadLine();
            }
            text = sb.ToString();
            Regex beginning = new Regex(@"<a.*?(?<!"">)href\s*?=\s*?([""']\S.*?(>|class|[""']))>");
            Regex ending = new Regex(@"</a>");
            Match match = beginning.Match(text);
            Match match2 = ending.Match(text);
            while (match2.Success)
            {                
                text = text.Replace(match2.Value, @"[/URL]");
                match2 = ending.Match(text);
            }
            while (match.Success)
            {
                text = text.Replace(match.Value, @"[URL href=" + match.Groups[1].Value.ToString() + "]");
                match = beginning.Match(text);
            }
            Console.WriteLine(text);
        }
    }
}