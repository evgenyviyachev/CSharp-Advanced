using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_09
{
    class UserLogs
    {
        static void Main()
        {
            SortedDictionary<string, Dictionary<string, int[]>> data = new SortedDictionary<string, Dictionary<string, int[]>>();
            string input = Console.ReadLine();
            int counter = 1;
            while (input != "end")
            {
                string[] currentData = input.Split(' ');
                string IP = currentData[0].Substring(3);
                string username = currentData[2].Substring(5);
                if (!data.ContainsKey(username))
                {
                    data.Add(username, new Dictionary<string, int[]>());
                }
                if (!data[username].ContainsKey(IP))
                {
                    data[username].Add(IP, new int[2]);
                    data[username][IP][0] = 0;
                    data[username][IP][1] = counter;
                }
                data[username][IP][0]++;
                counter++;
                input = Console.ReadLine();
            }
            foreach (var kvpInData in data)
            {
                Console.WriteLine($"{kvpInData.Key}:");
                var IPsOrder = kvpInData.Value.Keys.OrderBy(x => data[kvpInData.Key][x][1]).Select(x => x);
                string delim = "";
                foreach (var IPOrder in IPsOrder)
                {
                    Console.Write(delim + IPOrder);
                    Console.Write(" => ");
                    Console.Write(data[kvpInData.Key][IPOrder][0]);
                    delim = ", ";
                }
                Console.WriteLine(".");
            }
        }
    }
}