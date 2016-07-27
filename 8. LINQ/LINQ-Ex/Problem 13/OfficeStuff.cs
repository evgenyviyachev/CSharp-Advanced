using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_13
{
    class OfficeStuff
    {
        static void Main()
        {
            var companyProducts = new Dictionary<string, List<string>>();
            var companyProductsCount = new Dictionary<string, Dictionary<string, int>>();
            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] input = Console.ReadLine()
                                .Split('-')
                                .Select(x => x.Trim(new[] { ' ', '|' }))
                                .ToArray();

                string company = input[0];
                int count = int.Parse(input[1]);
                string product = input[2];

                if (!companyProducts.ContainsKey(company))
                {
                    companyProducts.Add(company, new List<string>());
                    companyProductsCount.Add(company, new Dictionary<string, int>());
                }

                if (!companyProducts[company].Contains(product))
                {
                    companyProducts[company].Add(product);
                    companyProductsCount[company].Add(product, 0);
                }

                companyProductsCount[company][product] += count;
            }

            var sorted = companyProducts.Keys.OrderBy(x => x).ToList();

            foreach (var company in sorted)
            {
                Console.Write(company + ": ");
                string delim = "";
                foreach (var product in companyProducts[company])
                {
                    Console.Write(delim + product + "-" + companyProductsCount[company][product]);
                    delim = ", ";
                }
                Console.WriteLine();
            }
        }
    }
}