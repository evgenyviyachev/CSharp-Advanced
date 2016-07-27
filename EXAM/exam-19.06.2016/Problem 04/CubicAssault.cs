using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Numerics;

namespace Problem_04
{
    class CubicAssault
    {
        static void Main()
        {
            const int million = 1000000;

            Dictionary<string, Dictionary<string, BigInteger>> regionData = new Dictionary<string, Dictionary<string, BigInteger>>();
            string input = Console.ReadLine();
            string splitting = " -> ";

            while (input != "Count em all")
            {
                string[] currentData = Regex.Split(input, splitting).Select(x => x.Trim()).ToArray();
                string region = currentData[0];
                string type = currentData[1];
                BigInteger count = BigInteger.Parse(currentData[2]);

                if (!regionData.ContainsKey(region))
                {
                    regionData.Add(region, new Dictionary<string, BigInteger>());
                    regionData[region].Add("Black", 0);
                    regionData[region].Add("Red", 0);
                    regionData[region].Add("Green", 0);
                }

                regionData[region][type] += count;

                if (regionData[region]["Green"] >= million)
                {
                    BigInteger reds = regionData[region]["Red"];
                    BigInteger greens = regionData[region]["Green"];

                    reds += greens / million;
                    greens = greens % million;

                    regionData[region]["Red"] = reds;
                    regionData[region]["Green"] = greens;
                }

                if (regionData[region]["Red"] >= million)
                {
                    BigInteger blacks = regionData[region]["Black"];
                    BigInteger reds = regionData[region]["Red"];

                    blacks += reds / million;
                    reds = reds % million;

                    regionData[region]["Black"] = blacks;
                    regionData[region]["Red"] = reds;
                }

                input = Console.ReadLine();
            }
            
            var regions = regionData.Keys
                .OrderByDescending(x => regionData[x]["Black"])
                .ThenBy(x => x.Length)
                .ThenBy(x => x)
                .ToList();

            foreach (var region in regions)
            {
                Console.WriteLine(region);
                var types = regionData[region].Keys
                    .OrderByDescending(x => regionData[region][x])
                    .ThenBy(x => x)
                    .ToList();

                foreach (var type in types)
                {
                    Console.WriteLine($"-> {type} : {regionData[region][type]}");
                }
            }
        }
    }
}