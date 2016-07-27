using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem_07
{
    class ValidUsernames
    {
        static void Main()
        {
            string[] usernames = Console.ReadLine().Split(new[] { ' ', '/', '\\', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            Regex rgx = new Regex(@"\b[a-zA-Z]\w{2,24}\b");
            List<string> validUsernames = new List<string>();
            for (int i = 0; i < usernames.Length; i++)
            {
                if (rgx.IsMatch(usernames[i]))
                {
                    validUsernames.Add(usernames[i]);
                }
            }
            int index = 0;
            int sum = int.MinValue;
            for (int i = 0; i < validUsernames.Count - 1; i++)
            {
                if (validUsernames[i].Length + validUsernames[i + 1].Length > sum)
                {
                    sum = validUsernames[i].Length + validUsernames[i + 1].Length;
                    index = i;
                }
            }
            Console.WriteLine(validUsernames[index]);
            Console.WriteLine(validUsernames[index + 1]);
        }
    }
}