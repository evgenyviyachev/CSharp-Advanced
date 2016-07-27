using System;
using System.Text.RegularExpressions;

namespace Problem_03
{
    class FormattingNumbers
    {
        static void Main()
        {
            Regex whiteSpaces = new Regex("\\s+");
            string[] input = whiteSpaces.Replace(Console.ReadLine(), " ").Trim().Split(' ');
            int a = int.Parse(input[0]);
            double b = double.Parse(input[1]);
            double c = double.Parse(input[2]);

            string hexadecimalNum = a.ToString("X");
            string result = "|" + hexadecimalNum.PadRight(10) + "|";
            string binaryNum = Convert.ToString(a, 2);
            result = result + binaryNum.PadLeft(10, '0').Substring(0, 10) + "|";
            result = result + b.ToString("0.00").PadLeft(10) + "|";
            result = result + c.ToString("0.000").PadRight(10) + "|";
            Console.WriteLine(result);
        }
    }
}