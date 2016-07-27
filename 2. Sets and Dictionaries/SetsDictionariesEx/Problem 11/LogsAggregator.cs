using System;
using System.Collections.Generic;

namespace Problem_11
{
    class LogsAggregator
    {
        static void Main()
        {
            int lines = int.Parse(Console.ReadLine());
            SortedDictionary<string, SortedSet<string>> usernameIPs = new SortedDictionary<string, SortedSet<string>>();
            Dictionary<string, int> usernameDuration = new Dictionary<string, int>();
            for (int i = 0; i < lines; i++)
            {
                string[] data = Console.ReadLine().Split(' ');
                string IP = data[0];
                string username = data[1];
                int duration = int.Parse(data[2]);
                if (!usernameIPs.ContainsKey(username))
                {
                    usernameIPs.Add(username, new SortedSet<string>());
                    usernameDuration.Add(username, 0);
                }
                usernameIPs[username].Add(IP);
                usernameDuration[username] += duration;
            }
            foreach (var user in usernameIPs.Keys)
            {
                Console.Write($"{user}: {usernameDuration[user]} [");
                Console.Write(string.Join(", ", usernameIPs[user]));
                Console.WriteLine("]");
            }
        }
    }
}