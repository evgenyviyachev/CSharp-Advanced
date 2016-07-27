using System;

namespace Problem_08
{
    class MultiplyBigNums
    {
        static void Main()
        {
            string num1 = Console.ReadLine();
            int num2 = int.Parse(Console.ReadLine());
            if (num1 == "0" || num2 == 0)
            {
                Console.WriteLine(0);
                return;
            }
            string result = "";
            int product = 0;
            for (int i = num1.Length - 1; i >= 0; i--)
            {
                int digit = int.Parse(num1[i].ToString());
                product += digit * num2;
                result = (product % 10).ToString() + result;
                product = product / 10;
            }
            if (product != 0)
            {
                result = product + result;
            }
            while (result[0] == '0')
            {
                result = result.Substring(1, result.Length - 1);
            }
            Console.WriteLine(result);
        }
    }
}