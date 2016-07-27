using System;
using System.Text.RegularExpressions;

namespace Problem_01
{
    class MatchFullName
    {
        static void Main()
        {
            string input = Console.ReadLine();
            Regex rgx = new Regex(@"\b[A-Z][a-z]+ [A-Z][a-z]+\b");
            while (input != "end")
            {
                if (rgx.IsMatch(input))
                {
                    Console.WriteLine(input);
                }
                input = Console.ReadLine();
            }
        }
    }
}