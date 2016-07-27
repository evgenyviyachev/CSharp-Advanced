using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_20
{
    class TheHeiganDance
    {
        static void Main()
        {
            double healthHeigan = 3000000d;
            int healthPlayer = 18500;
            double damageHeiganPerRound = double.Parse(Console.ReadLine());
            int playerCurrentRow = 7;
            int playerCurrentCol = 7;
            string s = Console.ReadLine();
            bool isCloud = false;
            while (healthHeigan > 0 && healthPlayer > 0)
            {
                string[] input = s.Split(' ');
                string spell = input[0];
                int rowHeigan = int.Parse(input[1]);
                int colHeigan = int.Parse(input[2]);
                if (playerCurrentCol >= colHeigan - 1 && playerCurrentCol <= colHeigan + 1
                        && playerCurrentRow >= rowHeigan - 1 && playerCurrentRow <= rowHeigan + 1)
                {
                    if (playerCurrentRow == rowHeigan - 1 && playerCurrentRow > 0)
                    {
                        healthHeigan -= damageHeiganPerRound;
                        if (isCloud)
                        {
                            healthPlayer -= 3500;
                            if (healthPlayer <= 0)
                            {
                                break;
                            }
                        }
                        if (healthHeigan <= 0)
                        {
                            break;
                        }
                        playerCurrentRow -= 1;
                        isCloud = false;
                    }
                    else if (playerCurrentCol == colHeigan + 1 && playerCurrentCol < 14)
                    {
                        healthHeigan -= damageHeiganPerRound;
                        if (isCloud)
                        {
                            healthPlayer -= 3500;
                            if (healthPlayer <= 0)
                            {
                                break;
                            }
                        }
                        if (healthHeigan <= 0)
                        {
                            break;
                        }
                        playerCurrentCol += 1;
                        isCloud = false;
                    }
                    else if (playerCurrentRow == rowHeigan + 1 && playerCurrentRow < 14)
                    {
                        healthHeigan -= damageHeiganPerRound;
                        if (isCloud)
                        {
                            healthPlayer -= 3500;
                            if (healthPlayer <= 0)
                            {
                                break;
                            }
                        }
                        if (healthHeigan <= 0)
                        {
                            break;
                        }
                        playerCurrentRow += 1;
                        isCloud = false;
                    }
                    else if (playerCurrentCol == colHeigan - 1 && playerCurrentCol > 0)
                    {
                        healthHeigan -= damageHeiganPerRound;
                        if (isCloud)
                        {
                            healthPlayer -= 3500;
                            if (healthPlayer <= 0)
                            {
                                break;
                            }
                        }
                        if (healthHeigan <= 0)
                        {
                            break;
                        }
                        playerCurrentCol -= 1;
                        isCloud = false;
                    }
                    else {
                        healthHeigan -= damageHeiganPerRound;
                        if (isCloud)
                        {
                            healthPlayer -= 3500;
                            if (healthPlayer <= 0)
                            {
                                break;
                            }
                        }
                        if (healthHeigan <= 0)
                        {
                            break;
                        }
                        if (spell.Equals("Cloud"))
                        {
                            isCloud = true;
                            healthPlayer -= 3500;
                        }
                        else {
                            isCloud = false;
                            healthPlayer -= 6000;
                        }
                    }
                }
                else {
                    healthHeigan -= damageHeiganPerRound;
                    if (isCloud)
                    {
                        healthPlayer -= 3500;
                        if (healthPlayer <= 0)
                        {
                            break;
                        }
                    }
                    if (healthHeigan <= 0)
                    {
                        break;
                    }
                    isCloud = false;
                }
                try
                {
                    s = Console.ReadLine();
                }
                catch (Exception e)
                {
                    break;
                }
            }
            if (healthHeigan <= 0 && healthPlayer > 0)
            {
                Console.WriteLine("Heigan: Defeated!");
                Console.WriteLine("Player: " + healthPlayer);
                Console.WriteLine("Final position: " + playerCurrentRow + ", " + playerCurrentCol);
            }
            if (healthPlayer <= 0 && healthHeigan > 0)
            {
                if (isCloud)
                {
                    Console.WriteLine("Heigan: " + string.Format("{0:0.00}", healthHeigan));
                    Console.WriteLine("Player: Killed by Plague Cloud");
                    Console.WriteLine("Final position: " + playerCurrentRow + ", " + playerCurrentCol);
                }
                else {
                    Console.WriteLine("Heigan: " + string.Format("{0:0.00}", healthHeigan));
                    Console.WriteLine("Player: Killed by Eruption");
                    Console.WriteLine("Final position: " + playerCurrentRow + ", " + playerCurrentCol);
                }
            }
            if (healthHeigan <= 0 && healthPlayer <= 0)
            {
                Console.WriteLine("Heigan: Defeated!");
                if (isCloud)
                {
                    Console.WriteLine("Player: Killed by Plague Cloud");
                    Console.WriteLine("Final position: " + playerCurrentRow + ", " + playerCurrentCol);
                }
                else {
                    Console.WriteLine("Player: Killed by Eruption");
                    Console.WriteLine("Final position: " + playerCurrentRow + ", " + playerCurrentCol);
                }
            }
        }
    }
}