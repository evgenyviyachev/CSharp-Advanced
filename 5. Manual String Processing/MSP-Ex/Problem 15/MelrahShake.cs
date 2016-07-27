using System;
using System.Text;

namespace Problem_15
{
    class MelrahShake
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string key = Console.ReadLine();
            StringBuilder sb = new StringBuilder(input);
            StringBuilder sbKey = new StringBuilder(key);
            while (true)
            {
                int keyLength = key.Length;
                int firstMatch = input.IndexOf(key);
                int lastMatch = input.LastIndexOf(key);
                if (lastMatch == -1 || firstMatch == lastMatch)
                {
                    Console.WriteLine("No shake.");
                    Console.WriteLine(input);
                    return;
                }
                else {
                    Console.WriteLine("Shaked it.");
                    if (firstMatch + keyLength < lastMatch)
                    {
                        sb.Remove(firstMatch, keyLength);
                        sb.Remove(lastMatch - keyLength, keyLength);
                    }
                    else {
                        sb.Remove(firstMatch, lastMatch - firstMatch + keyLength);
                    }
                    int indexToRemoveFromKey = keyLength / 2;
                    sbKey.Remove(indexToRemoveFromKey, 1);
                }
                input = sb.ToString();
                key = sbKey.ToString();
                if (key == "")
                {
                    Console.WriteLine("No shake.");
                    Console.WriteLine(input);
                    return;
                }
            }
        }
    }
}