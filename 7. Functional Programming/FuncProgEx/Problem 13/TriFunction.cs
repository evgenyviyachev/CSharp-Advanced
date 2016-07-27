using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_13
{
    class TriFunction
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split().ToList();
            Func<string, int, bool> function = (x, y) =>
                {
                    int sum = 0;
                    for (int i = 0; i < x.Length; i++)
                    {
                        sum += x[i];
                    };
                    if (sum >= y)
                    {
                        return true;
                    }
                    return false;
                };
            Func<Func<string, int, bool>, List<string>, int, string> mainFunc = (x, y, z) =>
            {
                foreach (var name in y)
                {
                    if (x(name, z))
                    {
                        return name;
                    }
                }
                return "";
            };
            Console.WriteLine(mainFunc(function, names, n));
        }
    }
}