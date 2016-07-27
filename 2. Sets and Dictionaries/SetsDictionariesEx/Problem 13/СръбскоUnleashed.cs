using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Problem_13
{
    class СръбскоUnleashed
    {
        static void Main()
        {
            string pattern = @"^(([A-Za-z]+ ){1,3})@(([A-Za-z]+ ){1,3})([0-9]+ )([0-9]+)$";
            Regex regex = new Regex(pattern);
            int counter = 1;
            Dictionary<string, Dictionary<string, long[]>> venueSingerMoney = new Dictionary<string, Dictionary<string, long[]>>();
            Dictionary<string, int> venueOrder = new Dictionary<string, int>();
            string input = Console.ReadLine();
            while (input != "End")
            {
                if (regex.IsMatch(input))
                {
                    Match match = regex.Match(input);
                    string venue = match.Groups[3].ToString().Substring(0, match.Groups[3].ToString().Length - 1);
                    string singer = match.Groups[1].ToString().Substring(0, match.Groups[1].ToString().Length - 1);
                    int ticketPrice = int.Parse(match.Groups[5].ToString().Substring(0, match.Groups[5].ToString().Length - 1));
                    int ticketCount = int.Parse(match.Groups[6].ToString());
                    long money = Convert.ToInt64(ticketPrice * ticketCount);
                    if (!venueSingerMoney.ContainsKey(venue))
                    {
                        venueSingerMoney.Add(venue, new Dictionary<string, long[]>());
                        venueSingerMoney[venue].Add(singer, new long[2]);
                        venueSingerMoney[venue][singer][0] = money;
                        venueSingerMoney[venue][singer][1] = counter;
                        venueOrder.Add(venue, counter);
                    }
                    else if (!venueSingerMoney[venue].ContainsKey(singer))
                    {
                        venueSingerMoney[venue].Add(singer, new long[2]);
                        venueSingerMoney[venue][singer][0] = money;
                        venueSingerMoney[venue][singer][1] = counter;
                    }
                    else
                    {
                        venueSingerMoney[venue][singer][0] += money;
                    }
                }
                counter++;
                input = Console.ReadLine();
            }
            var venues = venueOrder.Keys.OrderBy(x => venueOrder[x]).Select(x => x);
            foreach (var venue in venues)
            {
                Console.WriteLine(venue);
                var singers = venueSingerMoney[venue].Keys.OrderByDescending(x => venueSingerMoney[venue][x][0])
                    .ThenBy(x => venueSingerMoney[venue][x][1]);
                foreach (var singer in singers)
                {
                    Console.WriteLine($"#  {singer} -> {venueSingerMoney[venue][singer][0]}");
                }
            }
        }
    }
}