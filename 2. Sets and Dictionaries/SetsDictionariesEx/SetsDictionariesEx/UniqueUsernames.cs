using System;
using System.Collections.Generic;

namespace Problem_01
{
    class UniqueUsernames
    {
        static void Main()
        {
            HashSet<string> usernames = new HashSet<string>();
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                usernames.Add(Console.ReadLine());
            }
            foreach (var name in usernames)
            {
                Console.WriteLine(name);
            }
        }
    }
}