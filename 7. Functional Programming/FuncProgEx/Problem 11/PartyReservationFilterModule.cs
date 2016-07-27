using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_11
{
    class PartyReservationFilterModule
    {
        static void Main()
        {
            List<string> names = Console.ReadLine().Split().ToList();
            List<bool> isGoing = new List<bool>();
            for (int i = 0; i < names.Count; i++)
            {
                isGoing.Add(true);
            }
            string input = Console.ReadLine();
            while (input != "Print")
            {
                string[] data = input.Split(';');
                string action = data[0].Split()[0];
                string condition = data[1].Split()[0];
                string parameter = data[2];
                if (action == "Add")
                {
                    if (condition == "Starts")
                    {
                        isGoing = Filter(isGoing, names, x => x = false, x => x.StartsWith(parameter));
                    }
                    else if (condition == "Ends")
                    {
                        isGoing = Filter(isGoing, names, x => x = false, x => x.EndsWith(parameter));
                    }
                    else if (condition == "Length")
                    {
                        isGoing = Filter(isGoing, names, x => x = false, x => x.Length == int.Parse(parameter));
                    }
                    else if (condition == "Contains")
                    {
                        isGoing = Filter(isGoing, names, x => x = false, x => x.Contains(parameter));
                    }
                }
                else if (action == "Remove")
                {
                    if (condition == "Starts")
                    {
                        isGoing = Filter(isGoing, names, x => x = true, x => x.StartsWith(parameter));
                    }
                    else if (condition == "Ends")
                    {
                        isGoing = Filter(isGoing, names, x => x = true, x => x.EndsWith(parameter));
                    }
                    else if (condition == "Length")
                    {
                        isGoing = Filter(isGoing, names, x => x = true, x => x.Length == int.Parse(parameter));
                    }
                    else if (condition == "Contains")
                    {
                        isGoing = Filter(isGoing, names, x => x = true, x => x.Contains(parameter));
                    }
                }
                input = Console.ReadLine();
            }
            names.RemoveAll(x => isGoing[names.IndexOf(x)] == false);
            Console.WriteLine(string.Join(" ", names));
        }

        public static List<bool> Filter(List<bool> isGoing, List<string> names, Func<bool, bool> func, Predicate<string> condition)
        {
            for (int i = 0; i < names.Count; i++)
            {
                if (condition(names[i]))
                {
                    isGoing[i] = func(isGoing[i]);
                }
            }
            return isGoing;
        }
    }
}