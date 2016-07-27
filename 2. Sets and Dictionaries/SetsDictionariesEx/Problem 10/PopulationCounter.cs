using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_10
{
    class PopulationCounter
    {
        static void Main()
        {
            Dictionary<string, Dictionary<string, int[]>> data = new Dictionary<string, Dictionary<string, int[]>>();
            Dictionary<string, long[]> countryPopulation = new Dictionary<string, long[]>();
            int counter = 1;
            string input = Console.ReadLine();
            while (input != "report")
            {
                string[] lineOfData = input.Trim().Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                string country = lineOfData[1];
                string city = lineOfData[0];
                int population = int.Parse(lineOfData[2]);
                if (!data.ContainsKey(country))
                {
                    data.Add(country, new Dictionary<string, int[]>());
                    data[country].Add(city, new int[2]);
                    data[country][city][0] = population;
                    data[country][city][1] = counter;
                    countryPopulation.Add(country, new long[2]);
                    countryPopulation[country][1] = Convert.ToInt64(counter);
                }
                else
                {
                    data[country].Add(city, new int[2]);
                    data[country][city][0] = population;
                    data[country][city][1] = counter;
                }
                counter++;
                input = Console.ReadLine();
            }

            foreach (var country in data.Keys)
            {
                long totalPopulation = 0;
                foreach (var population in data[country].Values)
                {
                    totalPopulation += Convert.ToInt64(population[0]);
                }
                countryPopulation[country][0] = totalPopulation;
            }

            var countries = countryPopulation.Keys.OrderByDescending(x => countryPopulation[x][0])
                .ThenBy(x => countryPopulation[x][1]).Select(x => x);

            foreach (var country in countries)
            {
                Console.WriteLine($"{country} (total population: {countryPopulation[country][0]})");
                var cities = data[country].Keys.OrderByDescending(x => data[country][x][0])
                .ThenBy(x => data[country][x][1]).Select(x => x);
                foreach (var city in cities)
                {
                    Console.WriteLine($"=>{city}: {data[country][city][0]}");
                }
            }
        }
    }
}