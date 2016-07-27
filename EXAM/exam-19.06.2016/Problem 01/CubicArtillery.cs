using System;
using System.Collections.Generic;

namespace Problem_01
{
    class CubicArtillery
    {
        static void Main()
        {
            int capacity = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            Queue<string> bunkers = new Queue<string>();
            Queue<int> weapons = new Queue<int>();
            List<string> all = new List<string>();

            while (input != "Bunker Revision")
            {
                string[] currentData = input.Trim().Split();
                for (int i = 0; i < currentData.Length; i++)
                {
                    all.Add(currentData[i]);
                    int num;
                    bool isNumeric = int.TryParse(currentData[i], out num);

                    if (!isNumeric)
                    {
                        bunkers.Enqueue(currentData[i]);
                    }
                    else
                    {
                        weapons.Enqueue(num);
                    }
                }

                input = Console.ReadLine();
            }

            int currentFill = 0;
            int counter = 0;
            List<int> weaponsIn = new List<int>();
            string currentBunker = bunkers.Dequeue();

            while (weapons.Count > 0)
            {
                int currentWeapon = weapons.Dequeue();
                counter++;
                if (currentWeapon > capacity)
                {
                    if (bunkers.Count == 0)
                    {
                        break;
                    }
                    if (!HasBunkerBesidesCurrent(all, currentBunker, counter))
                    {
                        continue;
                    }
                    if (weaponsIn.Count > 0)
                    {
                        Console.WriteLine(currentBunker + " -> " + string.Join(", ", weaponsIn));
                    }
                    else
                    {
                        Console.WriteLine(currentBunker + " -> " + "Empty");
                    }

                    weaponsIn.Clear();
                    currentBunker = bunkers.Dequeue();
                    counter++;
                    continue;
                }

                if (currentFill + currentWeapon > capacity)
                {
                    if (bunkers.Count == 0 || !HasBunkerBesidesCurrent(all, currentBunker, counter))
                    {
                        while (true)
                        {
                            if (weaponsIn.Count > 0)
                            {
                                int weaponToRemove = weaponsIn[0];
                                weaponsIn.RemoveAt(0);
                                currentFill -= weaponToRemove;
                            }
                            else
                            {
                                break;
                            }

                            if (currentFill + currentWeapon <= capacity)
                            {
                                currentFill = currentFill + currentWeapon;
                                weaponsIn.Add(currentWeapon);
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine(currentBunker + " -> " + string.Join(", ", weaponsIn));
                        currentBunker = bunkers.Dequeue();
                        counter++;
                        weaponsIn.Clear();
                        weaponsIn.Add(currentWeapon);
                        currentFill = currentWeapon;
                    }
                }
                else
                {
                    currentFill += currentWeapon;
                    weaponsIn.Add(currentWeapon);
                }
            }
        }

        public static bool HasBunkerBesidesCurrent(List<string> all, string currentBunker, int counter)
        {
            int positionOne = all.IndexOf(currentBunker);
            int positionTwo = -1;
            for (int i = positionOne; i < all.Count; i++)
            {
                int num;
                bool isNumeric = int.TryParse(all[i], out num);

                if (!isNumeric && i != positionOne)
                {
                    positionTwo = i;
                    break;
                }
            }

            if (positionTwo <= positionOne)
            {
                return false;
            }
            if (counter > positionOne && counter < positionTwo)
            {
                return false;
            }

            return true;
        }
    }
}