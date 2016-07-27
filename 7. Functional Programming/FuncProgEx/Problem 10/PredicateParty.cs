using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_10
{
    class PredicateParty
    {
        static void Main()
        {
            List<string> peopleAttending = Console.ReadLine().Split().ToList();
            string input = Console.ReadLine();
            while (input != "Party!")
            {
                string[] data = input.Split();
                string criteria = data[1];
                string parameter = data[2];
                if (data[0] == "Remove")
                {
                    if (criteria == "StartsWith")
                    {
                        peopleAttending = Remove(peopleAttending, x => x.StartsWith(parameter));
                    }
                    else if (criteria == "EndsWith")
                    {
                        peopleAttending = Remove(peopleAttending, x => x.EndsWith(parameter));
                    }
                    else if (criteria == "Length")
                    {
                        int length = int.Parse(parameter);
                        peopleAttending = Remove(peopleAttending, x => x.Length == length);
                    }
                }
                else if (data[0] == "Double")
                {
                    if (criteria == "StartsWith")
                    {
                        peopleAttending = Double(peopleAttending, x => x.StartsWith(parameter));
                    }
                    else if (criteria == "EndsWith")
                    {
                        peopleAttending = Double(peopleAttending, x => x.EndsWith(parameter));
                    }
                    else if (criteria == "Length")
                    {
                        int length = int.Parse(parameter);
                        peopleAttending = Double(peopleAttending, x => x.Length == length);
                    }
                }
                input = Console.ReadLine();
            }
            if (peopleAttending.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
                return;
            }
            Console.WriteLine($"{string.Join(", ", peopleAttending)} are going to the party!");
        }

        public static List<string> Double(List<string> names, Predicate<string> condition)
        {
            int counter = 0;
            while (counter < names.Count)
            {
                if (condition(names[counter]))
                {
                    names.Insert(counter + 1, names[counter]);
                    counter += 2;
                    continue;
                }
                counter++;
            }
            return names;
        }

        public static List<string> Remove(List<string> names, Predicate<string> condition)
        {
            names.RemoveAll(x => condition(x));
            return names;
        }
    }
}