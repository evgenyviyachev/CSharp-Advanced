using System;
using System.Collections.Generic;

namespace Problem_07
{
    class FixEmails
    {
        static void Main()
        {
            string input = Console.ReadLine();
            int counter = 1;
            Dictionary<string, string> personEmail = new Dictionary<string, string>();
            string person = "";
            while (input != "stop")
            {
                if (counter % 2 == 1)
                {
                    person = input;
                    if (!personEmail.ContainsKey(person))
                    {
                        personEmail.Add(person, "");
                    }
                }
                else
                {
                    personEmail[person] = input;
                }
                counter++;
                input = Console.ReadLine();
            }

            foreach (var kvp in personEmail)
            {
                string ending = kvp.Value[kvp.Value.Length - 2].ToString() + kvp.Value[kvp.Value.Length - 1].ToString();
                if (ending.ToLower() == "us" || ending.ToLower() == "uk")
                {
                    continue;
                }
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}