using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_08
{
    class HandsOfCards
    {
        static void Main()
        {
            Dictionary<string, HashSet<string>> personCards = new Dictionary<string, HashSet<string>>();
            string input = Console.ReadLine();
            while (input != "JOKER")
            {
                string[] firstSplit = input.Trim().Split(':');
                string[] cards = firstSplit[1].Trim().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (!personCards.ContainsKey(firstSplit[0]))
                {
                    personCards.Add(firstSplit[0], new HashSet<string>());
                }
                for (int i = 0; i < cards.Length; i++)
                {
                    personCards[firstSplit[0]].Add(cards[i]);
                }
                input = Console.ReadLine();
            }
            foreach (var person in personCards)
            {
                Console.Write($"{person.Key}: ");
                int sum = 0;
                foreach (var card in personCards[person.Key])
                {
                    int power = 0;
                    switch (card.Substring(0, card.Length - 1))
                    {
                        case "J":
                            power = 11;
                            break;
                        case "Q":
                            power = 12;
                            break;
                        case "K":
                            power = 13;
                            break;
                        case "A":
                            power = 14;
                            break;
                        default:
                            power = int.Parse(card.Substring(0, card.Length - 1));
                            break;
                    }
                    int type = 0;
                    switch (card[card.Length - 1])
                    {
                        case 'S':
                            type = 4;
                            break;
                        case 'H':
                            type = 3;
                            break;
                        case 'D':
                            type = 2;
                            break;
                        case 'C':
                            type = 1;
                            break;
                        default:
                            break;
                    }
                    sum += power * type;
                }
                Console.WriteLine(sum);
            }
        }
    }
}