using System;
using System.Text;

namespace Problem_10
{
    class UnicodeCharacters
    {
        static void Main()
        {
            string text = Console.ReadLine();
            StringBuilder sb = new StringBuilder("");
            for (int i = 0; i < text.Length; i++)
            {
                string unicodeChar = "\\u" + ((int)text[i]).ToString("x4");
                sb.Append(unicodeChar);
            }
            Console.WriteLine(sb.ToString());
        }
    }
}