using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_06
{
    class CountSubstringOccurences
    {
        static void Main()
        {
            string text = Console.ReadLine();
            string searchString = Console.ReadLine();
            int counter = 0;
            for (int i = 0; i < text.Length - searchString.Length; i++)
            {
                if (text.Substring(i, searchString.Length).ToLower() == searchString.ToLower())
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }
    }
}