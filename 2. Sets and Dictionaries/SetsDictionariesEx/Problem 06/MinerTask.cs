using System;
using System.Collections.Generic;

namespace Problem_06
{
    class MinerTask
    {
        static void Main()
        {
            string input = Console.ReadLine();
            int counter = 1;
            Dictionary<string, long> resourcesQuantity = new Dictionary<string, long>();
            string resource = "";
            while (input != "stop")
            {
                if (counter % 2 == 1)
                {
                    resource = input;
                    if (!resourcesQuantity.ContainsKey(resource))
                    {
                        resourcesQuantity.Add(resource, 0);
                    }
                }
                else
                {
                    long quantity = long.Parse(input) + resourcesQuantity[resource];
                    resourcesQuantity[resource] = quantity;
                }
                counter++;
                input = Console.ReadLine();
            }
            foreach (var kvp in resourcesQuantity)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}