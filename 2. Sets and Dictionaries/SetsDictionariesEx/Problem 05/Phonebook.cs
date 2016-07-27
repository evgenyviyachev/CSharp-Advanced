using System;
using System.Collections.Generic;

namespace Problem_05
{
    class Phonebook
    {
        static void Main()
        {
            Dictionary<string, string> phonebook = new Dictionary<string, string>();
            string input = Console.ReadLine();
            while (input != "search")
            {
                string[] line = input.Split('-');
                if (!phonebook.ContainsKey(line[0]))
                {
                    phonebook.Add(line[0], line[1]);
                }
                else
                {
                    phonebook[line[0]] = line[1];
                }
                input = Console.ReadLine();
            }
            input = Console.ReadLine();

            while (input != "stop")
            {
                if (phonebook.ContainsKey(input))
                {
                    Console.WriteLine($"{input} -> {phonebook[input]}");
                }
                else
                {
                    Console.WriteLine($"Contact {input} does not exist.");
                }
                input = Console.ReadLine();
            }
        }
    }
}