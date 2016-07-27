using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Problem_09
{
    class QueryMass
    {
        static void Main()
        {
            string inputLine = Console.ReadLine();
            string pattern = @"[^\?\&\s]+=[^\?\&\s]+";
            string encodedSpace = @"(?:\+|%20)";
            string whiteSpaces = @"\s+";
            Regex rgx = new Regex(pattern);
            Regex rgx2 = new Regex(encodedSpace);
            Regex rgx3 = new Regex(whiteSpaces);
            while (inputLine != "END")
            {
                Dictionary<string, List<string>> keyValue = new Dictionary<string, List<string>>();
                Dictionary<string, int> keyOrder = new Dictionary<string, int>();
                Match match = rgx.Match(inputLine);
                while (match.Success)
                {
                    int counter = 1;
                    string currentPair = rgx3.Replace(rgx2.Replace(match.ToString(), " "), " ");
                    string[] currentKeyValue = currentPair.Split('=').Select(x => x.Trim()).ToArray();
                    string key = currentKeyValue[0];
                    string value = currentKeyValue[1];
                    if (!keyValue.ContainsKey(key))
                    {
                        keyValue.Add(key, new List<string>());
                        keyOrder.Add(key, counter);
                        counter++;
                    }
                    if (!keyValue[key].Contains(value))
                    {
                        keyValue[key].Add(value);
                    }
                    match = match.NextMatch();
                }

                var keysSorted = keyOrder.Keys.OrderBy(x => keyOrder[x]).Select(x => x);
                StringBuilder sb = new StringBuilder();
                foreach (var key in keysSorted)
                {
                    sb.Append(key);
                    sb.Append("=[");
                    sb.Append(string.Join(", ", keyValue[key]));
                    sb.Append("]");
                }
                Console.WriteLine(sb.ToString());
                inputLine = Console.ReadLine();
            }
        }
    }
}