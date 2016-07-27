using System;
using System.Text.RegularExpressions;

namespace Problem_02
{
    class MatchPhoneNumber
    {
        static void Main()
        {
            string input = Console.ReadLine();
            Regex rgx = new Regex(@"^ *\+359([ -])2\1\d{3}\1\d{4}\b");
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