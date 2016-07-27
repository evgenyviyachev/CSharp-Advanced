using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_12
{
    class LegendaryFarming
    {
        static void Main()
        {
            Dictionary<string, int> legendary = new Dictionary<string, int>();
            legendary.Add("motes", 0);
            legendary.Add("shards", 0);
            legendary.Add("fragments", 0);
            SortedDictionary<string, int> junk = new SortedDictionary<string, int>();
            string input = Console.ReadLine();
            while (true)
            {
                string[] collected = input.Trim().Split(' ');
                for (int i = 0; i < collected.Length; i += 2)
                {
                    string material = collected[i + 1].ToLower();
                    int quantity = int.Parse(collected[i]);
                    if (material == "motes")
                    {
                        legendary[material] += quantity;
                        if (legendary[material] >= 250)
                        {
                            Console.WriteLine("Dragonwrath obtained!");
                            legendary[material] -= 250;
                            var legendaryMaterials = legendary.Keys
                                .OrderByDescending(x => legendary[x])
                                .ThenBy(x => x)
                                .Select(x => x);
                            foreach (var legendaryMaterial in legendaryMaterials)
                            {
                                Console.WriteLine($"{legendaryMaterial}: {legendary[legendaryMaterial]}");
                            }
                            foreach (var junkMaterial in junk.Keys)
                            {
                                Console.WriteLine($"{junkMaterial}: {junk[junkMaterial]}");
                            }
                            return;
                        }
                    }
                    else if (material == "shards")
                    {
                        legendary[material] += quantity;
                        if (legendary[material] >= 250)
                        {
                            Console.WriteLine("Shadowmourne obtained!");
                            legendary[material] -= 250;
                            var legendaryMaterials = legendary.Keys
                                .OrderByDescending(x => legendary[x])
                                .ThenBy(x => x)
                                .Select(x => x);
                            foreach (var legendaryMaterial in legendaryMaterials)
                            {
                                Console.WriteLine($"{legendaryMaterial}: {legendary[legendaryMaterial]}");
                            }
                            foreach (var junkMaterial in junk.Keys)
                            {
                                Console.WriteLine($"{junkMaterial}: {junk[junkMaterial]}");
                            }
                            return;
                        }
                    }
                    else if (material == "fragments")
                    {
                        legendary[material] += quantity;
                        if (legendary[material] >= 250)
                        {
                            Console.WriteLine("Valanyr obtained!");
                            legendary[material] -= 250;
                            var legendaryMaterials = legendary.Keys
                                .OrderByDescending(x => legendary[x])
                                .ThenBy(x => x)
                                .Select(x => x);
                            foreach (var legendaryMaterial in legendaryMaterials)
                            {
                                Console.WriteLine($"{legendaryMaterial}: {legendary[legendaryMaterial]}");
                            }
                            foreach (var junkMaterial in junk.Keys)
                            {
                                Console.WriteLine($"{junkMaterial}: {junk[junkMaterial]}");
                            }
                            return;
                        }
                    }
                    else
                    {
                        if (!junk.ContainsKey(material))
                        {
                            junk.Add(material, 0);
                        }
                        junk[material] += quantity;
                    }
                }
                input = Console.ReadLine();
            }
        }
    }
}