using System;

namespace Problem_12
{
    class CharacterMultiplier
    {
        static void Main()
        {
            string[] strings = Console.ReadLine().Split(' ');
            string firstString = strings[0];
            string secondString = strings[1];
            int maxLength = Math.Max(firstString.Length, secondString.Length);
            int minLength = Math.Min(firstString.Length, secondString.Length);
            long sum = 0;
            for (int i = 0; i < minLength; i++)
            {
                sum += firstString[i] * secondString[i];
            }
            for (int i = minLength; i < maxLength; i++)
            {
                try
                {
                    sum += firstString[i];
                }
                catch (Exception)
                {
                    
                }
                try
                {
                    sum += secondString[i];
                }
                catch (Exception)
                {

                }
            }
            Console.WriteLine(sum);
        }
    }
}