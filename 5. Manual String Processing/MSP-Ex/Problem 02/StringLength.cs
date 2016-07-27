using System;

namespace Problem_02
{
    class StringLength
    {
        static void Main()
        {
            string input = Console.ReadLine();
            if (input.Length >= 20)
            {
                for (int i = 0; i < 20; i++)
                {
                    Console.Write(input[i]);
                }
                Console.WriteLine();
            }
            else
            {
                int difference = 20 - input.Length;
                Console.Write(input);
                for (int i = 0; i < difference; i++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}