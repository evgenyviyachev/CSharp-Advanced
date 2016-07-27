using System;

namespace Problem_07
{
    class SumBigNums
    {
        static void Main()
        {
            string num1 = Console.ReadLine();
            string num2 = Console.ReadLine();
            string result = "";
            int maxLength = Math.Max(num1.Length, num2.Length);
            int sum = 0;
            for (int i = 0; i < maxLength; i++)
            {
                int digit1 = 0;
                int digit2 = 0;
                try
                {
                    digit1 = int.Parse(num1[num1.Length - 1 - i].ToString());
                }
                catch (Exception)
                {

                }
                try
                {
                    digit2 = int.Parse(num2[num2.Length - 1 - i].ToString());
                }
                catch (Exception)
                {

                }
                sum += digit1 + digit2;
                if (sum <= 9)
                {
                    result = sum.ToString() + result;
                    sum = 0;
                }
                else
                {
                    result = (sum % 10).ToString() + result;
                    sum = sum / 10;
                }
            }
            if (sum != 0)
            {
                result = sum + result;
            }
            while (result[0] == '0' && result.Length > 1)
            {
                result = result.Substring(1, result.Length - 1);
            }
            Console.WriteLine(result);
        }
    }
}